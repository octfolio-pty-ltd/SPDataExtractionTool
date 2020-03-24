using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SharepointDataImport.BL;

namespace SharepointDataImport.BL
{
    public class SPHelper
    {
        private static string _path;
        public string GetViewFields(List<String> selectedColumns)
        {
            StringBuilder viewFields = new StringBuilder();
            foreach (var item in selectedColumns)
            {
                viewFields.Append(String.Format("<FieldRef Name = '{0}'/>", item));
            }
            return viewFields.ToString();
        }

        public string GetViewFields(Dictionary<string, string> selectedColumns)
        {
            StringBuilder viewFields = new StringBuilder();
            foreach (var item in selectedColumns)
            {
                viewFields.Append(String.Format("<FieldRef Name = '{0}'/>", item.Key));
            }
            return viewFields.ToString();
        }

        public string GetViewFields(List<SPListObject> selectedColumns)
        {
            StringBuilder viewFields = new StringBuilder();
            foreach (var item in selectedColumns)
            {
                viewFields.Append(String.Format("<FieldRef Name = '{0}'/>", item.InternalFieldName));
            }
            return viewFields.ToString();
        }

        public string GetQuery()
        {
            //return "<OrderBy><FieldRef Name='Modified' Ascending='False'/></OrderBy>";
            return "<OrderBy><FieldRef Name='ID' /></OrderBy>";
        }

        public string GetQueryOptions()
        {
            return "<IncludeAttachmentUrls>TRUE</IncludeAttachmentUrls>";
        }

        public static void CreatePath(string listName)
        {
            string path = Directory.GetCurrentDirectory();

            var newpath = String.Format(@"{0}\{1}_{2}", path, listName, DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            Directory.CreateDirectory(newpath);

            _path = newpath;
        }

        public static string GetCsvFullName()
        {
            return _path + @"\data.csv";
        }

        public static void CreatePathForImages(int counter)
        {
            var newpath = String.Format(@"{0}\R{1}_Attachments\", _path, counter);

            Directory.CreateDirectory(newpath);
        }        

        public static string GetPathForImage(int counter)
        {
            var newpath = String.Format(@"{0}\R{1}_Attachments\", _path, counter);
            return newpath;
        }

        public static void CreatePathForFiles(int counter)
        {
            var newpath = String.Format(@"{0}\R{1}_File\", _path, counter);

            Directory.CreateDirectory(newpath);
        }

        public static string GetPathForFiles(int counter)
        {
            var newpath = String.Format(@"{0}\R{1}_File\", _path, counter);
            return newpath;
        }
    }
}
