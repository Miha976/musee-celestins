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
    public partial class Form1 : Form
    {
        public Musee musee = Program.musee;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Program.nom_musee;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Nom du musée
            label1.Text = Program.nom_musee;
            label1.Font = new Font("Arial", 23);
            // "Liste des salles" - "Liste des oeuvres" - "Liste des artistes"
            label2.Font = new Font("Arial", 17);
            label3.Font = new Font("Arial", 17);
            label4.Font = new Font("Arial", 17);

            listBox1.Font = new Font("Arial", 13);
            listBox2.Font = new Font("Arial", 13);
            listBox3.Font = new Font("Arial", 13);



            foreach (Salle salle in this.musee.GetLesSalles()) 
                listBox1.Items.Add(salle.GetNomSalle());
            foreach (Oeuvre oeuvre in this.musee.GetLesOeuvres())
                listBox2.Items.Add(oeuvre.GetNomOeuvre());
            foreach (Artiste artiste in this.musee.GetLesArtistes())
                listBox3.Items.Add(artiste.GetNomArtiste());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string salleSelected = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(salleSelected);
            Salle salle = new Salle(musee.GetSalle(index));
            Form2 DetailSalle = new Form2(salle);
            DetailSalle.ShowDialog();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oeuvreSelected = listBox2.SelectedItem.ToString();
            int index = listBox2.FindString(oeuvreSelected);
            Form3 DetailOeuvre = new Form3(Program.musee.GetOeuvre(index));
            DetailOeuvre.ShowDialog();
        }
    }
}
