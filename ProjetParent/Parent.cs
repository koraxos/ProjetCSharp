using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetParent
{
    public class Parent
    {

        String nom, prenom;
        String motdepasse;

        public Parent()
        {
            this.nom = "";
            this.prenom = "";
            this.motdepasse = "";
        }
        public Parent(String nom, String prenom, String motdepasse)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.motdepasse = motdepasse;
        }

        public String Nom {  get { return nom; } set { nom = value; } }
        public String Prenom { get { return prenom; } set { prenom = value; } }
        public String Motdepasse { get { return motdepasse; } set { motdepasse = value; } }
    }
}
