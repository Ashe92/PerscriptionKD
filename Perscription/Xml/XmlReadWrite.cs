using Microsoft.Win32;
using Perscription.Xml.XmlMedicine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Perscription.Xml
{
    public class XmlReadWrite
    {
        MedicinesXml medics = new MedicinesXml();
        LevelXml levelXml = new LevelXml { Level = "level1", Description = "level1Desc" };


        /// <summary>
        /// deserialize xml for medicines
        /// </summary>
        public MedicinesXml ReadXml()
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "Xml |*.xml"
            };
            if(openFile.ShowDialog() == true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MedicinesXml));
                StreamReader reader = new StreamReader(openFile.FileName);
                medics = (MedicinesXml)serializer.Deserialize(reader);
                reader.Close();
            }
            return medics;
        }



        public void WriteXml()
        {

        }

    }
}
