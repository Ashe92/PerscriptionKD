using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perscription.Xml.XmlMedicine;
using Perscription.Xml;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PerscriptionTest.XmlTest
{
    /// <summary>
    /// Summary description for XmlReadWriteTest
    /// </summary>
    [TestClass]
    public class XmlReadWriteTest
    {
        IList<LevelXml> listLevel;
        IList<MedicineXml> listMed;
        MedicinesXml medics;
        public XmlReadWriteTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSerialization()
        {
            //set data
            listLevel.Add(new LevelXml { Level = "1", Description = "1" });
            listLevel.Add(new LevelXml { Level = "2", Description = "2" });
            listMed.Add(new MedicineXml { BL7 = 8085962, Ean = "5909990419890", Psychotrop = "false", Vaccine = "false", Senior = "false", Cost = 0, Name = "Abilify", NameInt = "Aripiprazolum", Form = "tabl.uleg.rozp.w j.ustnej", Dose = "0,015 g", Wrappling = "28 tabl. (blister)", LevelItems = listLevel });
            listMed.Add(new MedicineXml { BL7 = 8085962, Ean = "5909990419890", Psychotrop = "false", Vaccine = "false", Senior = "false", Cost = 0, Name = "TEST", NameInt = "Aripiprazolum", Form = "tabl.uleg.rozp.w j.ustnej", Dose = "0,015 g", Wrappling = "28 tabl. (blister)", LevelItems = listLevel });
            
            //serialization
            string sSavePath = @"C:\Users\Kajka\Desktop\test.xml";
            medics.MedicineItems = listMed;
            //settings
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false
            };
            //uft
            XmlSerializerNamespaces names = new XmlSerializerNamespaces();
            names.Add("", "");
            XmlSerializer xmlSerial = new XmlSerializer(typeof(MedicinesXml));
            StreamWriter sw = new StreamWriter(sSavePath);
            XmlWriter xmlWriter = XmlWriter.Create(sw, settings);
            xmlSerial.Serialize(xmlWriter, medics,names);
            sw.Close();
            XmlDocument doc = new XmlDocument();
        }

        [TestMethod]
        public void TestDeseriualizatiion()
        {
            medics = null;
            string path = @"C:\Users\Kajka\Desktop\test.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(MedicinesXml));

            StreamReader reader = new StreamReader(path);
            medics = (MedicinesXml)serializer.Deserialize(reader);
            reader.Close();
        }

        [TestMethod]
        public void ReadXml()
        {
           XmlReadWrite xml = new XmlReadWrite();
           medics = xml.ReadXml();
        }

    }
}
