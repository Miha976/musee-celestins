using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMuseeProject
{
    // Classe TECHNIQUE : UTILISATION DES PREDICATS ET D'UNE MÉTHODE DE COMPARAISON SUR LES CLASSES METIER
    public class Predicats
    {
        // Donnée utilisées par le PREDICAT
        public static string nomArtiste = "";

        // Méthode PREDICAT (pour "Find()", "FindAll()"...)
        // Cette fonction sera appliquée, à tour de rôle, à chaque élement 
        // d'une collection d'OEUVRES pour une SALLE...
        public static bool RechercheOeuvresArtiste(Oeuvre o)
        {
            return o.GetArtiste().GetNomArtiste() == nomArtiste;

        }

        // Méthodes de COMPARAISON (pour "Sort()") entre deux objets OEUVRE ACHETEE
        // Cette méthode doit retourner, suivant le critère de comparaison 
        //      0 si = égalité
        //      1 = si o1 > o2
        //      -1 = si o1 < o2
        public static int ComparerOeuvresParNom(Oeuvre o1, Oeuvre o2)
        {
            int comparaison = -2;
            if (o1 != null && o2 != null)
            {
                if (o1.GetNomOeuvre().Equals(o2.GetNomOeuvre())) comparaison = 0;
                else comparaison = o1.GetNomOeuvre().CompareTo(o2.GetNomOeuvre());
            }
            return comparaison;

        }

        public static int ComparerOeuvresParPrix(Oeuvre o1, Oeuvre o2)
        {
            int comparaison = -2;
            if (o1 != null && o2 != null)
            {
                Oeuvre_Achetee oeuvre1 = new Oeuvre_Achetee(o1);
                Oeuvre_Achetee oeuvre2 = new Oeuvre_Achetee(o2);
                if (oeuvre1.GetPrixOeuvre() == oeuvre2.GetPrixOeuvre()) comparaison = 0;
                else comparaison = oeuvre1.GetPrixOeuvre().CompareTo(oeuvre1.GetPrixOeuvre());
            }
            return comparaison;

        }
    }

}
