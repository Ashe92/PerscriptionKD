using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perscription.Sql
{
    public class SqlConstructors
    {

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


        public Level Level(int medicineId, string desc, string lvlname, int bl7)
        {
            Level level = new Level
            {
                LevelName = lvlname,
                Description = desc,
                MedicineBL7= bl7
            };
            return level;
        }

        public Patient RetPatient(string name, string surname, string pesel, string address,string idPatient, bool saveobj)
        {
            Patient patient = null;
            ValidateObj validate = new ValidateObj();
            if (validate.ValidatePesel(pesel))
            {
                patient = new Patient
                {
                    Name = name,
                    Surname = surname,
                    PESEL = pesel,
                    Birthday = validate.GetBirthday(pesel),
                    Adddres = address
                };
                if (saveobj == true)
                {
                    patient.IdPatient = Int32.Parse(idPatient);
                }
            }
            else
            {
                throw new System.ArgumentException("Wrong parameter PESEL", "Patient PESEL");
            }
            return patient;
        }

        public Doctor Doctor(string name, string surname, string pesel, int profNo, ICollection<DoctorRecep> doctorRecep)
        {
            Doctor doctor = new Doctor
            {
                Name = name,
                Surname = surname,
                PESEL = pesel,
                ProfessionNo = profNo,
                DoctorRecep = doctorRecep
            };
            return doctor;
        }

        public DoctorRecep DoctorRecep(string recCat, long recNo, string recType, int idDoctor)
        {
            DoctorRecep doctorRecep = new DoctorRecep
            {
                ReceiptCat = recCat,
                ReceiptType = recType,
                ReceiptNumber = recNo,
                IdDoctor = idDoctor
            };
            return doctorRecep;
        }

        public Perscript Perscript(ICollection<Medicine> medicine, Patient patient, DoctorRecep doctorRecep)
        {
            Perscript perscript = new Perscript
            {
                Medicine = medicine,
                Patient = patient,
                DoctorRecep = doctorRecep
            };
            return perscript;
        }
    }
}
