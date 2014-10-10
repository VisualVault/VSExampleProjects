
using System;

namespace VisualVault.Examples.Common
{
    public static class Constants
    {
        /// DeveloperId, DeveloperKey, DeveloperSecret are generated in your VisualVault Account Properties screen.
        /// Developer Id and Key should be the same value
        public static string DeveloperId = "e9a31da0-fcd4-4d8f-9fb2-187b04bb77b1";
        public static string DeveloperKey = "e9a31da0-fcd4-4d8f-9fb2-187b04bb77b1";
        public static string DeveloperSecret = "uGyXZLR0FSqi6nnO4dDeB5oxQNAk9yw/aCXvxn1Yu0k=";

        //Product Id can be any .Net GUID (reserved for future use)
        public static Guid ProductId = new Guid("6451FB0D-7A35-4F71-99C4-B584053C3CA3");

        //URL of a VisualVault Instance
        //Example:  https://demo.visualvault.com/app/CustomerName/DatabaseName
        //public static string SoapApiServerUrl = "https://www.grmorc.com/App/CityMontereyPark/Main";
        public static string SoapApiServerUrl = "https://demo.visualvault.com/app/CustomerName/DatabaseName";
        public static string SoapApiTargetServerUrl = "https://demo.visualvault.com/app/CustomerName/DatabaseName";
        
        public static string UserId = "";
        public static string Password = "";
    }
}
