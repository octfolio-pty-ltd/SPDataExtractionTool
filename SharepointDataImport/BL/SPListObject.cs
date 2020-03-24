using System;

namespace SharepointDataImport.BL
{
    public class SPListObject
    {
        public string ExternalFieldName { get; set; }
        public string InternalFieldName { get; set; }
        public string Type { get; set; }
        public string DisplayName
        {
            get
            {
                return String.Format("{0} ({1})", ExternalFieldName, Type);
            }
        }
    }
}