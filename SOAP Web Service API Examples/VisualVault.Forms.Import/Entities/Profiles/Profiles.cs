using System.Collections.Generic;

namespace VisualVault.Forms.Import.Entities.Profiles
{
    [System.SerializableAttribute]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Profiles
    {
        public Profiles()
        {
            Items = new List<Profile>();
        }

        public bool Exists(string name)
        {
            return ProfileHandler.ProfileExists(this, name);
        }

        public void Delete(string name)
        {
            ProfileHandler.DeleteProfile(this, name, true);
        }

        public Profile GetByName(string name)
        {
            return ProfileHandler.GetProfileByName(this, name);
        }

        public List<Profile> GetProfiles()
        {
            return ProfileHandler.GetProfiles(this);
        }
        
        public void Add(Profile profile)
        {
            Items.Add(profile);
            Save();
        }

        public void Save()
        {
            ProfileHandler.SaveProfiles(this);
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Profile> Items;
    } 
}
