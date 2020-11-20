using System;

namespace Entidades.Clases
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad que setea el numero.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #region CONSTRUCTOR

        /// <summary>
        /// Por defecto el compilador inicializa el atributo double en 0.
        /// </summary>
        public Numero()
        {

        }

        /// <summary>
        /// Crea objeto Numero con el parametro double ingresado, reutiliza codigo llevandolo al constructor con parametro de string
        /// </summary>
        /// <param name="numero">Valor a setear en el atributo privado de Numero</param>
        public Numero(double numero) : this(numero.ToString())
        {

        }

        /// <summary>
        /// Crea objeto Numero con el parametro string ingresado
        /// </summary>
        /// <param name="strNumero">Valor a setear en el atributo privado de Numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region VALIDACION
        /// <summary>
        /// Valida antes de setear el a Numero si el parametro es casteable a double
        /// </summary>
        /// <param name="strNumero">Valor a ser casteado a double</param>
        /// <returns>De ser posible castea string a double, de lo contrario retorna 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double numberVal;
            if (double.TryParse(strNumero, out numberVal))
            {
                return numberVal;
            }

            return 0;
        }

        /// <summary>
        ///Retorna bool en caso de ser distino de 1 y 0
        /// </summary>
        private bool EsBinario(string binario)
        {
            if (binario == "")
            {
                return false;
            }

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
        /// <summary>
        /// Convierte de ser posible un valor binario a decimal
        /// </summary>
        /// <param name="binario">Valor a convertir a decimal</param>
        /// <returns>De ser posible retorna valor binario convertido a decimal, de lo contrario "Valor invalido"</returns>
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

        /// <summary>
        /// Convierte de ser posible un valor decimal a binario recibiendo como parametro un string
        /// </summary>
        /// <param name="numero">Valor a convertir a binario</param>
        /// <returns>De ser posible retorna valor decimal convertido a binario, de lo contrario "Numero invalido</returns>
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

        /// <summary>
        /// Convierte de ser posible un valor decimal a binario recibiendo como parametro un double
        /// </summary>
        /// <param name="numero">Valor a convertir a binario</param>
        /// <returns>De ser posible retorna valor decimal convertido a binario, de lo contrario "Numero invalido"</returns>
        public string DecimalBinario(double numero)
        {
            int auxEntero = Math.Abs(Convert.ToInt32(numero));
            return Convert.ToString(auxEntero, 2);
        }
        #endregion

        #region OPERADORES
        // <summary>
        /// Suma dos clases del tipo Numero
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Suma entre los atributos privados de clase Numero "numero"</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos clases del tipo Numero
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Resta entre los atributos privados de clase Numero "numero"</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        // <summary>
        /// Multiplica dos clases del tipo Numero
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Multiplicacion entre los atributos privados de clase Numero "numero"</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos clases del tipo Numero, valida division por 0
        /// </summary>
        /// <param name="n1">Operando1</param>
        /// <param name="n2">Operando2</param>
        /// <returns>Multiplicacion entre los atributos privados de clase Numero "numero", si Operando2 es == 0 entonces retorna un double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
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