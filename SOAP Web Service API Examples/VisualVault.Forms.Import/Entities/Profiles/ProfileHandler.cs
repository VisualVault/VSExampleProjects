using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace VisualVault.Forms.Import.Entities.Profiles
{
    public class ProfileHandler
    {
        private const string MFileName = "FormImportExportProfiles.xml";

        #region Status Class Definitions

        public class Status
        {
            public bool Successful;
            public string Message = string.Empty;
        }

        public class StatusSave : Status
        {
            public Profiles Profiles;
            public bool Exists;
        }

        #endregion

        #region Load and Save Profiles

        public static Profiles LoadProfiles()
        {
            var filePath = GetFileLocation();

            var serializer = new XmlSerializer(typeof(Profiles));

            if (!File.Exists(filePath))
            {
                CreateDefault();
            }

            TextReader reader = new StreamReader(filePath);
            var profiles = (Profiles)serializer.Deserialize(reader);
            reader.Close();

            return profiles;
        }

        public static string GetFileLocation()
        {
            var filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData);

            filePath = Path.Combine(filePath, "VisualVault");

            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            filePath = Path.Combine(filePath, "FormImportUtility");

            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                
            var fileLocation = Path.Combine(filePath, MFileName);

            return fileLocation;
        }

        public static Profiles SaveProfiles(Profiles profiles)
        {
            var serializer = new XmlSerializer(typeof(Profiles));
            TextWriter writer = new StreamWriter(GetFileLocation());
            serializer.Serialize(writer, profiles);
            writer.Close();

            return profiles;
        }

        public static StatusSave SaveProfile(Profiles profiles, Profile profile, bool overwrite)
        {
            var result = new StatusSave();

            // does an profile with the same name already exist
            var existingProfile = GetProfileByName(profiles, profile.Name);

            if (existingProfile != null)
            {
                // a profile with the same name already existed and we're allowed overwrite it
                if (overwrite)
                {
                    profiles = DeleteProfile(profiles, existingProfile, true);
                    profiles.Items.Add(profile);
                    result.Profiles = SaveProfiles(profiles);
                }
                else
                {
                    result.Message = "A profile with that name already exists.";
                    result.Exists = true;
                }
            }
            else
            {
                // the profile is new, lets add and save it
                profiles.Items.Add(profile);
                result.Profiles = SaveProfiles(profiles);
            }

            // finish setting the status
            if (result.Profiles == null)
            {
                if (result.Message == string.Empty)
                {
                    result.Message = "There was an problem saving the profile.";
                }
            }
            else
            {
                result.Successful = true;
                result.Message = "The profile was saved successfully.";
            }

            return result;
        }

        public static StatusSave SaveProfileWithNewName(Profiles profiles, Profile profile, string newProfileName)
        {
            var result = new StatusSave();

            // does an profile with the same name already exist
            var existingProfile = GetProfileByName(profiles, profile.Name);

            if (existingProfile != null)
            {
                // a profile with the same name already existed and we're allowed overwrite it
                profiles = DeleteProfile(profiles, existingProfile, true);

                profile.Name = newProfileName;
                profiles.Items.Add(profile);

                result.Profiles = SaveProfiles(profiles);
            }

            // finish setting the status
            if (result.Profiles == null)
            {
                if (result.Message == string.Empty)
                {
                    result.Message = "There was an problem saving the profile.";
                }
            }
            else
            {
                result.Successful = true;
                result.Message = "The profile was saved successfully.";
            }

            return result;
        }

        #endregion

        #region Delete Profiles

        public static Profiles DeleteProfile(Profiles profiles, Profile profile, bool saveToDisc)
        {
            profiles.Items.Remove(profile);
            if (saveToDisc) { SaveProfiles(profiles); }
            return profiles;
        }

        public static Profiles DeleteProfile(Profiles profiles, string name, bool saveToDisc)
        {
            profiles.Items.RemoveAll(oProfile => oProfile.Name.ToLower() == name.ToLower());
            if (saveToDisc) { SaveProfiles(profiles); }
            return profiles;
        }

        #endregion

        public static bool ProfileExists(Profiles profiles, string name)
        {
            var result = GetProfileByName(profiles, name) != null;

            return result;
        }

        public static bool MatchingProfiles(Profile profile1, Profile profile2)
        {
            var result = false;

            var ms = new MemoryStream();
            var serializer = new XmlSerializer(typeof(Profile));

            // represent a profile as a xml string
            serializer.Serialize(ms, profile1);
            var pfile1 = System.Text.Encoding.UTF8.GetString(ms.ToArray());

            ms = new MemoryStream();

            // represent a profile as a xml string
            serializer.Serialize(ms, profile2);
            var pfile2 = System.Text.Encoding.UTF8.GetString(ms.ToArray());

            if (System.String.CompareOrdinal(pfile1, pfile2) == 0)
            {
                result = true;
            }

            return result;
        }

        #region Searches

        public static Profile GetProfileByName(Profiles profiles, string name)
        {
            var result = profiles.Items.Find(oProfile => oProfile.Name.ToLower() == name.ToLower());
            return result;
        }

        public static List<Profile> GetProfiles(Profiles profiles)
        {
            var result = profiles.Items.FindAll(oProfile => oProfile.Name.Length>0);
            return result;
        }

        #endregion

        #region Misc

        public static void CreateDefault()
        {
            var myProfiles = new Profiles();

            var myProfile = CreateNew();

            myProfiles.Items.Add(myProfile);

            SaveProfiles(myProfiles);
        }

        public static Profile CreateNew()
        {
            return CreateNew("Default");
        }

        public static Profile CreateNew(string name)
        {
            // create a default profile
            var myProfile = new Profile
            {
                ServerUrl = "",
                Name = name,
                Username = "",
                Password = "",
                ImportCsvSourcePath = @"c:\",
                ExportCsvTargetPath = @"c:\",
                ImportFormTemplateName = "00000000-0000-0000-0000-000000000000",
                ExportFormDashboardName = "00000000-0000-0000-0000-000000000000",
                CsvHeadersQuoted = false,
                CsvLineItemsQuoted = true,
                AllowUpdate = false
            };
            return myProfile;
        }

        #endregion
    }
}
