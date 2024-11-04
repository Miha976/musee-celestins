using APMuseeProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APMuseeProjectWF
{
    public partial class Form2 : Form
    {
        protected Salle salle;
        protected List<Oeuvre> oeuvres;
        public Form2(Salle salle)
        {
            InitializeComponent();
            this.salle = salle;
            this.oeuvres =  new List<Oeuvre>();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Form1 form1 = new Form1();
            label1.Text = $"Salle - {this.salle.GetNomSalle()}";
            label1.Font = new Font("Arial", 17);
            label2.Text = "Ecart : " + Convert.ToString(salle.Ecart());
            foreach(Oeuvre oeuvre1 in form1.musee.GetLesOeuvres())
            {
                if(oeuvre1 != null && salle.ExisteOeuvre(oeuvre1))
                    oeuvres.Add(oeuvre1);
            }
            foreach(Oeuvre oeuvre in this.oeuvres)
                listBox1.Items.Add(oeuvre.GetNomOeuvre());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oeuvreSelected = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(oeuvreSelected);
            Form3 DetailOeuvre = new Form3(Program.musee.GetOeuvre(index));
            DetailOeuvre.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
