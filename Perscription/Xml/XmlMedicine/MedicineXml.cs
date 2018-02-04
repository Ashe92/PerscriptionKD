using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Perscription.Xml.XmlMedicine
{
    [XmlRoot(ElementName = "Lek")]
    public class MedicineXml
    {
        #region Variables
        private IList<LevelXml> ListLevelXml;
        #endregion

        [XmlAttribute("BL7")]
        public int BL7 { get; set; }
        [XmlAttribute("EAN")]
        public string Ean { get; set; }
        [XmlAttribute("psychotrp")]
        public string Psychotrop {get;set;}
        [XmlAttribute("senior")]
        public string Senior { get; set; }
        [XmlAttribute("szczepionka")]
        public string Vaccine { get; set; }
        [XmlAttribute("cena")]
        public decimal Cost { get; set; }
        [XmlElement(ElementName = "Nazwa")]
        public string Name { get; set; }
        [XmlElement(ElementName = "NazwaInt")]
        public string NameInt { get; set; }
        [XmlElement(ElementName = "Postać")]
        public string Form { get; set; }
        [XmlElement(ElementName = "Dawka")]
        public string Dose { get; set; }
        [XmlElement(ElementName = "Opakowanie")]
        public string Wrappling { get; set; }
        [XmlIgnore]
        public IList<LevelXml> LevelItems
        {
            get
            {
                return this.ListLevelXml;
            }
            set
            {
                this.ListLevelXml = value;
            }
        }
        [XmlArray("Refundacja")]
        [XmlArrayItem(typeof(LevelXml), ElementName = "Poziom")]
        public LevelXml[] LevelLines
        {
            get
            {
                return LevelItems.ToArray();
            }
            set
            {
                LevelItems = value.ToList<LevelXml>();
            }
        }

        public void SetMedicineXml(int bl7, string ean, bool psychotrop, bool senior, bool vaccine, decimal cost, string name, string nameint, string form, string dose, string wrapping, IList<LevelXml> refundation)
        {
            if (ean == "-") ean ="0";
            this.BL7 = bl7;
            this.Ean = ean;
            this.Psychotrop = psychotrop.ToString();
            this.Senior = senior.ToString();
            this.Vaccine = vaccine.ToString();
            this.Cost = cost;
            this.Name = name;
            this.NameInt = nameint;
            this.Form = form;
            this.Dose = dose;
            this.Wrappling = wrapping;
            this.LevelItems = refundation;
        }

        public bool Get(string temp)
        {
            bool value = false;
            if (temp !="False")
            {
                value = true;
            }
            return value;
        }
    }
}
