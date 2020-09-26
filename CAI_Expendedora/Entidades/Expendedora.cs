using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class Expendedora
    {
        private List<Lata> _latas;
        private string _proveedor;
        private int _capacidad;
        private double _dinero;
        private bool _encendida;

        public List<Lata> Latas
        {
            get { return _latas; }
            set { _latas = value; }
        }

        public string Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }

        public double Dinero
        {
            get { return _dinero; }
            set { _dinero = value; }
        }

        public bool Encendida
        {
            get { return _encendida; }
            set { _encendida = value; }
        }

        //Caso de uso 1. La expendedora de fabrica, trae seis tipos de latas. Se pasa por parametro el proveedor de la expendedora y cantidad de latas que soporta.
        public Expendedora (string Proveedor, int Capacidad)
        {
            this._proveedor = Proveedor;
            this._capacidad = Capacidad;
            Latas = new List<Lata>();
     
            Lata l0 = new Lata("CO1", "Coca Cola Regular", "Cola", 150, 2);
            Lata l1 = new Lata("CO2", "Coca Cola Zero", "Cola", 140, 2);
            Lata l2 = new Lata("SP1", "Sprite Regular", "Lima", 90, 2);
            Lata l3 = new Lata("SP2", "Sprite Zero", "Lima", 80, 2);
            Lata l4 = new Lata("FA1", "Fanta Regular", "Naranja", 150, 2);
            Lata l5 = new Lata("FA2", "Fanta Zero", "Naranja", 140, 2);

            Latas.Add(l0);
            Latas.Add(l1);
            Latas.Add(l2);
            Latas.Add(l3);
            Latas.Add(l4);
            Latas.Add(l5);

        }

        //Caso de uso 0
        public void EncenderMaquina()
        {
            Encendida = true;
            Console.WriteLine("Maquina encendida.");
        }
        //Caso de uso 2
        public void AgregarLata(Lata lata1)
        {
            int capacidadrest = GetCapacidadRestante();

            if(capacidadrest <= 0)
            {
                throw new CapacidadInsuficienteException();
            }
            else
            {
                Latas.Add(lata1);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Se agrego: {0}.", lata1);
                Console.WriteLine("Queda lugar para: " + (capacidadrest-1) + " latas.");
                Console.WriteLine("----------------------------------------");
            }
        }

        public Lata ExtraerLata(string codigo, double dinerocliente)
        {
            Lata lataARemover = null;
            double vuelto; 
            //lata = BuscarLata(Validaciones.ValidarTextoVacio("el codigo de la lata a extraer: "));
            lataARemover = BuscarLata(codigo);

            if (codigo != lataARemover.Codigo)
            {
                throw new CodigoInvalidoException();
            }
            else
            {
                if (dinerocliente == lataARemover.Precio)
                {
                    vuelto = 0;
                    Dinero += dinerocliente;
                    Latas.Remove(lataARemover);
                    Console.WriteLine(
                        "Su vuelto es de: {0}.", vuelto);
                        //+ Environment.NewLine +
                        //"Detalles de su compra: {1}.", lataARemover.ToString());
                }
                else if (dinerocliente >= lataARemover.Precio)
                {
                    vuelto = dinerocliente - lataARemover.Precio;
                    Dinero += lataARemover.Precio;
                    Latas.Remove(lataARemover);
                    Console.WriteLine("Su vuelto es de: {0}", vuelto + Environment.NewLine +
                        "Detalles de su compra: " + lataARemover.ToString());
                }
                else if (dinerocliente < lataARemover.Precio)
                {
                    throw new DineroInsuficienteException();
                }
            }

            return lataARemover;

        }

        public Lata BuscarLata(string code)
        {
            return Latas.Find(l => l.Codigo == code);
        }

        public int GetCapacidadRestante()
        {
            int capacidadrest = Capacidad - Latas.Count();
            return capacidadrest;
        }

        public string GetBalance()
        {
            return string.Format(
                "Dinero disponible en la maquina: ${0}" + Environment.NewLine +
                "Latas disponibles en la maquina: {1}",
                Dinero,
                GetCapacidadRestante()
                );

        }

        public bool EstaVacia()
        {
            bool flag;
            int capacidadrestante = GetCapacidadRestante();

            if(capacidadrestante == 0)
            {
                Console.WriteLine("La maquina esta completa");
                flag = false;
            }
            else
            {
                Console.WriteLine("La maquina no esta vacia, tiene capacidad para {0} latas.", capacidadrestante);
                flag = true;
            }

            return flag;
        }

        public string GetNombre(string codigo)
        {
            string nombre = "";

            switch(codigo.ToUpper())
            {
                case "CO1":
                    {
                        nombre = "Coca Cola Regular";
                        break;
                    }
                case "CO2":
                    {
                        nombre = "Coca Cola Zero";
                        break;
                    }
                case "SP1":
                    {
                        nombre = "Sprite Regular";
                        break;
                    }
                case "SP2":
                    {
                        nombre = "Sprite Zero";
                        break;
                    }
                case "FA1":
                    {
                        nombre = "Fanta Regular";
                        break;
                    }
                case "FA2":
                    {
                        nombre = "Fanta Zero";
                        break;
                    }
            }
            return nombre;
        }

        public string GetSabor(string codigo)
        {
            string sabor = "";

            switch (sabor.ToUpper())
            {
                case "CO1":
                    {
                        sabor = "Cola con azucar";
                        break;
                    }
                case "CO2":
                    {
                        sabor = "Cola sin azucar";
                        break;
                    }
                case "SP1":
                    {
                        sabor = "Sprite con azucar";
                        break;
                    }
                case "SP2":
                    {
                        sabor = "Sprite sin azucar";
                        break;
                    }
                case "FA1":
                    {
                        sabor = "Fanta con azucar";
                        break;
                    }
                case "FA2":
                    {
                        sabor = "Fanta sin azucar";
                        break;
                    }
            }
            return sabor;
        }



    }
}
