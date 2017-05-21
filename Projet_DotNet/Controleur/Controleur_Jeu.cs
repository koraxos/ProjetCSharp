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

        public static void sendJeu(Jeu j)
        {
            int validation;//si validation ==1 alors tout s'est bien passé
            jeuHttp.sendJeu(j);
        }

    }
}
