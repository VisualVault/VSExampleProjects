using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VVFormDefinitions;

namespace VisualVault.Examples.IndexFields.WebServiceIntegration.Services
{
    /// <summary>
    /// Summary description for Validate
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Validate : System.Web.Services.WebService
    {
        //To use this sample index field validation web service:
        //(1) Register the web service within VisualVault's Web Services admin screen.
        //(2) Add an approval task to a Workflow that is associated with a document
        //(3) Configure the Approval task for External Process and select the configured Web Service

        //This example shows how to validate index fields using custom business logic.  
        //You can also modify index fields using the same approach by changing the index field's value

        //note the dependency on VVFormDefinitions.dll

        [WebMethod]
        public string[] ValidateIndexFields(List<DocumentIndexField> indexFieldList, out List<DocumentIndexField> returnDataList)
        {
            string returnMessageTitle;
            string returnMessageSubject;
            string returnMessage;


            //call the business logic class
            bool response = BusinessLogic.Validation.ValidateIndexFields.Validate(indexFieldList, out returnMessage, out returnMessageTitle, out returnMessageSubject, out returnDataList);


            //setup return response string array
            //first item in the array must be "true" or "false" which indicates validation passed or failed
            //second item in the array in an HTML formatted message which will be displayed in the form within a message box
            //third item in the array is an HTML formatted title which will be the title of the message box displayed in the form
            //fourth item in the array is an HTML formatted subject which will be displayed just above the error message at the top of the message box
            string[] responses = new string[4];

            responses[0] = response.ToString();
            responses[1] = returnMessage;
            responses[2] = returnMessageTitle;
            responses[3] = returnMessageSubject;

            return responses;
        }

    }
}
