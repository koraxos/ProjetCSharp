using Projet_DotNet.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_DotNet.Request;
using Projet_DotNet.Modele;
namespace Projet_DotNet.Controleur
{
    public class Controleur_Jeu
    {
        private static JeuHttp jeuHttp= new JeuHttp();
        private static Controleur_Jeu instance = null;
        private Controleur_Jeu()
        {
        }

        public static Controleur_Jeu getInstance()
        {
            if (instance == null)
                instance = new Controleur_Jeu();
            return instance;
        }
        public void sendJeu(Jeu j)
        {
            int validation;//si validation ==1 alors tout s'est bien passé
            validation=jeuHttp.sendJeu(j);

            System.Console.WriteLine(validation.ToString());
        }

    }
}
