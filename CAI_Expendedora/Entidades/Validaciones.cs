using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class Validaciones
    {

        public static string ValidarTextoVacio(string variable)
        {
            string salidavariable;

            do
            {
                Console.Write("Ingrese {0} ", variable);
                salidavariable = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(salidavariable))
                {
                    Console.WriteLine("Error. Debe ingresar al menos un caracter.");
                }
            } while (string.IsNullOrEmpty(salidavariable));

            return salidavariable;
        }

        public static double ValidarNumero(string variable)
        {
            double salidauserinput;
            string userinput;
            bool flag = false;
            do
            {
                Console.Write("Ingrese {0}", variable);
                userinput = Console.ReadLine().ToUpper();
                if (!double.TryParse(userinput, out salidauserinput))
                {
                    Console.WriteLine("Error. Debe ingresar un dato numerico.");
                }
                else if (salidauserinput < 0)
                {
                    Console.WriteLine("Error. Debe ingresar un dato numerico positivo.");
                }
                else
                {
                    flag = true;
                }
            } while (flag == false);

            return salidauserinput;
        }






    }

}
