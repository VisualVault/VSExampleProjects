using System;
using System.Data;
using System.Data.SqlClient;
using VVRuntime.VisualVault;

namespace VisualVault.Forms.WebServiceIntegration.BusinessLogic.Common
{
    ///<summary>
    ///
    ///</summary>
    public static class Common
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="formID"></param>
        /// <param name="formName"></param>
        /// <returns></returns>
        internal static string GetFormLink(string baseUrl, Guid formID, string formName)
        {
            string link =
                string.Format(
                    @"<a href="""" onclick=""javascript:var clientURL='{0}Form_Details.aspx?DataID={1}" +
                    @"&hidemenu=true&title={2}';var newwindow='';var x=(document.all)?window.screenLeft+120:window.screenX+120;" +
                    @"var y=(document.all)?window.screenTop+60:window.screenY+80;;var nwidth=(920<screen.availWidth)?920:screen.availWidth-200;" +
                    @"var nheight=(700<screen.availHeight)?700:screen.availHeight-200;newwindow=" +
                    @"window.open(clientURL, '{2}', 'height=700, width=920, status=yes, resizable=yes, scrollbars=yes, menubar=no, toolbar=no," +
                    @" location=no, copyhistory=no, left='+ x + ',top=' + y +',screenX=' + x + ',screenY=' + y + '');if(nwidth!=920||nheight!=700)newwindow.resizeTo(nwidth,nheight);" +
                    @"addChildWindow(newwindow);if(newwindow)newwindow.focus();return false;"">{3}</a>", baseUrl, formID, formName.Replace("-", ""), formName);

            return link;
        }

        /// <summary>
        /// The form object passed in from <see cref="VisualVault"/> does not expose the form's Document ID
        /// value.  This function will go to the database and retrieve the form's document ID.
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="vault"></param>
        /// <returns></returns>
        internal static string GetFormDhDocID(Guid formID, Vault vault)
        {
            SqlConnection conn = new SqlConnection(vault.Configurations.GetConnectionString());

            string formDhDocID = "";

            try
            {
                const string cmdText = "SELECT TOP 1 DhdocID FROM Doc_Header WHERE DhID=@FormID";

                SqlCommand cmd = new SqlCommand(cmdText) { Connection = conn };

                cmd.Parameters.Add(new SqlParameter("@FormID", SqlDbType.UniqueIdentifier)).Value = formID;

                conn.Open();

                object objDocID = cmd.ExecuteScalar();

                if (objDocID != null) formDhDocID = ((string)objDocID);

            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;
                System.Diagnostics.Debug.WriteLine(exMessage);
                formDhDocID = "";
            }
            finally
            {
                conn.Close();
            }

            return formDhDocID;
        }
    }
}
