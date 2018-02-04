using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Perscription.Xml.XmlMedicine
{

    [XmlRoot("Leki")]
    public class MedicinesXml
    {
        #region Variables
        private IList<MedicineXml> medicineLines;
        #endregion

        #region XMlLines
        [XmlIgnore]
        public IList<MedicineXml> MedicineItems
        {
            get
            {
                return this.medicineLines;
            }
            set
            {
                this.medicineLines = value;
            }
        }
        [XmlElement("Lek")]
        public MedicineXml[] MedicineLines
        {
            get
            {
                return MedicineItems.ToArray();
            }
            set
            {
                MedicineItems = value.ToList<MedicineXml>();
            }
        }
        #endregion
    }
    
}
