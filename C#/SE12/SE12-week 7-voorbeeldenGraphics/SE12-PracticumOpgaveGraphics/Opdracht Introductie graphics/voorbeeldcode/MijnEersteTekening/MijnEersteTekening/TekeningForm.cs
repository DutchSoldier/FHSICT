using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MijnEersteTekening
{
    public partial class TekeningForm : Form
    {
        public TekeningForm() {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e) {
            // Vraag het Graphics object op, dat bij dit form hoort.
            // Met dit graphics object kunnen we op het form tekenen.
            Graphics graphics = CreateGraphics();

            // Na het opvragen van het Graphics object kunnen we gaan tekenen.

            int breedte = 100;
            int hoogte = 50;

            // Teken een rechthoek op coordinaat (10, 10)
            // en een gevulde rechthoek op coordinaat (10, 70).
            graphics.DrawRectangle(Pens.Black, 10, 10, breedte, hoogte);
            graphics.FillRectangle(Brushes.Blue, 10, 70, breedte, hoogte);

            // Doen!: Probeer dit programma uit.
            //        Wat gebeurt er als je na het zien van de tekening 
            //        het form minimized en maximized? 
            //        En wat gebeurt er als je een ander venster over de applicatie beweegt? 
            //        Wat gebeurt er met de tekening?  
            // 
            //        Let goed op de coordinaten! Kun je op je scherm aanwijzen 
            //        waar het coordinaat (0, 0) ligt?
        }
    }
}
