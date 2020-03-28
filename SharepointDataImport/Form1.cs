using CsvHelper;
using SharepointDataImport.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace SharepointDataImport
{
	public partial class Form1 : Form
	{
		private string spListName = null;
		private string spUser;
		private string spDomain;
		private string spPass;
		private List<SPListObject> fieldList;
		private List<SPListObject> selectedFieldList;

		public Form1()
		{
			InitializeComponent();
		}

		private bool SetCredentials()
		{
			bool missingData = true;
			spUser = txtUser.Text.Trim();
			spDomain = txtDomain.Text.Trim();
			spPass = txtPassword.Text.Trim();

			if (txtServer.Text.Trim() == String.Empty)
				MessageBox.Show("Provide URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else if (txtDomain.Text.Trim() == String.Empty)
				MessageBox.Show("Provide domain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else if (txtUser.Text.Trim() == String.Empty)
				MessageBox.Show("Provide user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else if (txtPassword.Text.Trim() == String.Empty)
				MessageBox.Show("Provide password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
				missingData = false;

			return missingData;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (SetCredentials())
				return;
			SharepointWebServices.Lists proxySP = new SharepointWebServices.Lists();
			proxySP.Url = String.Format("{0}/_vti_bin/lists.asmx", txtServer.Text.Trim()); ;
			proxySP.Credentials = new NetworkCredential(spUser, spPass, spDomain);
			try
			{
				Dictionary<string, string> SPLists = new Dictionary<string, string>();
				XmlNode nodes = proxySP.GetListCollection();

				foreach (XmlNode node in nodes)
				{
					if (node.Name == "List")
					{
						string listType = "";
						if (node.Attributes["BaseType"].Value == "0")
							listType = "List";
						else
							listType = "Library";
						//if (node.Attributes["BaseType"].Value == "0")
						//{
						string title = node.Attributes["Title"].Value;
						string count = node.Attributes["ItemCount"].Value;
						SPLists.Add(title, String.Format("{0} ({1} rows) ({2})", title, count, listType));
						//}
					}
				}

				lbAvailableLists.DataSource = new BindingSource(SPLists, null);
				lbAvailableLists.DisplayMember = "Value";
				lbAvailableLists.ValueMember = "Key";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void btnGetListInfo_Click(object sender, EventArgs e)
		{
			if (SetCredentials())
				return;
			lbFields.DataSource = null;
			lbFields.Items.Clear();
			fieldList = new List<SPListObject>();


			if (lbAvailableLists.SelectedIndex == -1)
			{
				MessageBox.Show("Please, select a list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			spListName = lbAvailableLists.SelectedValue.ToString();

			SharepointWebServices.Lists proxySP = new SharepointWebServices.Lists();
			proxySP.Url = String.Format("{0}/_vti_bin/lists.asmx", txtServer.Text.Trim()); ;
			proxySP.Credentials = new NetworkCredential(spUser, spPass, spDomain);

			try
			{
				//Clear fields
				lbFields.DataSource = null;

				Dictionary<string, string> SPColumns = new Dictionary<string, string>();
				XmlNode nodes = proxySP.GetList(spListName);

				foreach (XmlNode node in nodes)
				{
					if (node.Name == "Fields")
					{
						for (int f = 0; f < node.ChildNodes.Count; f++)
						{
							if (node.ChildNodes[f].Name == "Field")
							{
								string name = node.ChildNodes[f].Attributes["Name"].Value;
								string displayName = node.ChildNodes[f].Attributes["DisplayName"].Value;
								string type = node.ChildNodes[f].Attributes["Type"].Value;

								fieldList.Add(new SPListObject
								{
									ExternalFieldName = node.ChildNodes[f].Attributes["DisplayName"].Value,
									InternalFieldName = node.ChildNodes[f].Attributes["Name"].Value,
									Type = node.ChildNodes[f].Attributes["Type"].Value
								}); ;


								SPColumns.Add(name, String.Format("{0} ({1})", displayName, type));
							}
						}
					}
				}

				//Order list & binding.
				List<SPListObject> sortedList = fieldList.OrderBy(o => o.ExternalFieldName).ToList();
				lbFields.DataSource = sortedList;
				lbFields.DisplayMember = "DisplayName";
				lbFields.ValueMember = "InternalFieldName";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}

		}

		private void btnExtractInfo_Click(object sender, EventArgs e)
		{
			if (SetCredentials())
				return;
			//Verify if there are items selected
			if (lbFields.SelectedItems.Count <= 0)
			{
				MessageBox.Show("Please, select one or more columns on the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			selectedFieldList = new List<SPListObject>();

			//Get column list from List Box.
			foreach (var item in lbFields.SelectedItems)
			{
				SPListObject spListItem = (SPListObject)item;
				selectedFieldList.Add(spListItem);
			}

			//Disable buttons.
			DisableButtons();

			bgWorker.RunWorkerAsync();
		}

		private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			int counter = 0;
			SPHelper spHelper = new SPHelper();
			string SPViewFields = spHelper.GetViewFields(selectedFieldList);
			string SPQuery = spHelper.GetQuery();

			SharepointWebServices.Lists proxySP = new SharepointWebServices.Lists();
			proxySP.Url = String.Format("{0}/_vti_bin/lists.asmx", txtServer.Text.Trim()); ;
			proxySP.Credentials = new NetworkCredential(spUser, spPass, spDomain);

			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				XmlElement query = xmlDoc.CreateElement("Query");
				XmlElement viewFields = xmlDoc.CreateElement("ViewFields");
				XmlElement queryOptions = xmlDoc.CreateElement("QueryOptions");

				query.InnerXml = SPQuery;
				viewFields.InnerXml = SPViewFields;
				queryOptions.InnerXml = spHelper.GetQueryOptions();

				//Report 1 - Data from ws
				bgWorker.ReportProgress(10);

				XmlNode nodes = proxySP.GetListItems(spListName, null, query, viewFields, "0", queryOptions, null);
				//Report 2 - Data from ws
				bgWorker.ReportProgress(30);

				//Create folder for extract data.
				SPHelper.CreatePath(spListName);

				using (TextWriter writer = new StreamWriter(SPHelper.GetCsvFullName(), false, System.Text.Encoding.UTF8))
				{
					var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
					//Write headers.
					//Add count row.
					csv.WriteField("GENERATED ID");
					//Add extra columns for mixed fields.
					foreach (var field in selectedFieldList)
					{
						csv.WriteField(field.ExternalFieldName);
						//Extra columns
						switch (field.Type)
						{
							case "Calculated":
							case "Lookup":
							case "File":
							case "User":
								csv.WriteField(String.Format("{0} - ID", field.ExternalFieldName));
								csv.WriteField(String.Format("{0} - Value", field.ExternalFieldName));
								break;
						}
					}
					csv.NextRecord();

					foreach (XmlNode node in nodes)
						if (node.Name == "rs:data")
							for (int f = 0; f < node.ChildNodes.Count; f++)
							{
								var progress = (((f + 1) * 100) / node.ChildNodes.Count) * 0.7;
								bgWorker.ReportProgress((int)progress + 30);
								if (node.ChildNodes[f].Name == "z:row")
								{
									//Number of rows.
									counter += 1;
									//Write Generated Id
									csv.WriteField(String.Format("R{0}", counter));
									foreach (var field in selectedFieldList)
									{
										//Get value.
										var value = String.Empty;
										if (node.ChildNodes[f].Attributes["ows_" + field.InternalFieldName] != null)
											value = node.ChildNodes[f].Attributes["ows_" + field.InternalFieldName].Value;
										//Write value
										if (field.Type == "Attachments")
										{
											if (value.StartsWith(";#"))
											{
												value = value.Remove(0, 2);
											}
											if (value.EndsWith(";#"))
											{
												value = value.Remove(value.Length - 2, 2);
											}


											csv.WriteField(value.Replace(";#", "|"));
										}
										else
											csv.WriteField(value);

										switch (field.ExternalFieldName)
										{
											case "Encoded Absolute URL":
												//Check if download option is marked.
												if (chkIncludeFiles.Checked)
												{
													Uri uri = new Uri(value);

													using (WebClient myWebClient = new WebClient())
													{
														myWebClient.UseDefaultCredentials = true;

														myWebClient.Credentials = new NetworkCredential(String.Format(@"{0}\{1}", spDomain, spUser), spPass);
														SPHelper.CreatePathForFiles(counter);
														myWebClient.DownloadFile(value, String.Format(@"{0}\{1}", SPHelper.GetPathForFiles(counter), Path.GetFileName(uri.LocalPath)));
													}
												}
												break;
										}

										//Extra columns ID - VALUE
										switch (field.Type)
										{
											case "Calculated":
											case "Lookup":
											case "File":
											case "User":
												if (value == String.Empty)
												{
													csv.WriteField(value);
													csv.WriteField(value);
												}
												else
												{
													var aux = value.Split(new string[] { ";#" }, StringSplitOptions.None);
													csv.WriteField(aux[0]);
													csv.WriteField(aux[1]);
												}
												break;
											case "Attachments":
												var filesFromItem = value.Split(new string[] { ";#" }, StringSplitOptions.None);
												foreach (var itemFile in filesFromItem)
												{
													if (itemFile.Trim().Length > 0 && itemFile != "0")
													{
														//Check if download option is marked.
														if (chkIncludeFiles.Checked)
														{
															Uri uri = new Uri(itemFile);
															using (WebClient myWebClient = new WebClient())
															{
																myWebClient.UseDefaultCredentials = true;

																myWebClient.Credentials = new NetworkCredential(String.Format(@"{0}\{1}", spDomain, spUser), spPass);
																SPHelper.CreatePathForImages(counter);
																myWebClient.DownloadFile(itemFile, String.Format(@"{0}\{1}", SPHelper.GetPathForImage(counter), Path.GetFileName(uri.LocalPath)));
															}
														}
													}
												}
												break;
										}
									}
									csv.NextRecord();
								}
							}
				}
				bgWorker.ReportProgress(100);
			}
			catch (Exception ex)
			{
				bgWorker.ReportProgress(100);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbBar.Value = e.ProgressPercentage;
		}

		private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			EnableButtons();
			MessageBox.Show("Process completed!", "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void DisableButtons()
		{
			btnConnect.Enabled = false;
			btnGetListInfo.Enabled = false;
			btnExtractInfo.Enabled = false;
		}

		private void EnableButtons()
		{
			btnConnect.Enabled = true;
			btnGetListInfo.Enabled = true;
			btnExtractInfo.Enabled = true;
		}
	}
}
