using System.Collections.Generic;
using System.Diagnostics;
using VVFormDefinitions;

namespace VisualVault.Examples.IndexFields.WebServiceIntegration.BusinessLogic.Validation
{
    public class ValidateIndexFields
    {
        public static bool Validate(List<DocumentIndexField> indexFieldList, out string returnMessage, out string returnTitle, out string returnSubject, out List<DocumentIndexField> returnDataList)
        {
            var success = false;

            //create outgoing FormFieldCollection
            returnDataList = new List<DocumentIndexField>();

            //loop through the index fields and validate values
            foreach (var indexfield in indexFieldList)
            {
                //list formfield information
                Debug.WriteLine("FieldLabel = " + indexfield.FieldLabel);
                Debug.WriteLine("FieldDescription = " + indexfield.FieldDescription);
                Debug.WriteLine("DataFieldID = " + indexfield.DataFieldID);
                Debug.WriteLine("DataDhID = " + indexfield.DataDhID);
                Debug.WriteLine("DataID = " + indexfield.DataID);
                Debug.WriteLine("DataValue = " + indexfield.DataValue);
                Debug.WriteLine("FieldType = " + indexfield.FieldType);

                if (indexfield.FieldLabel == "Name")
                {
                    indexfield.DataValue = "Sample Data";
                    returnDataList.Add(indexfield);
                }
            }

            //set return result status
            success = true;

            //set return messages
            returnMessage = "<b>No error was returned</b><br><br><span style='color: blue;'>This should be a really long explaination that will test the ability of the HTML Message Display to correctly display an HTML message. If all is good the messagebox height should continue to expand with the height of the text, if not the text will overfloe its boundry and place itselfs on top of the bottom of the box.</span>";
            returnTitle = "Index Field Validation";
            returnSubject = "Response From Index Field Validation";

            return success;
        }
    }
}