using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perscription.Sql
{
    public class ValidateObj
    {
        private static readonly int[] mnozniki = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        public bool ValidatePesel(string pesel)
        {
            bool toRet = false;
            try
            {
                if (pesel.Length == 11)
                {
                    toRet = CountSum(pesel).Equals(pesel[10].ToString());
                }
            }
            catch (Exception)
            {
                toRet = false;
            }
            return toRet;
        }


        private static string CountSum(string pesel)
        {
            int sum = 0;
            for (int i = 0; i < mnozniki.Length; i++)
            {
                sum += mnozniki[i] * int.Parse(pesel[i].ToString());
            }

            int reszta = sum % 10;
            return reszta == 0 ? reszta.ToString() : (10 - reszta).ToString();
        }

        internal DateTime GetBirthday(string pesel)
        {
            DateTime dt = new DateTime();
            
            int rok = 0;
            int mies = 0;
            int dzien = Convert.ToInt32(pesel[4].ToString()) * 10 + Convert.ToInt32(pesel[5].ToString());

            if (pesel[2] == '0' || pesel[2] == '1')
            {
                rok = 1900;
                mies = Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString());
            }
            else if (pesel[2] == '2' || pesel[2] == '3')
            {
                rok = 2000;
                mies = (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 20);
            }
            else if (pesel[2] == '4' || pesel[2] == '5')
            {
                rok = 2100;
                mies = (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 40);
            }
            else if (pesel[2] == '6' || pesel[2] == '7')
            {
                rok = 2200;
                mies = (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 60);
            }
            else if (pesel[2] == '8' || pesel[2] == '9')
            {
                rok = 1800;
                mies = (Convert.ToInt32(pesel[2].ToString()) * 10 + Convert.ToInt32(pesel[3].ToString()) - 80);
            }
            rok += Convert.ToInt32(pesel[0].ToString()) * 10 + Convert.ToInt32(pesel[1].ToString());
            String szDate = rok.ToString() + "-" + (mies < 10 ? "0" + mies.ToString() : mies.ToString()) + "-" + (dzien < 10 ? "0" + dzien.ToString() : dzien.ToString());

            bool bResult = DateTime.TryParse(szDate, out dt);


            return dt;
        }
    }
}
