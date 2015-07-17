using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TekenenOpCommando
{
    public partial class TekeningForm : Form
    {
        private bool laatTekeningZien;  // Als true, laat tekening zien, anders tekening niet laten zien.

        public TekeningForm() {
            InitializeComponent();
            laatTekeningZien = false;   // Zorgen voor de juiste initialisatie: 
                                        // Initieel geen tekening op het Form.
        }

        private void TekeningForm_Paint(object sender, PaintEventArgs e) {
            if (laatTekeningZien) {    // Tekenen als laatTekeningZien == true

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
            }
        }

        private void drawButton_Click(object sender, EventArgs e) {
            laatTekeningZien = true; // Ervoor zorgen dat er getekend kan worden.

            // Het aanroepen van Refresh() zorgt ervoor ervoor dat het Form
            // als 'beschadigd' wordt gemarkeerd. Hierdoor wordt zijn paint event 
            // automagisch afgevuurd.
            // Gebruik van de Refresh() methode forceert dus het opnieuw tekenen 
            // van het form dmv het Paint event.
            Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e) {
            laatTekeningZien = false; // Ervoor zorgen dat er niet getekend kan worden.

            // Het aanroepen van Refresh() zorgt ervoor ervoor dat het Form
            // als 'beschadigd' wordt gemarkeerd. Hierdoor wordt zijn paint event 
            // automagisch afgevuurd.
            // Gebruik van de Refresh() methode forceert dus het opnieuw tekenen 
            // van het form dmv het Paint event.
            Refresh();
        }
        // Probeer dit programma uit.
    }
}
