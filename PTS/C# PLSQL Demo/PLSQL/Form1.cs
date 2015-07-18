using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using Oracle.DataAccess.Types;


namespace PLSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bProcedure_Click(object sender, EventArgs e)
        {
            //Verbinding openen (waarschijnlijk doe je dit in je applicatie niet voor ieder database commando)
            using (OracleConnection objConn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=webdb.hi.fontys.nl)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=cicdb.informatica.local))); User ID=" + mUsername.Text + "; Password=" + tPassword.Text))
            {

                //Nieuw Oracle commando aanmaken
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure; //Instellen dat het om een stored procedure aanroep gaat
                objCmd.CommandText = "Verdubbel";  //Naam van de stored procedure welke we aanroepen
                
                //Mee te geven parameters instellen (richting, type en eventueel een waarde)
                objCmd.Parameters.Add("teVerdubbelen",OracleDbType.Decimal).Value = Convert.ToInt32(nTeVerdubbelenGetal.Value);
                objCmd.Parameters.Add("resultaat", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                
                //Connectie maken en het commando uitvoeren
                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery(); //Voert de stored procedure uit
                    
                    //Tonen van de waarde in de resultaat parameter na uitvoeren van de stored procedure
                    MessageBox.Show("De verdubbelde waarde is: "+objCmd.Parameters["resultaat"].Value); 
                }
                catch (Exception ex)
                {
                    //Voor het geval "iets" mis gaat, de letterlijke foutmelding tonen (doe je natuurlijk niet in een "echte" applicatie)
                    MessageBox.Show("De volgende fout is opgetreden: "+ex.ToString());
                }
                //Verbinding sluiten (waarschijnlijk doe je dit in je applicatie niet per database commando)
                objConn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Verbinding openen (waarschijnlijk doe je dit in je applicatie niet voor ieder database commando)
            using (OracleConnection objConn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=webdb.hi.fontys.nl)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=cicdb.informatica.local))); User ID="+ mUsername.Text+"; Password=" + tPassword.Text))
            {

                //Nieuw Oracle commando aanmaken
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure; //Instellen dat het om een stored procedure aanroep gaat
                objCmd.CommandText = "GetAlleCategorieen"; //Naam van de stored procedure welke we aanroepen

                //Parameters instellen, omdat we alleen meerdere rijen terug krijgen maken we één ref cursor variabele aan.
                OracleParameter categorieCursor = new OracleParameter();
                categorieCursor.OracleDbType = OracleDbType.RefCursor;
                categorieCursor.Direction = ParameterDirection.Output;
                categorieCursor.ParameterName = "categoriecursor";
                objCmd.Parameters.Add(categorieCursor);

                //Connectie maken en het commando uitvoeren
                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery(); //Voert de stored procedure uit
                    
                    //De teruggekregen ref cursor doorgeven aan een Oracle data reader object
                    OracleDataReader r = ((OracleRefCursor)objCmd.Parameters["categoriecursor"].Value).GetDataReader();

                    //Zolang het lukt om een rij uit te lezen de data van de rij in een listview zetten.
                    while (r.Read())
                    {
                        lvCategorieen.Items.Add(new ListViewItem(new string[] { r["naam"].ToString(), r["omschrijving"].ToString() }));
                
                    }

                    //De teksten in de kolommen mooi zichtbaar maken
                    lvCategorieen.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                catch (Exception ex)
                {
                    //Voor het geval "iets" mis gaat, de letterlijke foutmelding tonen (doe je natuurlijk niet in een "echte" applicatie)
                    MessageBox.Show("De volgende fout is opgetreden: " + ex.ToString());
                }
                //Verbinding sluiten (waarschijnlijk doe je dit in je applicatie niet per database commando)
                objConn.Close();

            }
        }
    }
}
