using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DotNet.Modele
{
    public class Operation
    {
        int operande1;
        int operande2;
        int resultat;

        public Operation(int o, int o2)
        {
            operande1 = o;
            operande2 = o2;
            resultat = o * o2;
        }

        public int getOperateur(int i)
        {
            if (i == 0)
                return operande1;
            return operande2;
        }

        public int getResultat()
        {
            return resultat;
        }
    }
}
