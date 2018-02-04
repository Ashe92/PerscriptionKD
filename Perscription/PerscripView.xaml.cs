using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Perscription
{
    /// <summary>
    /// Interaction logic for PerscripView.xaml
    /// </summary>
    public partial class PerscripView : Window
    {
        PerscriptionEntities conn = new PerscriptionEntities();
        Perscript perscript = null;
        
        //dataforprint
        string DoctorInfo;
        int DoctorNo;
        string PatientInfo;
        List<string> ListMedicine = new List<string>();
        List<string> ListLvl = new List<string>();
        public PerscripView(Perscript obj)
        {
            InitializeComponent();
            LoadObject();
            perscript = obj;            
        }

        private void GetDoctorInfo()
        {
            Doctor doctor = conn.Doctor.Where(d => d.IdDoctor == perscript.DoctorRecep.IdDoctor).First();
            DoctorInfo = doctor.Name + " " + doctor.Surname + "\r\n" + doctor.PESEL + "\r\n" + doctor.ProfessionNo.ToString();
            DoctorNo = doctor.ProfessionNo;
        }

        private void GetPatientInfo()
        {
            Patient patient = conn.Patient.Where(d => d.IdPatient == perscript.Patient.IdPatient).First();
            PatientInfo = patient.Name + " " + patient.Surname + "\r\n" + patient.PESEL + "\r\n" + patient.Adddres;
        }

        private void GetMedicines()
        {
            foreach(Medicine med in perscript.Medicine)
            {
                ListMedicine.Add(med.Name + " "+ med.NameInt + " " + med.Form + " " + med.Dose + " " + med.Wrapping);
                //fin level 
                ListLvl.Add(FindLvl(med));
            }
        }

        private string FindLvl(Medicine medicine)
        {
            string temp= "100 %";
            Level Level = conn.Level.Where(l => l.MedicineBL7 == medicine.BL7).First();
            if (Level != null)
            {
                temp = Level.LevelName;                
            }
            return temp;
        }
        private void LoadObject()
        {
            ImageBrush brush = new ImageBrush();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            brush.ImageSource = new BitmapImage(new Uri(path+"\\Images\\Perscript.png", UriKind.Relative));
            cnPerscript.Background = brush;
            DeCreate();
        }


        private void DeCreate()
        {
            GetDoctorInfo();
            GetPatientInfo();
            GetMedicines();
        }
    }
}
