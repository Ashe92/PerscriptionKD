using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Perscription
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PerscriptionEntities conn = new PerscriptionEntities();
        Medicine medicine = new Medicine();
        Patient patient = new Patient();
        Doctor doctor = new Doctor();
        int items = 0;
        public MainWindow()
        {
            InitializeComponent();
            SelectPatientList();
            SelectDocotr();
        }

        private void SelectDocotr()
        {
            doctor = conn.Doctor.Find(1);
            if (doctor != null)
            {
                tbDocName.Text = doctor.Name + " " + doctor.Surname;
                tbDocNo.Text = doctor.ProfessionNo.ToString();
                SelectDoctorRecep();
            }
        }

        private void SelectDoctorRecep()
        {
            List<DoctorRecep> listDoctorRecep = new List<DoctorRecep>();
            listDoctorRecep = conn.DoctorRecep.Where(t => t.IdDoctor == doctor.IdDoctor).ToList();
            foreach (DoctorRecep d in listDoctorRecep)
            {
                KeyValuePair<long, int> key = new KeyValuePair<long, int>((long)d.ReceiptNumber, d.IdReceiptNo);
                cbDoctorRecep.Items.Add(key);
            }
            cbDoctorRecep.SelectedIndex = 0;
        }

        private void SelectPatientList()
        {
            List<Patient> listPatient = new List<Patient>();
            cbPatient.DisplayMemberPath = "Key";
            cbPatient.SelectedValuePath = "Value";
            listPatient = conn.Patient.ToList();
            foreach (Patient p in listPatient)
            {
                KeyValuePair<string, int> key = new KeyValuePair<string, int>(p.Name + " " + p.Surname, p.IdPatient);
                cbPatient.Items.Add(key);
            }
            cbPatient.SelectedIndex = 0;
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            MedicineWin medWin = new MedicineWin();
            medWin.ShowDialog();            
            if (medWin.MedValue!= null)
            {                
                MedicineGrid.Items.Add(medWin.MedValue);
                items++;
                CheckBtEnabled();
            }
        }

        private void btnDeleteMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you shure you want delete selected object?", "Delete object Medicine", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MedicineGrid.Items.RemoveAt(MedicineGrid.SelectedIndex);
                items--;
                CheckBtEnabled();
            }
        }

        private void CheckBtEnabled()
        {
            if(items <=0 || items <= 5){
                btnAddMedicine.IsEnabled = true;
            }else {
                btnAddMedicine.IsEnabled = false;
            }
        }

        private void AddNewPatient(object sender, RoutedEventArgs e)
        {
            patient = null;
            PatientWin patientWin = new PatientWin(patient);
            patientWin.ShowDialog();
            PopulatePatient();
        }

        private void EditPatient(object sender, RoutedEventArgs e)
        {
            patient = (Patient)PatientGrid.SelectedItem;
            PatientWin patientWin = new PatientWin(patient);
            patientWin.ShowDialog();
            PopulatePatient();
        }

        private void DeletePatient(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you shure you want delete selected object?","Delete object Patient", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                patient = (Patient)PatientGrid.SelectedItem;
                conn.Patient.Attach(patient);
                conn.Patient.Remove(patient);
                conn.SaveChanges();
                PopulatePatient();
            }
        }

        private void TabILoadData_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new PerscriptionEntities();
            PatientGrid.ItemsSource = conn.Patient.ToList();
        }

        public void PopulatePatient()
        {
            PatientGrid.ItemsSource = conn.Patient.ToList<Patient>();
            SelectPatientList();
        }

        public void PopulateMedicine()
        {
            MedicineGrid.ItemsSource = conn.Medicine.ToList<Medicine>();
        }

        private Perscript CollectDataPerscript()
        {
            Perscript perscript = null;
            try
            {
                KeyValuePair<string, int> PatientKey = (KeyValuePair<string, int>)cbPatient.SelectedItem;
                patient = conn.Patient.Where(t => t.IdPatient == PatientKey.Value).First();
                KeyValuePair<long, int> DoctorRecepKey = (KeyValuePair<long, int>)cbDoctorRecep.SelectedItem;
                DoctorRecep doctorRecep = conn.DoctorRecep.Where(t => t.IdReceiptNo == DoctorRecepKey.Value && t.IdDoctor == doctor.IdDoctor).First();
                List<Medicine> listmed;
                Medicine[] med = new Medicine[MedicineGrid.Items.Count];
                MedicineGrid.Items.CopyTo(med, 0);
                listmed = med.ToList();
                //add all to perscription
                perscript = new Perscript
                {
                    DoctorRecep = doctorRecep,
                    Patient = patient,
                    Medicine = listmed
                };
            }
            catch (Exception exp)
            {
                MessageBox.Show("Some of element are not choosen, try again.", "Warning");
            }
            return perscript;
        }

        private void PrintPerscript(object sender, RoutedEventArgs e)
        {
            Perscript perscript   =CollectDataPerscript();
            if(perscript != null)
            {
                PerscripView perscripView = new PerscripView(perscript);
                perscripView.ShowDialog();

            }
        }
    }
}
