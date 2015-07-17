using System;
using System.Collections.Generic;
using System.Text;

namespace OpdrachtDierenasiel1
{
    class DierenAsiel
    {
        private List<Huisdier> huisdier;
        /// <summary>
        /// ALS in het dierenasiel al een huisdier voorkomt met 
        /// chipnummer gelijk aan chipnr,
        /// DAN is de returnwaarde dat betreffende huisdier 
        /// ANDERS is de returnwaarde gelijk aan null 
        /// </summary>
        /// <param name="chipnr">het chipnummer</param>
        public Huisdier GetHuisdierMetChipnummer(String chipnr)
        {
            foreach (Huisdier h in huisdier)
            {
                if (h.Chipnummer == chipnr)
                {
                    return h;
                }
            }
            return null;
        }

        /// <summary>
        /// ALS in het dierenasiel al een huisdier voorkomt met 
        /// chipnummer gelijk dat van h, of als het asiel vol is,
        /// DAN is de returnwaarde false (en h is niet toegevoegd) 
        /// ANDERS is de returnwaarde true en is h toegevoegd 
        /// </summary>
        /// <param name="h">het toe te voegen huisdier</param>
        public bool VoegHuisdierToe(Huisdier h)
        {
            if (GetHuisdierMetChipnummer(h.Chipnummer) == null)
            {
                huisdier.Add(h);
                return true;
            }
            return false;
        }

        /// <summary>
        /// ALS in het dierenasiel een huisdier voorkomt met 
        /// chipnummer gelijk aan chipnr,
        /// DAN is de returnwaarde true en is het betreffende 
        /// huisdier verwijderd, 
        /// ANDERS is de returnwaarde false en is niets verwijderd 
        /// </summary>
        /// <param name="h">het te verwijderen huisdier</param>
        public bool VerwijderHuisdier(String chipnr)
        {
            if (GetHuisdierMetChipnummer(chipnr) != null)
            {
                huisdier.Remove(GetHuisdierMetChipnummer(chipnr));
                return true;
            }
            return false;
        }
    }
}
