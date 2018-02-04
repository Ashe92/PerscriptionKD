using Perscription.Sql;
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
using System.Windows.Shapes;

namespace Perscription
{
    /// <summary>
    /// Interaction logic for MedicineWin.xaml
    /// </summary>
    public partial class MedicineWin : Window
    {
        Medicine medValue;

        public Medicine MedValue { get => medValue; set => medValue = value; }

        public MedicineWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadObject();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Medicine row = (Medicine)medicineDataGrid.SelectedItem;
            MedValue = row;
            this.Close();
        }

        public Medicine Medicine(int bl7, long ean, bool psychotrop, bool senior, bool vaccine, decimal cost, string name, string nameInt, string form, string dose, string wrapping)
        {
            Medicine medicine = new Medicine
            {
                BL7 = bl7,
                EAN = ean,
                Psychotrop = psychotrop,
                Senior = senior,
                Vaccine = vaccine,
                Cost = cost,
                Name = name,
                NameInt = nameInt,
                Dose = dose,
                Form = form,
                Wrapping = wrapping,
                Used = false
            };
            return medicine;
        }

        private void LoadFromXml(object sender, RoutedEventArgs e)
        {
            TransferXmlSql transfer = new TransferXmlSql();
            transfer.TransferFromXml();
            LoadObject();
        }

        private void LoadObject()
        {
            using (var db = new PerscriptionEntities())
            {
                if (db.Medicine.Any())
                {
                    PerscriptionEntities conn = new PerscriptionEntities();
                    medicineDataGrid.ItemsSource = conn.Medicine.ToList();
                    int selectd = medicineDataGrid.SelectedIndex;
                    levelDataGrid.ItemsSource = conn.Level.Where(l => l.MedicineBL7 == selectd).ToList();
                    //Perscription.PerscriptionDataSet perscriptionDataSet = ((Perscription.PerscriptionDataSet)(this.FindResource("perscriptionDataSet")));
                    //// Load data into the table Medicine. You can modify this code as needed.
                    ////Perscription.PerscriptionDataSetTableAdapters.MedicineTableAdapter perscriptionDataSetMedicineTableAdapter = new Perscription.PerscriptionDataSetTableAdapters.MedicineTableAdapter();
                    ////perscriptionDataSetMedicineTableAdapter.Fill(perscriptionDataSet.Medicine);
                    ////System.Windows.Data.CollectionViewSource medicineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicineViewSource")));
                    ////medicineViewSource.View.MoveCurrentToFirst();
                    //// Load data into the table Level. You can modify this code as needed.
                    //Perscription.PerscriptionDataSetTableAdapters.LevelTableAdapter perscriptionDataSetLevelTableAdapter = new Perscription.PerscriptionDataSetTableAdapters.LevelTableAdapter();
                    //perscriptionDataSetLevelTableAdapter.Fill(perscriptionDataSet.Level);
                    //System.Windows.Data.CollectionViewSource levelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("levelViewSource")));
                    //levelViewSource.View.MoveCurrentToFirst();
                }
            }
        }
    }
}
