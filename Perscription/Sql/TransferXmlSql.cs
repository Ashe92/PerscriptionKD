using Perscription.Xml.XmlMedicine;
using Perscription.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Perscription.Sql
{
    class TransferXmlSql
    {
        #region XMlClasses
        private MedicinesXml medicineXml = new MedicinesXml();
        private XmlReadWrite xml = new XmlReadWrite();
        #endregion

        #region DatabaseClasses
        SqlConstructors sqlCon = new SqlConstructors();
        //just to chech files
        List<Medicine> listMedicine = new List<Medicine>();
        List<Level> listLevel = new List<Level>();
        #endregion

        public void TransferFromXml()
        {
            PerscriptionEntities conn = new PerscriptionEntities();
            medicineXml = xml.ReadXml();
            try
            {
                foreach (MedicineXml t in medicineXml.MedicineItems)
                {
                    if (t.Ean == "-") t.Ean = "0";
                    Medicine med = sqlCon.Medicine(t.BL7,Int64.Parse(t.Ean), Convert.ToBoolean(t.Psychotrop), Convert.ToBoolean(t.Senior), Convert.ToBoolean(t.Vaccine), t.Cost, t.Name, t.NameInt, t.Form, t.Dose, t.Wrappling);
                    listMedicine.Add(med);
                    //add to data base
                    conn.Medicine.Add(med);
                    foreach (LevelXml lvl in t.LevelLines)
                    {
                        Level level = sqlCon.Level(t.BL7, lvl.Description, lvl.Level,med.BL7);
                        listLevel.Add(level);
                        conn.Level.Add(level);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Warning");
            }
            finally
            {
                conn.SaveChanges();
            }

        }
      
    }
}
