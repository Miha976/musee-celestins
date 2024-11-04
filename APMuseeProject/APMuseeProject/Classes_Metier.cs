using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMuseeProject
{
    #region Classe ARTISTE

    // FAIT
    public class Artiste
    {
        // Attributs 
        private string nomArtiste;
        private string nationalite;

        // Constructeur (+ surcharge)
        public Artiste(string nom, string nat)
        { this.nomArtiste = nom; this.nationalite = nat; }
        public Artiste(Artiste a)
        {
            if (a != null)
            {
                this.nomArtiste = a.nomArtiste;
                this.nationalite = a.nationalite;
            }
        }

        // Accesseurs
        public string GetNomArtiste()
        { return this.nomArtiste; }
        public string GetNationalité()
        { return this.nationalite; }
        public void SetNom(string nom)
        { this.nomArtiste = nom; }
        public void SetNationalité(string nat)
        { this.nationalite = nat; }

        // Retourne une chaine avec nom et nationalité de l’artiste)
        public override string ToString()
        { return string.Format("\t[" + this.nomArtiste + ", nationalité " + this.nationalite + "]\n"); }
    }

    #endregion

    #region Classe ETAT OEUVRE

    // FAIT
    public class Etat_Oeuvre
    {
        // Attributs
        private string libelle;
        private int nbJoursEntreExpertises;

        // Constructeur
        public Etat_Oeuvre(string l, int nb)
        {
            this.libelle = l;
            this.nbJoursEntreExpertises = nb;
        }

        // Accesseurs
        public string getLibelleEtatOeuvre()
        { return this.libelle; }
        public int getNbJoursEntreExpertises()
        { return this.nbJoursEntreExpertises; }
    }

    #endregion

    #region Classe OEUVRE

    // A vérifier & 2 surcharges du constructeur à écrire
    public class Oeuvre
    {
        // Attributs communs
        private string nomOeuvre;
        private Artiste artisteOeuvre;

        // Constructeur (+ surcharges)
        public Oeuvre(string nom)
        {
            this.nomOeuvre = nom;
            this.artisteOeuvre = null;
        }

        public Oeuvre(string nom, Artiste a)
        {
            this.nomOeuvre = nom;
            this.artisteOeuvre = a;
        }

        public Oeuvre(Oeuvre o)
        {
            this.nomOeuvre = o.nomOeuvre;
            this.artisteOeuvre = o.artisteOeuvre;
        }

        // Accesseurs
        public string GetNomOeuvre()
        { return this.nomOeuvre; }

        public void SetNomOeuvre(string nom)
        { this.nomOeuvre = nom; }

        // Accesseurs sur l'attribut 'artisteOeuvre'
        public Artiste GetArtiste()
        { return this.artisteOeuvre; }

        public void SetArtiste(Artiste a)
        {
            if (a != null)
                artisteOeuvre = new Artiste(a);
        }

        // Méthode redéfinie dans les classes derivées
        public virtual string ToString()
        {
            string résultat = "\t[";
            résultat += nomOeuvre;
            résultat += "=> ";
            résultat += artisteOeuvre.GetNomArtiste();
            résultat += ", ";
            résultat += artisteOeuvre.GetNationalité();
            résultat += "]";
            return string.Format(résultat);
        }
    }

    #endregion

    #region Classe OEUVRE ACHETEE

    /* A vérifier & à écrire :
		- Constructeur + surcharges
		- estAExpertiser()
		- ToString()
	*/
    public class Oeuvre_Achetee : Oeuvre
    {
        // Attributs spécifiques
        private float prixOeuvre;
        private DateTime dateAchat;
        private Etat_Oeuvre etat;
        private DateTime dateDerniereExpertise;
        private bool aExpertiser;

        // Constructeur (+surcharges)
        public Oeuvre_Achetee(string nom, float prix, DateTime achat, DateTime expertise, Etat_Oeuvre etat) : base(nom)
        {
            this.prixOeuvre = prix;
            this.dateAchat = achat;
            this.dateDerniereExpertise = expertise;
            this.etat = etat;
            this.aExpertiser = false;
            //...//
        }

        public Oeuvre_Achetee(string nom, float prix, Etat_Oeuvre etat) : base(nom) //  Date achat et Date expertise = Date courante
        {
            this.prixOeuvre = prix;
            this.dateAchat = DateTime.Now;
            this.dateDerniereExpertise = DateTime.Now;
            this.etat = etat;
            this.aExpertiser = false;
            //... //
        }

        public Oeuvre_Achetee(string nom, float prix, DateTime achat, DateTime expertise, Etat_Oeuvre etat, Artiste a) : base(nom, a)
        {
            this.prixOeuvre = prix;
            this.dateAchat = achat;
            this.dateDerniereExpertise = expertise;
            this.etat = etat;
            this.aExpertiser = false;
            //... //
        }

        public Oeuvre_Achetee(Oeuvre o) : base(o)
        {
            this.prixOeuvre = 0;
            //if (o is Oeuvre_Achetee)
            //{
            //    this.prixOeuvre = o.GetPrixOeuvre();
            //}
            this.dateAchat = DateTime.Now;
            this.dateDerniereExpertise = DateTime.Now;
            this.aExpertiser = false;
            //...
        }

        // Accesseurs
        public float GetPrixOeuvre()
        { return this.prixOeuvre; }

        public void SetPrixOeuvre(float prix)
        { this.prixOeuvre = prix; }

        // Méthode permettant de savoir si une oeuvre est à expertiser.
        public bool estAExpertiser()
        {
            if (this.dateAchat.Subtract(this.dateDerniereExpertise).Days > this.etat.getNbJoursEntreExpertises())
            {
                this.aExpertiser = true;
            }
            return this.aExpertiser;
        }

        // Méthode REDEFINIE. Formatage une chaine avec les informations de l'oeuvre
        public override string ToString()
        {
            string aRetourner = "";
            aRetourner += base.ToString();
            aRetourner += string.Format("\n\tAchetée le {0} et expertisée le {1}\n", this.dateAchat.ToShortDateString(), this.dateDerniereExpertise.ToShortDateString());
            aRetourner += string.Format("\tEtat {0}\n", this.etat.getLibelleEtatOeuvre());
            aRetourner += string.Format("\tEcart {0}\n", this.dateAchat.Subtract(this.dateDerniereExpertise).Days);
            aRetourner += string.Format("\tPour {0} euros\n", this.prixOeuvre);
            if (this.estAExpertiser()) aRetourner += "\t\t---> Doit être expertisée\n\n";

            // ...

            return aRetourner;
        }
    }
    #endregion

    #region Classe OEUVRE PRETEE

    /* A vérifier & à écrire :
         - Constructeur + surcharges
         - setDates()
         - ToString()
     */
    public class Oeuvre_Pretee : Oeuvre
    {
        // Attribut spécifique
        private string preteur;
        private DateTime date_debut;
        private DateTime date_fin;

        // Constructeur (+surcharges)
        // Pour la dernière surcharge : 
        //  * Les dates seront initialisées à la date courante
        //  * Le prêteur sera initialisé à "inconnu"
        public Oeuvre_Pretee(string nom, string preteur, DateTime debut, DateTime fin) : base(nom)
        {
            this.preteur = preteur;
            this.date_debut = debut;
            this.date_fin = fin;
            // ...
        }

        public Oeuvre_Pretee(string nom, string preteur, DateTime debut, DateTime fin, Artiste a) : base(nom, a)
        {
            this.preteur = preteur;
            this.date_debut = debut;
            this.date_fin = fin;
            // ...
        }

        public Oeuvre_Pretee(Oeuvre o) : base(o)
        {
            this.date_debut = DateTime.Now;
            this.date_fin = DateTime.Now;
            this.preteur = null;
            // ...
        }

        // Accesseurs
        // Remarque : getDates retourne un TABLEAU avec les deux dates (début et fin)
        // et setDates reçoit en paramètre un tableau analogue.
        public string getPreteur()
        { return this.preteur; }

        public DateTime[] getDates()
        { return new DateTime[] { this.date_debut, this.date_fin }; }

        public void setPreteur(string p)
        { this.preteur = p; }

        public void setDates(DateTime[] dates)
        {
            if(dates.Length == 2)
            {
                this.date_debut = dates[0];
                this.date_fin = dates[1];
            }
            // ...
        }

        // Méthode REDEFINIE. Formatage une chaine avec les informations de l'oeuvre
        public override string ToString()
        {
            string aRetourner = "";
            aRetourner += base.ToString();
            aRetourner += string.Format("\n\tPrêtée par {0} pour {1} jours\n\n", this.preteur, (this.date_fin - this.date_debut).Days);
            return aRetourner;
        }
    }
    #endregion

    #region Classe SALLE

    /* A vérifier & à écrire :
		- Constructeur + surcharges
		- GetOeuvre()
		- ExisteOeuvre() + surcharge
		
		- 4 Indexeurs :
			Sur le rang de l'OEUVRE dans la collection
			Sur le prix (retourne toutes les oeuvres dont le prix est <= à celui cherché)
			Sur la référence (objet) artiste(retourne toutes les oeuvres de l'artiste cherché)
			Sur le nom d'un artiste (retourne toutes les oeuvres de l'artiste cherché)
		
		- AjouteOeuvre()
		- RetireOeuvre()
		- ValeurSalle()
		- Ecart()
		- getLesOeuvresAExpertiser()
		- ToString()
	*/
    public class Salle
    {
        // Attributs
        private string nomSalle;
        private float montantAssurance;
        private List<Oeuvre> lesOeuvres;

        // Constructeur (+ surcharges)
        public Salle(string nomSalle, float montant)
        {
            this.nomSalle = nomSalle;
            this.montantAssurance = montant;
            this.lesOeuvres = new List<Oeuvre>();
            // ...
        }

        public Salle(Salle s)
        {
            this.nomSalle = s.nomSalle;
            this.montantAssurance = s.montantAssurance;
            this.lesOeuvres = s.lesOeuvres;
            // ...
        }

        public Salle(string nomSalle, float montant, List<Oeuvre> l)
        {
            this.nomSalle = nomSalle;
            this.montantAssurance = montant;
            this.lesOeuvres = l;
            // ...
        }

        // Accesseurs sur le nom de la salle et le montant de l'assureance
        public string GetNomSalle()
        { return this.nomSalle; }

        public float GetMontantAssurance()
        { return this.montantAssurance; }

        public void SetNomSalle(string nom)
        { this.nomSalle = nom; }

        public void SetMontantAssurance(float mtt)
        { this.montantAssurance = mtt; }

        // Retourne le nombre d'oeuvres
        public int GetNbOeuvres()
        { return this.lesOeuvres.Count; }

        // Retourne l’oeuvre dont le nom est passé en paramètre ou "null" sinon trouvée.
        public Oeuvre GetOeuvre(string nom)
        {
            foreach(Oeuvre o in this.lesOeuvres)
                if (o.GetNomOeuvre() == nom) return o;
            return null;
        }

        // Retourne vrai si l'Oeuvre dont le nom est passé en paramètre existe dans la salle, faux sinon.
        // (+ surcharge)
        public bool ExisteOeuvre(string nom)
        {
            // ...
            foreach (Oeuvre o in this.lesOeuvres)
                if (o.GetNomOeuvre() == nom) return true;
            return false;
        }

        public bool ExisteOeuvre(Oeuvre uneOeuvre)
        {
            // ...
            foreach (Oeuvre o in this.lesOeuvres)
                if (o.Equals(uneOeuvre)) return true;
            return false;
        }

        #region INDEXEURS

        // Fournissent l'accès à(aux) oeuvre(s) de la salle)
        // * Sur le rang de l'OEUVRE dans la COLLECTION
        // * Sur le prix (retourne toutes les oeuvres dont le prix est <= à celui cherché)
        // * Sur la référence (objet) artiste(retourne toutes les oeuvres de l'artiste cherché)
        // * Sur le nom d'un artiste (retourne toutes les oeuvres de l'artiste cherché)

        // A ECRIRE (4 indexeurs)
        // ...
        public Oeuvre this[int i]
        {
            get
            {
                return i < this.GetNbOeuvres() ? this.lesOeuvres[i] : null;
            }

        }
        public List<Oeuvre> this[float prix]
        {
            get
            {
                List<Oeuvre_Achetee> oeuvres = new List<Oeuvre_Achetee>();
                foreach(Oeuvre oeuvre in this.lesOeuvres)
                {
                    if(oeuvre is Oeuvre_Achetee)
                    {
                        oeuvres.Add((Oeuvre_Achetee)oeuvre);
                    }
                }
                foreach (Oeuvre_Achetee o in oeuvres)
                {
                    if (o.GetPrixOeuvre() > prix)
                    {
                        oeuvres.Remove(o);
                    }
                } 
                return new List<Oeuvre>(oeuvres);
            }

        }

        public List<Oeuvre> this[Artiste artiste]
        {
            get
            {
                List<Oeuvre> oeuvres = new List<Oeuvre>();
                foreach (Oeuvre oeuvre in this.lesOeuvres)
                {
                    if (oeuvre.GetArtiste().Equals(artiste))
                    {
                        oeuvres.Add(oeuvre);
                    }
                }
                return oeuvres;
            }

        }

        public List<Oeuvre> this[string nomArtiste]
        {
            get
            {
                List<Oeuvre> oeuvres = new List<Oeuvre>();
                foreach (Oeuvre oeuvre in this.lesOeuvres)
                {
                    if (oeuvre.GetArtiste().GetNomArtiste() == nomArtiste)
                    {
                        oeuvres.Add(oeuvre);
                    }
                }
                return oeuvres;
            }

        }
        #endregion

        // Ajoute une Oeuvre dans la salle, 
        // Retourne vrai si l’ajout a eu lieu, faux si l'œuvre existe déjà.
        public bool AjouteOeuvre(Oeuvre uneOeuvre)
        {
            // ...
            if (!this.lesOeuvres.Contains(uneOeuvre)) {
                this.lesOeuvres.Add(uneOeuvre);
                return true;
            }
            return false;
        }

        // Enlève une Oeuvre dans la salle.
        // Retourne vrai si le retrait a eu lieu, faux si l'œuvre n'existe pas.
        public bool RetireOeuvre(Oeuvre uneOeuvre)
        {
            if (this.lesOeuvres.Contains(uneOeuvre))
            {
                this.lesOeuvres.Remove(uneOeuvre);
                return true;
            }
            return false;
        }

        // Retourne la valeur totale des oeuvres stockées dans la salle
        public double ValeurSalle()
        {
            double total = 0;
            if(this.lesOeuvres.Count > 0)
                foreach (Oeuvre oeuvre in this.lesOeuvres)
                    if (oeuvre is Oeuvre_Achetee) total += ((Oeuvre_Achetee)oeuvre).GetPrixOeuvre();
            return total;
        }

        // Retourne l’écart entre le montant de la valeur déclarée 
        // à l’assurance et la valeur des Oeuvres.
        // Lorsque la valeur de la salle est égale à ZERO
        // (=que des oeuvres prêtées) alors on retourne ZERO.
        public double Ecart()
        {
            return this.ValeurSalle() == 0 ? 0 : this.montantAssurance - this.ValeurSalle();
        }

        // Retourne l'ensemble des oeuvres devant faire l'objet d'une expertise
        public List<Oeuvre_Achetee> getLesOeuvresAExpertiser()
        {
            List<Oeuvre_Achetee> LesOeuvresAExpertiser = new List<Oeuvre_Achetee>();
            foreach(Oeuvre oeuvre in this.lesOeuvres)
                if(oeuvre is Oeuvre_Achetee)
                    if (((Oeuvre_Achetee)oeuvre).estAExpertiser()) 
                        LesOeuvresAExpertiser.Add((Oeuvre_Achetee)oeuvre);
            return LesOeuvresAExpertiser;
        }

        // Retourne une chaîne avec les caractéristiques de la salle 
        // (nom et montant de l’assurance) et des œuvres avec artiste.
        public override string ToString()
        {
            string résultat = "";
            résultat += $"SALLE : {this.nomSalle}. Montant d'assurance : {this.montantAssurance}\n";
            résultat += $"Il y a {this.GetNbOeuvres()} oeuvre(s)\n\n";
            foreach(Oeuvre o in this.lesOeuvres) résultat += o.ToString();
            résultat += $"\n\n\n Valeur : {this.ValeurSalle()} euros. Ecart : {this.Ecart()} euros";
            return résultat;
        }
    }

    #endregion

    #region Classe MUSEE

    /* A vérifier & à écrire :
		- Constructeur 
		- CreerSalle()
		- CreerArtiste()
		- CreerOeuvre() + surcharge
		- GetArtiste(), GetOeuvre(), GetSalle()
		- getLesExpertisesAFAire()
		- ToString()
	*/
    public class Musee
    {
        // Attributs
        private string monMusee;                // Nom du musée
        private List<Artiste> lesArtistes;      // Liste des artistes
        private List<Salle> lesSalles;          // Liste des salles
        private List<Oeuvre> lesOeuvres;        // Liste des oeuvres;

        // Constructeur : création d'un musée
        public Musee(string nom)
        {
            this.monMusee = nom == "" ? null : nom;
            this.lesArtistes = new List<Artiste>();
            this.lesSalles = new List<Salle>();
            this.lesOeuvres = new List<Oeuvre>();
        }

        // Création d'une SALLE
        public string CreerSalle(Salle s)
        {
            string aRetourner = $"La salle '{s.GetNomSalle()}'";
            if(!this.lesSalles.Contains(s))
            {
                this.lesSalles.Add(s);
                aRetourner += " a été crée";
            } else aRetourner += " n'a pas été crée";
            return aRetourner;
        }

        // Création d'un ARTISTE
        public string CreerArtiste(Artiste a)
        {
            string aRetourner = $"L'artiste '{a.GetNomArtiste()}'";
            if (!this.lesArtistes.Contains(a))
            {
                this.lesArtistes.Add(a);
                aRetourner += " a été ajoutée à la salle";
            }
            else aRetourner += " n'a pas été ajouté à la salle";
            return aRetourner;
        }

        // Création d'une OEUVRE avec un ARTISTE et une SALLE
        // (+ surcharge : OEUVRE avec l'ARTISTE déjà défini)
        public string CreerOeuvre(Oeuvre o, Artiste a, Salle s)
        {
            string aRetourner = $"L'oeuvre '{a.GetNomArtiste()}'";
            o.SetArtiste(a);
            if (!this.lesOeuvres.Contains(o))
            {
                this.lesOeuvres.Add(o);
                s.AjouteOeuvre(o);
                aRetourner += " a été ajoutée à la salle";
            }
            else aRetourner += " n'a pas été ajoutée à la salle";
            this.CreerArtiste(a);
            this.CreerSalle(s);
            return aRetourner;
        }

        public string CreerOeuvre(Oeuvre o, Salle s)
        {
            string aRetourner = $"L'oeuvre '{o.GetNomOeuvre()}'";
            if (!this.lesOeuvres.Contains(o))
            {
                this.lesOeuvres.Add(o);
                s.AjouteOeuvre(o);
                aRetourner += " a été ajoutée à la salle";
            } else aRetourner += " n'a pas été ajoutée à la salle";
            this.CreerSalle(s);
            return aRetourner;
        }

        // Accesseurs
        public List<Oeuvre> GetLesOeuvres()
        { return this.lesOeuvres; }

        public List<Salle> GetLesSalles()
        { return this.lesSalles; }

        public List<Artiste> GetLesArtistes()
        { return this.lesArtistes; }

        public Artiste GetArtiste(int i)
        {
            return this.lesArtistes[i];
        }

        public Oeuvre GetOeuvre(int i)
        {
            return this.lesOeuvres[i];
        }

        public Salle GetSalle(int i)
        {
            return this.lesSalles[i];
        }

        // Retourne une collection DICTIONNAIRE avec la liste des OEUVRES
        // devant faire l'objet d'une expertise.
        // Chaque élément est de la forme :
        //  * Clé : objet SALLE
        //  * Valeur associée : collection d'oeuvres à expertiser
        public Dictionary<Salle, List<Oeuvre_Achetee>> getLesExpertisesAFAire()
        {
            Dictionary<Salle, List<Oeuvre_Achetee>> dict = new Dictionary<Salle, List<Oeuvre_Achetee>>();
            foreach(Salle s in this.lesSalles)
                dict.Add(s, s.getLesOeuvresAExpertiser());
            return dict;
        }

        // Formatte une chaîne avec les données du MUSEE
        public override string ToString()
        {
            string résultat = string.Format("\n***********************************\n");
            résultat += string.Format(" {0} \n", monMusee);
            résultat += string.Format("***********************************");

            // A COMPLETER :

            résultat += "\n";
            // Liste des ARTISTES
            résultat += "\n--- Liste des ARTISTES\n\n";
            foreach(Artiste artiste in this.GetLesArtistes()) résultat += artiste;

            // Liste des OEUVRES
            résultat += "\n--- Liste des OEUVRES\n\n";
            foreach (Oeuvre oeuvre in this.GetLesOeuvres())
            {
                résultat += oeuvre.ToString();
            } 
                

            // Liste et détail des SALLES
            résultat += "\n--- Liste des SALLES\n\n";
            foreach (Salle salle in this.GetLesSalles()) résultat += salle;

            return résultat;
        }
    }
    #endregion
}
