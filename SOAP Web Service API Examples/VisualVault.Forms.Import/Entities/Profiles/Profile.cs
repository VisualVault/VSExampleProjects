using System;
using System.Collections.Generic;

namespace VisualVault.Forms.Import.Entities.Profiles
{
    [SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Profile : ICloneable
    {
        #region Fields

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Username { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Password { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ServerUrl { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ImportCsvSourcePath { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExportCsvTargetPath { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ImportFormTemplateName { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExportFormDashboardName { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool CsvHeadersQuoted { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool CsvLineItemsQuoted { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CsvDelimeterCharacter { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool AllowUpdate { get; set; }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DateTimeFormat { get; set; }

        #endregion

        #region Methods

        public bool CompareTo(Profile profile)
        {
            return DoProfilesMatch(this, profile);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public Profile Copy
        {
            get { return (Profile)Clone(); }
        }

        internal static bool DoProfilesMatch(Profile profile1, Profile profile2)
        {
            return PublicFieldsAreEqual(profile1, profile2, "");
        }

        public static bool PublicFieldsAreEqual<T>(T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                var type = typeof(T);

                var ignoreList = new List<string>(ignore);

                foreach (System.Reflection.FieldInfo fieldInfo in type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(fieldInfo.Name))
                    {
                        var selfValue = type.GetField(fieldInfo.Name).GetValue(self);

                        var toValue = type.GetField(fieldInfo.Name).GetValue(to);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return self == to;
        }

        #endregion
    } 
}
