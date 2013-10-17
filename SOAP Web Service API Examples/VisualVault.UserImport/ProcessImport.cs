using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;using VVRuntime.VisualVault.Security;

namespace VisualVault.UserImport
{
    class ProcessImport
    {
        /// <summary>
        /// Read CSV file and import users.  For this simple example assume the column names
        /// in the CSV file match the user properties.
        /// </summary>
        ProcessImport()
        {
            
        }
        
        /// <summary>
        /// Read csv file and return list of user objects.  User objects only created for each row in the csv file where userID and password exist.
        /// </summary>
        /// <param name="filePath">Path to CSV file</param>
        /// <param name="site"><c>VisualVault</c> Site object</param>
        /// <returns></returns>
        public static List<User> ReadUserCSFile(string filePath, Site site)
        {
            //read the index file and populate a list with a list of vendor records to process
            var userList = new List<User>();

            var reader = File.OpenText(filePath);
            var fileRow = reader.ReadLine();
            string[] values;
            string[] columnNames = null;

            var lineCount = 0;
            
            while (fileRow != null)
            {

                //pattern to find a delimiter and ignore other occurences of the delimiter character which occur within quotes
                var pattern = "," + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";
                var regex = new Regex(pattern);

                //const string delimStr = ",";
                //var delimiter = delimStr.ToCharArray();

                if (lineCount == 0)
                {
                    //if we are on the first line then get the column names
                    columnNames = regex.Split(fileRow);
                    //columnNames = fileRow.Split(delimiter);

                    //validate that we have all required column names
                    //for (var i = 0; i < columnNames.Length; i += 1)
                    //{
                    //    switch (columnNames[i].Trim().ToLower())
                    //    {
                    //        case "userid":
                    //            break;
                    //        case "password":
                    //            break;
                    //    }
                    //}

                    fileRow = reader.ReadLine();

                    if (fileRow != null)
                    {
                        if (fileRow.Length == 0)
                        {
                            break;
                        }
                    }

                    lineCount += 1;
                }
                else
                {
                    //else get field values

                    values = regex.Split(fileRow);
                    //values = fileRow.Split(delimiter);

                    var fieldCount = values.Length;

                    if (fieldCount > 0)
                    {
                        var userID = "";
                        var firstName = "";
                        var lastName = "";
                        var initial = "";
                        var email = "";
                        var password = "";

                        //loop through the values in the row and create a customer contact object
                        for (var i = 0; i < fieldCount; i += 1)
                        {
                            if (columnNames != null)
                                switch (columnNames[i].Trim().ToLower())
                                {
                                    case "userid":
                                        userID = values[i].Trim();
                                        break;
                                    case "firstname":
                                        firstName = values[i].Trim();
                                        break;
                                    case "lastname":
                                        lastName = values[i].Trim();
                                        break;
                                    case "initial":
                                        initial = values[i].Trim();
                                        break;
                                    case "email":
                                        email = values[i].Trim();
                                        break;
                                    case "password":
                                        password = values[i].Trim();
                                        break;
                                }
                        }

                        //create new user if user does not exist
                        if (userID.Length > 0 && password.Length > 0)
                        {
                            //if user exists an exception will be thrown
                            try
                            {
                                var newUser = site.NewUser(userID, firstName, initial, lastName, email, password);

                                userList.Add(newUser);
                            }
                            catch
                            {
                                
                            }
                        }
                    }

                    fileRow = reader.ReadLine();

                    if (fileRow != null)
                    {
                        if (fileRow.Length == 0)
                        {
                            break;
                        }
                    }

                    lineCount += 1;
                }
                
            }

            reader.Close();

            return userList;
        }
    }
}
