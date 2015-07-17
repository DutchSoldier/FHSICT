using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TekenenMetHetPaintEvent
{
    public partial class TekeningForm : Form
    {
        public TekeningForm() {
            InitializeComponent();
        }

        private void TekeningForm_Paint(object sender, PaintEventArgs e) {
            // Vraag het Graphics object op van de control, die dit Paint event
            // heeft verzonden. Met het graphics object kunnen we tekenen op dit control.
            // Definitie 'control': Een control is een User Interface object.
            // Voorbeelden van controls: TextBox, PictureBox, Button, Label, Form, Panel, etc
            Graphics graphics = e.Graphics;

            // Na het opvragen van het Graphics object kunnen we gaan tekenen.

            int breedte = 100;
            int hoogte = 50;

            // Teken een rechthoek op coordinaat (10, 10)
            // en een gevulde rechthoek op coordinaat (10, 70).
            graphics.DrawRectangle(Pens.Black, 10, 10, breedte, hoogte);
            graphics.FillRectangle(Brushes.Blue, 10, 70, breedte, hoogte);

            // Probeer dit programma uit.
            // Wat gebeurt er als je na het zien van de tekening 
            // het form minimized en maximized? 
            // En wat gebeurt er als je een ander venster over de applicatie beweegt? 
            // Welk verschil zie je methet programma van het 'MijnEersteTekening' project?  
        }
    }
}
