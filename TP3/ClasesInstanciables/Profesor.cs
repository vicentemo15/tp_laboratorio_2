using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor de instancia privado
        /// </summary>
        private Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Constructor de instancia 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Profesor().clasesDelDia;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo privado donde asigna dos clases a un instructor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (random.Next(4))
                {
                    case 0:
                        this.clasesDelDia.Enqueue(EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(EClases.SPD);
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra datos completos de la clase. Nombre completo, nacionalidad y su legajo.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        /// <summary>
        /// Retorna las clases del dia
        /// </summary>
        /// <returns>cadena con los datos de la clase</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach (EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return string.Format("CLASES DEL DÍA: \n{0}", sb.ToString());
        }

        /// <summary>
        /// Retorna datos del profesor
        /// </summary>
        /// <returns>cadena con los datos del profesor </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();          
        }

        /// <summary>
        /// retorna si un profesor no da la clase
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Retorna si el  profesor da la clase
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {     
            foreach (EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                   return true;
                }
            }

            return false;
        }
        #endregion
    }
}