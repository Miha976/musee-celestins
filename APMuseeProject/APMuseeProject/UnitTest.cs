using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APMuseeProject
{
    [TestClass]
    class UnitTest
    {
        [TestMethod]
        public void test()
        {
            string nom = "Musee des Celestins - VICHY";
            Musee celestins = new Musee(nom);

            // -- Ajouter des ARTISTES
            Artiste monet = new Artiste("Monet", "Francaise");
            Artiste manet = new Artiste("Manet", "Francaise");
            Artiste vangogh = new Artiste("Van Gogh", "Neelandaise");
            celestins.CreerArtiste(monet);
            celestins.CreerArtiste(manet);
            celestins.CreerArtiste(vangogh);

            // -- Ajouter des SALLES
            Salle francaise = new Salle("Francaise", 2000000);
            Salle neerlandaise = new Salle("Neerlandaise", 2000000);
            celestins.CreerSalle(francaise);
            celestins.CreerSalle(neerlandaise);

            // -- Ajouter des ETATS des OEUVRES
            Etat_Oeuvre bon = new Etat_Oeuvre("Bon", 365);
            Etat_Oeuvre moyen = new Etat_Oeuvre("Moyen", 180);
            Etat_Oeuvre mauvais = new Etat_Oeuvre("Mauvais", 30);

            // -- Ajouter des OEUVRES

            // MONET
            Oeuvre o1 = new Oeuvre_Achetee("Le Déjeuner sur l'herbe", 500000, new DateTime(2021, 09, 15), new DateTime(2021, 07, 15), moyen, monet);
            Oeuvre o2 = new Oeuvre_Achetee("Au bord de l'eau", 350000, new DateTime(2021, 09, 15), new DateTime(2021, 05, 15), bon);
            Oeuvre o3 = new Oeuvre_Achetee("La Plage à Honfleur", 90000, new DateTime(2021, 09, 15), new DateTime(2021, 07, 1), mauvais, monet); // A expertiser
            Oeuvre o4 = new Oeuvre_Achetee("Quai du Louvre", 110000, new DateTime(2021, 09, 15), new DateTime(2021, 07, 15), mauvais, monet); // A expertiser

            // MANET
            Oeuvre o5 = new Oeuvre_Pretee("La Partie de croquet", "Museé d'Orsay", new DateTime(2021, 05, 03), new DateTime(2022, 01, 15));
            Oeuvre o6 = new Oeuvre_Pretee("Le Joueur de fifre", "Musée du Prado", new DateTime(2021, 08, 01), new DateTime(2022, 12, 31));
            Oeuvre o7 = new Oeuvre_Achetee("Le petit Lange", 110000, new DateTime(2021, 09, 15), new DateTime(2021, 08, 25), mauvais, manet);
            Oeuvre o8 = new Oeuvre_Achetee("L'Exécution de Maximilien", 250000, new DateTime(2021, 09, 15), new DateTime(2021, 08, 1), mauvais, manet); // A expertiser
            Oeuvre o9 = new Oeuvre_Achetee("Portrait d'Émile Zola", 95000, new DateTime(2021, 09, 15), new DateTime(2021, 06, 15), moyen, manet);

            // VAN GOGH
            Oeuvre o10 = new Oeuvre_Achetee("Tournesols dans un vase", 750000, new DateTime(2021, 09, 15), new DateTime(2021, 07, 15), mauvais); // A expertiser
            Oeuvre o11 = new Oeuvre_Pretee("Champ de ble avec cypres", "Metropolitan Museum", new DateTime(2020, 10, 24), new DateTime(2021, 10, 24));
            Oeuvre o12 = new Oeuvre_Achetee("Autoportrait", 1000000, new DateTime(2021, 09, 15), new DateTime(2021, 08, 30), mauvais);
            Oeuvre o13 = new Oeuvre_Achetee("Le Champ de blé aux iris", 95000, new DateTime(2021, 09, 15), new DateTime(2021, 07, 15), moyen);

            // SALLE FRANCAISE - MONET
            celestins.CreerOeuvre(o1, celestins.GetSalle(0));
            celestins.CreerOeuvre(o2, monet, celestins.GetSalle(0));
            celestins.CreerOeuvre(o3, celestins.GetSalle(0));
            celestins.CreerOeuvre(o4, celestins.GetSalle(0));

            // SALLE FRANCAISE - MANET
            celestins.CreerOeuvre(o5, manet, celestins.GetSalle(0));
            celestins.CreerOeuvre(o6, manet, celestins.GetSalle(0));
            celestins.CreerOeuvre(o7, celestins.GetSalle(0));
            celestins.CreerOeuvre(o8, celestins.GetSalle(0));
            celestins.CreerOeuvre(o9, celestins.GetSalle(0));

            // SALLE NEERLANDAISE - VAN GOGH
            celestins.CreerOeuvre(o10, vangogh, celestins.GetSalle(1));
            celestins.CreerOeuvre(o11, vangogh, celestins.GetSalle(1));
            celestins.CreerOeuvre(o12, vangogh, celestins.GetSalle(1));
            celestins.CreerOeuvre(o13, vangogh, celestins.GetSalle(1));
        }
    }
}
