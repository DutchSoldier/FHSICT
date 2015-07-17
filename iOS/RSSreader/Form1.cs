using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace RSSReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void toonRssCodeKnop_Click(object sender, EventArgs e)
        {
            
            WebClient client = new WebClient();

            
            MessageBox.Show(client.DownloadString(RSSTextBox.Text));
        }

        private void toonBerichtKnop_Click(object sender, EventArgs e)
        {
            
            WebClient client = new WebClient();
            
            string rssCode = client.DownloadString(RSSTextBox.Text);

                       
            int itemStartPositie = rssCode.IndexOf("<item>");  
            itemStartPositie = itemStartPositie + 6;           
            int itemEindPositie = rssCode.IndexOf("</item>");  
            int itemLengte = itemEindPositie-itemStartPositie; 
            
            
            string itemCode = rssCode.Substring(itemStartPositie, itemLengte);

            
            
            int titleStartPositie = itemCode.IndexOf("<title>");
            titleStartPositie = titleStartPositie + 7;
            int titleEindPositie = itemCode.IndexOf("</title>");
            int titleLengte = titleEindPositie - titleStartPositie;
            titelLabel.Text = itemCode.Substring(titleStartPositie, titleLengte);

            int descriptionStartPositie = itemCode.IndexOf("<description>");
            descriptionStartPositie = descriptionStartPositie + 13;
            int descriptionEindPositie = itemCode.IndexOf("</description>");
            int descriptionLengte = descriptionEindPositie - descriptionStartPositie;
            descriptionLabel.Text = itemCode.Substring(descriptionStartPositie, descriptionLengte);

        
            
         

            Console.WriteLine(itemCode);
        }
    }
}
