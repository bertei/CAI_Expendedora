using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class Lata
    {
        private string _codigo;
        private string _nombre;
        private string _sabor;
        private double _precio;
        private double _volumen;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Sabor
        {
            get { return _sabor; }
            set { _sabor = value; }
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public double Volumen
        {
            get { return _volumen; }
            set { _volumen = value; }
        }

        public Lata (string Codigo, string Nombre, string Sabor, double Precio, double Volumen)
        {
            this._codigo = Codigo;
            this._nombre = Nombre;
            this._sabor = Sabor;
            this._precio = Precio;
            this._volumen = Volumen;
        }

        public double GetPrecioPorLitro()
        {
            double precioporlitro = ((Precio * 1000) / Volumen);
            return precioporlitro;
        }

        public override string ToString()
        {
            return string.Format("Codigo: {0} - Nombre: {1} - Sabor: {2} - Precio: ${3}",
                Codigo,
                Nombre,
                Sabor,
                Precio
                ); 
        }

        public string GetStockYDescrp()
        {
            return string.Format("Codigo: {0} - Nombre: {1} - Sabor: {2} - Precio: ${3}, Precio por litro: ${4}.",
                Codigo,
                Nombre,
                Sabor,
                Precio,
                GetPrecioPorLitro()
                );
        }

    }
}
