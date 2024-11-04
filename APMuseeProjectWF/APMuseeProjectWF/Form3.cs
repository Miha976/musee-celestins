using APMuseeProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APMuseeProjectWF
{
    public partial class Form3 : Form
    {
        public Oeuvre oeuvre;
        public Form3(Oeuvre oeuvre)
        {
            InitializeComponent();
            this.oeuvre = oeuvre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Oeuvre - " + this.oeuvre.GetNomOeuvre();
            string text = this.oeuvre.ToString();
            //if(this.oeuvre is Oeuvre_Pretee)
            //{
            //    text += "Prêtée par " + ((Oeuvre_Pretee)this.oeuvre).getPreteur() + "\n";
            //    text += "Dates de prêt : "+
            //        ((Oeuvre_Pretee)this.oeuvre).getDates()[0].ToShortDateString() + 
            //        " - " +
            //        ((Oeuvre_Pretee)this.oeuvre).getDates()[1].ToShortDateString() + " soit " + 
            //        ((Oeuvre_Pretee)this.oeuvre).getDates()[1]
            //        .Subtract(((Oeuvre_Pretee)this.oeuvre).getDates()[0]).TotalDays + " jours";
            //} else
            //{
            //    text += "Prix : " + ((Oeuvre_Achetee)this.oeuvre).GetPrixOeuvre() + "\n";
            //}
            label4.Text = text;
            label4.Font = new Font("Arial", 16);
        }
    }
}
