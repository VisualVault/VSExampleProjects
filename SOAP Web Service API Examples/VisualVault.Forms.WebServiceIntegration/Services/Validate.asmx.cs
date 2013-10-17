using System.Web.Services;
using VVFormDefinitions;


namespace VisualVault.Forms.WebServiceIntegration.Services
{
    /// <summary>
    /// Validate
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Validate : System.Web.Services.WebService
    {
        //To use this sample form validation web service:
        //(1) Register the web service within VisualVault's outside process admin screen.
        //(2) Add a Button to a form in the form designer
        //(3) Configure the form button properties to call the web service

        //This example shows how to validate form fields using custom business logic.  
        //You can also modify form fields using the same approach including changing a field's value
        //and setting the read-only property on a field to true|false

        //note the dependency on VVFormDefinitions.dll

        ///<summary>
        ///
        ///</summary>
        ///<param name="fo"></param>
        ///<param name="returnFields"></param>
        ///<returns></returns>
        [WebMethod]
        public string[] ValidateForm(Form fo, out FormField[] returnFields)
        {
            //create outgoing FormFieldCollection
            FormFieldCollection returnFieldColl;

            string returnMessageTitle;
            string returnMessageSubject;
            string returnMessage;

            //call the business logic class
            bool response = BusinessLogic.Validation.ValidateForm.Validate(fo, out returnMessage, out returnMessageTitle, out returnMessageSubject, out returnFieldColl);

            //set the form field array out parameter
            returnFields = returnFieldColl.FormFields();

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
