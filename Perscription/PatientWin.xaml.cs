using Perscription.Sql;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PatientWin.xaml
    /// </summary>
    public partial class PatientWin : Window
    {
        PerscriptionEntities dbo;
        bool SaveObj = false;
        public PatientWin(Patient obj)
        {
            InitializeComponent();
            dbo = new PerscriptionEntities();
            if(obj != null)
            {
                SetModel(obj);
            }
        }

        private void SaveActual(object sender, RoutedEventArgs e)
        {
            using (PerscriptionEntities db = new PerscriptionEntities())
            {
                try
                {
                    if (tbName.Text!=null && tbSurname.Text != null && tbPesel.Text != null && tbAddres.Text !=null)
                    {
                        Patient saveobj = new SqlConstructors().RetPatient(tbName.Text, tbSurname.Text, tbPesel.Text, tbAddres.Text, idPatientTextBox.Text, SaveObj);
                        if (saveobj != null)
                        {
                            if (SaveObj)
                            {
                                db.Entry(saveobj).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                            else
                            {
                                db.Patient.Add(saveobj);
                                db.SaveChanges();
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException("Paramaters cannot be null", "Null parameters");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
            }
        }

        private void SetModel(Patient patient)
        {
            idPatientTextBox.Text = patient.IdPatient.ToString();
            tbName.Text = patient.Name;
            tbSurname.Text = patient.Surname;
            tbPesel.Text = patient.PESEL;
            tbBirthday.Text = patient.Birthday.ToString();
            tbAddres.Text = patient.Adddres;
            SaveObj = true;
        }

    
    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //    Perscription.PerscriptionDataSet perscriptionDataSet = ((Perscription.PerscriptionDataSet)(this.FindResource("perscriptionDataSet")));
            //    // Load data into the table Patient. You can modify this code as needed.
            //    Perscription.PerscriptionDataSetTableAdapters.PatientTableAdapter perscriptionDataSetPatientTableAdapter = new Perscription.PerscriptionDataSetTableAdapters.PatientTableAdapter();
            //    perscriptionDataSetPatientTableAdapter.Fill(perscriptionDataSet.Patient);
            //    System.Windows.Data.CollectionViewSource patientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("patientViewSource")));
            //    patientViewSource.View.MoveCurrentToFirst();
        }
    }
}
