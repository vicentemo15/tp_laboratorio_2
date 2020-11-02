using Archivos;
using System;
using System.Collections.Generic;
using System.Text;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de lectura y escritura de la lista privada como atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            { 
                return this.alumnos;
            }

            set 
            { 
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atriburo privado clase
        /// </summary>
        public EClases Clase
        {
            get 
            { 
                return this.clase;
            }

            set 
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura del atributo privado instructor
        /// </summary>
        public Profesor Instructor
        {
            get 
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value; 
            }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto privado
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <param name="instructor"> Profesor </param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo de clase que garda en formato .txt la lista de Jornada que recibe como parametro
        /// </summary>
        /// <param name="jornada"> Lista del tipo Jornada a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool respuesta = false;
            string directorio = AppDomain.CurrentDomain.BaseDirectory;

            Texto aux = new Texto();
            respuesta = aux.Guardar(directorio + @"Jornada.txt", jornada.ToString());

            return respuesta;
        }

        /// <summary>
        /// Metodo de clase que lee un archivo .txt en su directorio
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto aux = new Texto();
            string directorio = AppDomain.CurrentDomain.BaseDirectory;

            if (!aux.Leer(directorio + @"Jornada.txt", out string respuesta))
            {
                respuesta = null;
            }

            return respuesta;
        }

        /// <summary>
        /// Metodo de clase donde una Jornada no es igual a un alumno si este no este no cursa la clase de la Jornada
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Metodo de clase, donde una Jornada es igual a un alumno si este pertenece a la clase de esta Jornada
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

        /// <summary>
        /// Metodo de clase que a�ade a un alumno a la jornada si este no esta ya en ella
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool existe = false;
            foreach (Alumno item in j.Alumnos)
            {
                if (item == a)
                {
                    existe = true;
                    break;
                }
            }
            if (!existe)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        /// Retorna toda la informacion de la Jornada con todos sus alumnos y su informacion personal
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            if(this.alumnos.Count > 0)
            { 
                sb.AppendFormat("\nCLASE DE {0} POR {1}", this.clase.ToString(), this.instructor.ToString());
                sb.AppendLine("ALUMNOS: ");
                foreach (Alumno item in this.Alumnos)
                {
                    sb.AppendLine(item.ToString());
                }

                sb.Append("<------------------------------------------------->");
            }

            return sb.ToString();
        }
        #endregion
    }
}