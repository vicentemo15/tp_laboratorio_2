﻿using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region "Enumerados"
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region "Atributos"
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="chasis">Chasis</param>
        /// <param name="marca">Marca</param>
        /// <param name="color">Color</param>
        /// 
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        abstract protected ETamanio Tamanio { get; }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Cadena con datos a mostrar</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Convierte datos de un vehiculo a cadena
        /// </summary>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Cadena con datos de vehiculo</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CHASIS: " + p.chasis);
            sb.AppendLine("MARCA : " + p.marca.ToString());
            sb.AppendLine("COLOR : " + p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Vehiculo 1</param>
        /// <param name="v2">Vehiculo 2</param>
        /// <returns> Bool si son o no iguales </returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Vehiculo 1</param>
        /// <param name="v2">Vehiculo 2</param>
        /// <returns>Bool sin son distintos </returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
