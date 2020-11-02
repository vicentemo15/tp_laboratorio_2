using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region ATRIBUTOS

        private int legajo;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Comprueba si es del mismo tipo
        /// </summary>
        /// <param name="obj"> Cualquiero Clase </param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                Universitario u = (Universitario)obj;
                if(this.legajo == u.legajo || this.DNI == u.DNI)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Muestra datos completos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return string.Format("{0}\nLEGAJO NUMERO: {1}", base.ToString(), this.legajo);
        }

        /// <summary>
        /// Dos universitarios son diferentes si tienen DNI y Legajo diferentes
        /// </summary>
        /// <param name="pg1"> Universitario 1</param>
        /// <param name="pg2"> Universitario 2</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Dos Universitarios son iguales si comparten el mismo legajo o mismo DNI
        /// </summary>
        /// <param name="pg1"> Universitario 1 </param>
        /// <param name="pg2"> Universitario 2 </param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Implementacion en sus herencias
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
