using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class Program
    {
        static void Main(string[] args)
        {
            Expendedora exp1 = new Expendedora("Exp. FCE", 10);
            double opcion;
            Console.WriteLine("Expendedora de latas de gaseosa.");
            Console.WriteLine("Presione '0' para encender la maquina.");
            Console.WriteLine("Presione '1' para pedir el listado de latas disponibles.");
            Console.WriteLine("Presione '2' para insertar lata variable a la maquina.");
            Console.WriteLine("Presione '3' para comprar una lata de la maquina.");
            Console.WriteLine("Presione '4' para ver el balance de la maquina.");
            Console.WriteLine("Presione '5' para ver stock y descripcion de las latas.");
            
            do
            { 
                opcion = Validaciones.ValidarNumero("la opcion que desea ejecutar: ");
                try
                {
                    switch(opcion)
                    {
                        case 0:
                            {
                                exp1.EncenderMaquina();
                                break;
                            }
                        case 1:
                            {
                                MostrarStock(exp1);
                                break;
                            }
                        case 2:
                            {
                                InsertarBebida(exp1);
                                break;
                            }
                        case 3:
                            {
                                ExtraerLata(exp1);
                                break;
                            }
                        case 4:
                            {
                                ObtenerBalance(exp1);
                                break;
                            }
                        case 5:
                            {
                                StockYDescripcion(exp1);
                                break;
                            }
                        default:
                            break;
                    
                    }
                }
                catch (Exception excp)
                {
                    Console.WriteLine(excp.Message);
                }

            } while (opcion <= 5);

        }

        public static void MostrarStock(Expendedora exp)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (Lata l in exp.Latas)
            {  
                Console.WriteLine(l.ToString());
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        public static void ListarCodigos()
        {
            Console.WriteLine(
                    "----------------------------------------" + Environment.NewLine +
                    "Codigos validos: " + Environment.NewLine +
                    "CO1 = Coca Cola Regular con azucar." + Environment.NewLine +
                    "CO2 = Coca Cola Zero sin azucar." + Environment.NewLine +
                    "SP1 = Sprite Regular con azucar." + Environment.NewLine +
                    "SP2 = Sprite Zero sin azucar." + Environment.NewLine +
                    "FA1 = Fanta Regular con azucar." + Environment.NewLine +
                    "FA2 = Fanta Zero sin azucar." + Environment.NewLine +
                    "----------------------------------------");
        }

        public static void InsertarBebida(Expendedora exp)
        {
           if(exp.Encendida == false)
           {
                Console.WriteLine("Debe encendeder la maquina primero.");
           }
           else
           {
                ListarCodigos();
                try
                {
                    string codigo = Validaciones.ValidarTextoVacio("el codigo de la lata: "); //valido que el string no sea vacio

                    //si lo ingresado es dif a los codigos disponibles, tira exception de codigo invalido
                    if (codigo != "CO1" && codigo != "SP1" && codigo != "FA1" && codigo != "CO2" && codigo != "SP2" && codigo != "FA2")
                    {
                        throw new CodigoInvalidoException();
                    }

                    //valido dos userinput en nros, que no sean != a double y negativos
                    double precio = Validaciones.ValidarNumero("el precio de la lata: ");
                    double volumen = Validaciones.ValidarNumero("el volumen de la lata: ");

                    //Funcion Get que pasando el codigo ingresado, por parametro, si cae en el switch de los codigos, te devuelve en string el nombre perteneciente a ese codigo
                    string nombre = exp.GetNombre(codigo);
                    //lo mismo al otro get, pero el codigo te devuelve el sabor perteneciente al codigo ingresado
                    string sabor = exp.GetSabor(codigo);

                    //instancio la clase lata, osea creo un objeto nuevo con los datos variables ingresados
                    Lata lvariable = new Lata(codigo, nombre, sabor, precio, volumen);
                    //uso el metodo de la clase expendedora, que agrega la lata variable a la lista de latas
                    exp.AgregarLata(lvariable);
                }
                catch(Exception exc)
                {
                    Console.WriteLine("Se produjo un error, la causa es: {0}", exc.Message);
                }
           }
        }

        public static void ExtraerLata(Expendedora exp)
        {
            if(exp.Encendida == false)
            {
                Console.WriteLine("Debe encendeder la maquina primero.");
            }
            else if(exp.Latas.Count == 0)
            {
                throw new SinStockException();
            }
            else
            {
                try
                {
                    ListarCodigos();
                    string codigo = Validaciones.ValidarTextoVacio("el codigo de la lata a comprar: ");
                    double dinero = Validaciones.ValidarNumero("el dinero: ");

                    exp.ExtraerLata(codigo, dinero);

                }
                catch(Exception exc)
                {
                    Console.WriteLine("Se produjo un error, la causa es: {0}", exc.Message);
                }
            }
        }

        public static void ObtenerBalance(Expendedora exp)
        {
            if(exp.Encendida == false)
            {
                Console.WriteLine("Debe encender la maquina primero.");
            }
            else
            {
                Console.WriteLine(exp.GetBalance());
            }
        }

        public static void StockYDescripcion(Expendedora exp)
        {
            if (exp.Encendida == false)
            {
                Console.WriteLine("Debe encender la maquina primero.");
            }
            else if (exp.Latas.Count == 0)
            {
                throw new SinStockException();
            }
            else
            {
                try
                {
                    MostrarStock(exp);
                }
                catch(Exception excp)
                {
                    Console.WriteLine(excp.Message);
                }
            }
        }

    }
}
