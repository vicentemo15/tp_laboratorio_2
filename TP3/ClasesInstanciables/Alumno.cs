using EntidadesAbstractas;
using System.ComponentModel;
using System.Text;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region ATRIBUTOS

        public enum EEstadoCuenta 
        {
            AlDia, 
            Deudor,
            Becado 
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero</param>
        /// <param name="claseQueToma"> Programacion, Laboratorio, Legislacion, SPD </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero</param>
        /// <param name="claseQueToma"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <param name="estadoCuenta"> AlDia, Deudor, Becado </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Muestra datos completos del alumno
        /// </summary>
        /// <returns>cadena con datos del alumno </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("\nESTADO DE CUENTA: {0}", this.estadoCuenta.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Un alumno es diferente a una clase cuando no toma esa clase
        /// </summary>
        /// <param name="a"> Alumno </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return  true;
            }

            return false;
        }

        /// <summary>
        /// Un alumno es igual a una clase cuando toma esa clase y no es  deudor
        /// </summary>
        /// <param name="a"> Alumno </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retorna la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}", this.claseQueToma.ToString());
        }

        /// <summary>
        /// Muestra datos completos del alumno
        /// </summary>
        /// <returns>cadena con los datos del alumno</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        #endregion
    }
}