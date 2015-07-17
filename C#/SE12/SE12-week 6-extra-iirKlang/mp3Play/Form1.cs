using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IrrKlang;

namespace mp3Play
{
    public partial class Form1 : Form
    {
        private ISoundEngine engine;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"..\..\..\irrKlang-1.3.0\media\ophelia.mp3";


            if (File.Exists(path))
            {
                button1.Enabled = false;
                button2.Enabled = true;
                engine = new ISoundEngine();
                ISound music = engine.Play2D(path, false);
                MessageBox.Show("Lengte fragment (msec): " + music.PlayLength.ToString());
            }
            else
            {
                MessageBox.Show("File does noet exist!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            if (engine != null)
            {
                engine.StopAllSounds();
                engine.Dispose();
                engine = null;
            }
        }
      }
}
