// -----------------------------------------------------------------------
// <copyright file="Filestream.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Diertjes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Diagnostics;
    using System.Windows.Forms;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class BestandStroom
    {
        public static string GetFilePath()
        {
            string filePath = string.Empty;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            filePath = appPath + "/dieren.txt";
            return filePath;
        }

        public static List<string> GetDierNamen()
        {
            List<string> namen = new List<string>();
            int counter = 0;
            string line;

            System.IO.StreamReader file = new StreamReader(GetFilePath());
            while ((line = file.ReadLine()) != null)
            {
                namen.Add(line);
                counter++;
            }
            file.Close();

            return namen;
        }

        public static void SaveDierNamen(string naam)
        {
            System.IO.StreamWriter file = new StreamWriter(GetFilePath(), true);
            file.WriteLine(naam);
            file.Close();
        }
    }
}
