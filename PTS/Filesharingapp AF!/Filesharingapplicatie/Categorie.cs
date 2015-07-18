using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filesharingapplicatie
{
    public class Categorie : TreeNode
    {
        //Datavelden
        private int map_id;
        private string naam;
        private int parent_id;
        //

        //Properties
        public int Map_id
        {
            get
            {
                return map_id;
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }
        }

        public int Parent_id
        {
            get
            {
                return parent_id;
            }
        }
        //

        //Constructor
        public Categorie(int map_id, string naam, int parent_id)
        {
            this.map_id = map_id;
            this.naam = naam;
            this.parent_id = parent_id;
            this.Text = naam;
        }
        //
    }
}
