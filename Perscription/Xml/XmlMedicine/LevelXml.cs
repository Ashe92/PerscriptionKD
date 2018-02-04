using System.Xml.Serialization;

namespace Perscription.Xml.XmlMedicine
{
    public class LevelXml
    {
       
        [XmlAttribute("poziom")]
        public string Level { get; set; }
        [XmlText]
        public string Description { get; set; }

        public void SetLevelXml(string level, string desc)
        {
            this.Level = level;
            this.Description = desc;
        }
    }
}