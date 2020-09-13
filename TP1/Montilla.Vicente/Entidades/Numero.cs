using System;

namespace Entidades.Clases
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #region CONSTRUCTOR
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region VALIDACION
        private double ValidarNumero(string strNumero)
        {
            double numberVal;
            if (double.TryParse(strNumero, out numberVal))
            {
                return numberVal;
            }

            return 0;
        }

        private bool EsBinario(string binario)
        {
            foreach (var digito in binario)
            {
                if (digito != '0' && digito != '1')
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region CONVERTIDOR
        public string BinarioDecimal(string binario)
        {
            if (this.EsBinario(binario))
            {
                int auxDecimal = Convert.ToInt32(binario, 2);
                return auxDecimal.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }

        public string DecimalBinario(string numero)
        {
            double auxDouble = this.ValidarNumero(numero);
            if (auxDouble != 0)
            {
                return DecimalBinario(auxDouble);
            }
            else
            {
                return "Valor inválido";
            }
        }

        public string DecimalBinario(double numero)
        {
            int auxEntero = Math.Abs(Convert.ToInt32(numero));
            return Convert.ToString(auxEntero, 2);
        }
        #endregion

        #region OPERADORES
        public static double operator+(Numero n1, Numero n2)
        {
             return n1.numero + n2.numero;
        }

        public static double operator-(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator*(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator/(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }
        #endregion
    }
}