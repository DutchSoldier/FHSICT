using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using System.Diagnostics;



namespace ToegangsSysteem
{
        enum Appstate
        {
            Addtags, 
            Checkin,
            Default
        }
    public partial class Form1 : Form
    {
        private Appstate state;
        private RFID rfid;
        private DatabaseKoppeling DataKoppeling;
        private string rfidID;

        public Form1()
        {
            InitializeComponent();
            DataKoppeling = new DatabaseKoppeling();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rfid = new RFID();

            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Detach += new DetachEventHandler(rfid_Detach);

            rfid.Tag += new TagEventHandler(rfid_Tag);
            rfid.TagLost += new TagEventHandler(rfid_TagLost);

            openCmdLine(rfid);
        }

        void rfid_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;

            if (rfid.outputs.Count > 0)
            {
                rfid.Antenna = true;
            }
        }

        void rfid_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;
        }

        void rfid_Tag(object sender, TagEventArgs e)
        {
            rfidID = e.Tag;
            if (state == Appstate.Checkin)
            {
                lRfidNumber.Text = e.Tag;

                Debug.WriteLine("tag: " + e.Tag);

                DataKoppeling.CheckPresence(rfidID);
                DataKoppeling.ConfirmCheckIn(rfidID);
                Debug.WriteLine("accepted: " + DataKoppeling.accepted);
                string presence = DataKoppeling.presence;
                Debug.WriteLine("presence: " + presence);

                if (presence == "0" && DataKoppeling.accepted == true)
                {
                    lName.Text = DataKoppeling.name;
                    DataKoppeling.CheckIn(rfidID);
                    lCheck.Text = "Checked in";
                    pbAllowed.Visible = true;
                }
                if (presence == "1")
                {
                    lName.Text = DataKoppeling.name;
                    pbAllowed.Visible = true;
                    lCheck.Text = "Checked out";
                    DataKoppeling.CheckOut(rfidID);
                }
                if (DataKoppeling.accepted == false)
                {
                    DataKoppeling.DenyReason(rfidID);
                    lName.Text = DataKoppeling.name;
                    pbDenied.Visible = true;
                    lReason.Visible = true;
                    lDenyReason.Text = DataKoppeling.reason;
                    lDenied.Visible = true;
                }
            }
            else if (state == Appstate.Addtags)
            {
                rfidID = e.Tag;
                DataKoppeling.CheckTags(rfidID);
                if (DataKoppeling.tag == true)
                {
                    DataKoppeling.AddTags(rfidID);
                    pbAllowed.Visible = true;
                    lRfidNumber.Visible = true;
                    lRfidNumber.Text = e.Tag;
                    Debug.WriteLine(e.Tag);
                }
            }
        }

        void rfid_TagLost(object sender, TagEventArgs e)
        {

                lCheck.Text = "";
                lRfidNumber.Text = "";
                lName.Text = "";
                lDenyReason.Text = "";
                lReason.Visible = false;
                lDenied.Visible = false;
                pbAllowed.Visible = false;
                pbDenied.Visible = false;
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rfid.Attach -= new AttachEventHandler(rfid_Attach);
            rfid.Detach -= new DetachEventHandler(rfid_Detach);
            rfid.Tag -= new TagEventHandler(rfid_Tag);
            rfid.TagLost -= new TagEventHandler(rfid_TagLost);

            Application.DoEvents();

            rfid.close();
        }

        #region Command line open functions
        private void openCmdLine(Phidget p)
        {
            openCmdLine(p, null);
        }
        private void openCmdLine(Phidget p, String pass)
        {
            int serial = -1;
            int port = 5001;
            String host = null;
            bool remote = false, remoteIP = false;
            string[] args = Environment.GetCommandLineArgs();
            String appName = args[0];

            try
            { //Parse the flags
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "n":
                                serial = int.Parse(args[++i]);
                                break;
                            case "r":
                                remote = true;
                                break;
                            case "s":
                                remote = true;
                                host = args[++i];
                                break;
                            case "p":
                                pass = args[++i];
                                break;
                            case "i":
                                remoteIP = true;
                                host = args[++i];
                                if (host.Contains(":"))
                                {
                                    port = int.Parse(host.Split(':')[1]);
                                    host = host.Split(':')[0];
                                }
                                break;
                            default:
                                goto usage;
                        }
                    else
                        goto usage;
                }

                if (remoteIP)
                    p.open(serial, host, port, pass);
                else if (remote)
                    p.open(serial, host, pass);
                else
                    p.open(serial);
                return; //success
            }
            catch { }
        usage:
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            sb.AppendLine("Usage: " + appName + " [Flags...]");
            sb.AppendLine("Flags:\t-n   serialNumber\tSerial Number, omit for any serial");
            sb.AppendLine("\t-r\t\tOpen remotely");
            sb.AppendLine("\t-s   serverID\tServer ID, omit for any server");
            sb.AppendLine("\t-i   ipAddress:port\tIp Address and Port. Port is optional, defaults to 5001");
            sb.AppendLine("\t-p   password\tPassword, omit for no password" + Environment.NewLine);
            sb.AppendLine("Examples: ");
            sb.AppendLine(appName + " -n 50098");
            sb.AppendLine(appName + " -r");
            sb.AppendLine(appName + " -s myphidgetserver");
            sb.AppendLine(appName + " -n 45670 -i 127.0.0.1:5001 -p paswrd");
            MessageBox.Show(sb.ToString(), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }
        #endregion

        private void bDeny_Click(object sender, EventArgs e)
        {
            tbDeny.Enabled = true;
            bConfirmDeny.Visible = true;
        }
        


        private void bAllow_Click(object sender, EventArgs e)
        {
            bConfirmAllow.Visible = true;
        }

        private void bConfirmAllow_Click(object sender, EventArgs e)
        {
            DataKoppeling.AllowAccess(rfidID);
            DataKoppeling.CheckIn(rfidID);
            MessageBox.Show("Person is allowed to the event from now on.");
            bConfirmAllow.Visible = false;
        }

        private void bConfirmDeny_Click(object sender, EventArgs e)
        {
            string reason = tbDeny.Text;
            DataKoppeling.CheckPresence(rfidID);
            if (DataKoppeling.presence == "1")
            {
                DataKoppeling.CheckOut(rfidID);
                DataKoppeling.DenyAccess(rfidID, reason);
            }
            if (DataKoppeling.presence == "0")
            {
                DataKoppeling.DenyAccess(rfidID, reason);
            }
            MessageBox.Show("Person is denied from the event from now on.");
            tbDeny.Text = "";
            bConfirmDeny.Visible = false;
            tbDeny.Enabled = false;
        }

        private void bAddTags_Click(object sender, EventArgs e)
        {
            state = Appstate.Addtags;
            bBack.Visible = true;
            bAddTags.Visible = false;
            bCheckin.Visible = false;
            lRFID.Visible = true;
        }

        private void bCheckin_Click(object sender, EventArgs e)
        {
            state = Appstate.Checkin;
            bBack.Visible = true;
            bAddTags.Visible = false;
            bCheckin.Visible = false;
            lRFID.Visible = true;
            labelName.Visible = true;
            bDeny.Visible = true;
            bAllow.Visible = true;
            tbDeny.Visible = true;
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            state = Appstate.Default;
            bAddTags.Visible = true;
            bCheckin.Visible = true;
            lReason.Visible = false;
            lRFID.Visible = false;
            lRfidNumber.Visible = false;
            labelName.Visible = false;
            pbAllowed.Visible = false;
            pbDenied.Visible = false;
            bAllow.Visible = false;
            bDeny.Visible = false;
            tbDeny.Visible = false;
            bBack.Visible = false;
        }

    }

}