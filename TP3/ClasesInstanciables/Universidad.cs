using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region ATRIBUTOS
        public enum EClases 
        { 
            Programacion,
            Laboratorio, 
            Legislacion, 
            SPD 
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Retorna la posicion del elemento a agregar o insertar
        /// </summary>
        /// <param name="i"> Posicion donde insertar o tomar la clase almacenada </param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            { 
                return this.jornadas.ElementAt(i); 
            }

            set 
            { 
                this.jornadas.Insert(i, value);
            }
        }

        /// <summary>
        /// Propiedad del atributo privado alumnos
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
        /// Propiedad del atributo privado instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get 
            { 
                return this.profesores; 
            }

            set
            { 
                this.profesores = value; 
            }
        }

        /// <summary>
        /// Propiedad del atributo privado jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            { 
                return this.jornadas; 
            }

            set
            {  
                this.jornadas = value; 
            }
        }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Guarda la informacion de la clase Universidad en un archivo .xml
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns>True si pudo guardar la informacion</returns>
        public static bool Guardar(Universidad uni)
        {
            bool respuesta = false;
            string directorio = AppDomain.CurrentDomain.BaseDirectory;

            Xml<Universidad> aux = new Xml<Universidad>();
            respuesta = aux.Guardar(directorio + @"Universidad.xml", uni);

            return respuesta;
        }

        /// <summary>
        /// Lee un archivo .xml
        /// </summary>
        /// <returns>Informacion leida del archivo</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> aux = new Xml<Universidad>();
            string directorio = AppDomain.CurrentDomain.BaseDirectory;

            if (!aux.Leer(directorio + @"Universidad.xml", out Universidad respuesta))
            {
                respuesta = null;
            }

            return respuesta;
        }

        /// <summary>
        /// Muestra informacion de la universidad
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("JORNADA: ");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Determina si el alumno no esta dado de alta en la universidad
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Determina si un profesor no es instructor de la universidad
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer profesor que no puede dar la clase, sino null
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux = null;

            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    aux = p;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Retorna una Universidad, donde asigna todos los alumnos que cursen esa clase y los agrega a la jornada correspondiente
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = g == clase;
            Jornada j = new Jornada(clase, p);

            foreach (Alumno a in g.alumnos)
            {
                if (a == clase)
                {
                   j += a;
                }
            }

            g.jornadas.Add(j);

            return g;
        }

        /// <summary>
        /// Agrega a Alumno si este ya no se encuentra en dicha Universidad recibida como parametro
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u == a)
            {
                throw new AlumnoRepetidoException();
            }

            u.alumnos.Add(a);

            return u;
        }

        /// <summary>
        /// Agrega un Profesor a la Universidad recibida como parametro si este no se encuentra en ella
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }

            return g;
        }

        /// <summary>
        /// Verfica si el alumno se encuentra inscripto en la universidad
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Una Universidad es igual a un Profesor si da clases en ella
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna un profesor de ser este capas de dar la clase recibida como parametro
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD  </param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor p in u.profesores)
            { 
                if(p == clase)
                {
                    return p;
                }            
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna toda la informacion de la Universidad recibida como parametro
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion
    }
}