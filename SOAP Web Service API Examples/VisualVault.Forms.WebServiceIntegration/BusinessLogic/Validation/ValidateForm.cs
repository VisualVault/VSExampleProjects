using System;
using System.Web.Configuration;
using VVFormDefinitions;
using VVRuntime.VisualVault;
using VisualVault.Examples.Common;

namespace VisualVault.Forms.WebServiceIntegration.BusinessLogic.Validation
{
    ///<summary>
    ///
    ///</summary>
    public static class ValidateForm
    {
        private static Vault _vault;

        ///<summary>
        ///
        ///</summary>
        ///<param name="fo"></param>
        ///<param name="returnMessage"></param>
        ///<param name="returnTitle"></param>
        ///<param name="returnSubject"></param>
        ///<param name="returnFieldColl"></param>
        ///<returns></returns>
        public static bool Validate(Form fo, out string returnMessage, out string returnTitle, out string returnSubject, out FormFieldCollection returnFieldColl)
        {
            //login to VisualVault using API values stored in web.config file
            string serverUrl = WebConfigurationManager.AppSettings["vVServerURL"];
            string userId = WebConfigurationManager.AppSettings["vVUserID"];
            string password = WebConfigurationManager.AppSettings["vVPassword"];

            returnSubject = "";

            bool response;

            returnFieldColl = new FormFieldCollection();

            _vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userId, password,Constants.DeveloperKey,Constants.DeveloperSecret,Constants.ProductId);

            if (_vault != null)
            {
                //check required fields
                response = CheckRequiredFields(fo.FormFields, out returnMessage, out returnTitle, out returnSubject,out returnFieldColl);
                //response = UpdateFormFields(fo.FormFields, out returnMessage, out returnTitle, out returnSubject, out returnFieldColl);
            }else
            {
                //unable to login to VisualVault
                response = false;
                returnTitle = "Error";
                returnMessage = "Unable to login to VisualVault.";
            }

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formFieldCollection"></param>
        /// <param name="errorMessage"></param>
        /// <param name="messageTitle"></param>
        /// <param name="messageSubject"></param>
        /// <param name="returnFieldColl"></param>
        /// <returns></returns>
        internal static bool CheckRequiredFields(FormFieldCollection formFieldCollection, out string errorMessage, out string messageTitle, out string messageSubject, out FormFieldCollection returnFieldColl)
        {
            //list form fields you want to validate here
            var requiredFields = "First Name,DOB,Place of Birth,Gender".Split(',');

            var result = true;
            errorMessage = "";
            messageTitle = "";
            messageSubject = "";
            returnFieldColl = new FormFieldCollection();

            foreach (string fieldName in requiredFields)
            {
                foreach (FormField formField in formFieldCollection)
                {
                    if (fieldName.ToLower() == formField.FieldName.ToLower())
                    {
                        bool found;

                        //If the form field has no value we assume validation failed
                        
                        //If the form field has a value and the value = select item or --select-- we assume
                        //a drop down list where no value has been selected by the user

                        switch (formField.FieldValue.ToLower())
                        {
                            case "select item":
                            case "--select--":
                            case "":
                                found = false;
                                break;
                            default:
                                found = true;
                                break;
                        }

                        //Always set the RenderValidationError property to true|false

                        if (!found)
                        {
                            if (errorMessage.Length > 0)
                            {
                                errorMessage += ",";
                            }

                            //turn on the validation error icon
                            formField.RenderValidationError = true;
                            returnFieldColl.Add(formField);

                            errorMessage += fieldName;

                        }
                        else
                        {
                            //turn off the validation error icon
                            formField.RenderValidationError = false;
                            returnFieldColl.Add(formField);
                        }
                    }
                }
            }

            if (errorMessage.Length > 0)
            {
                errorMessage = errorMessage.Insert(0, "These fields have missing values: ");

                messageTitle = "Field validation error";

                messageSubject = "Missing required fields";

                result = false;
            }

            return result;
        }

        internal static bool UpdateFormFields(FormFieldCollection formFieldCollection, out string errorMessage, out string messageTitle, out string messageSubject, out FormFieldCollection returnFieldColl)
        {
            var result = true;
            errorMessage = "";
            messageTitle = "";
            messageSubject = "";
            returnFieldColl = new FormFieldCollection();

            try
            {

                //This method is a simple example of updating form field values

                //(1) Get the form template name. In this case we are storing the template name in the web.config file
                var formTemplateName = WebConfigurationManager.AppSettings["TestFormTemplate"];

                //(2) Instantiate a form template object by name
                var formTemplate = _vault.Forms.GetFormTemplate(formTemplateName);

                //(3) Fill in a new form.  This will be the first revision of a new form instance
                var formInstance = formTemplate.GetNewFormDataInstance();

                //(4) Populate field values for the new form instance.
                foreach (FormField formField in formInstance.FormFields)
                {
                    if (formField.FieldType == FormFieldTypes.UserIDStamp)
                    {
                        //UserIDStamp form field type is referred to as a SignatureStamp in the user interface.
                        //This field type requires special handling; in order to set the value pass in a string value of "True" 
                        //which will sign a signature using the user credentials of the authentication user (the user you used to instantiate the Vault object)

                        formField.FieldValue = "True";
                    }
                }

                //(5) Save the new form instance
                formInstance.SaveForm();

                //(6) Create a new revision of the form instance
                //formInstance = formInstance.GetNewDataInstanceRevision();

                //(7) Update form field values and Save to create a new revision of a form instance
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
