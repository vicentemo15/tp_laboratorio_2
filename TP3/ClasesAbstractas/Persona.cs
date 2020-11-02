using Excepciones;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        public enum ENacionalidad 
        { 
            Argentino, 
            Extranjero 
        }

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado apellido
        /// </summary>
        public string Apellido
        {
            get 
            { 
                return this.apellido; 
            }

            set 
            { 
                this.apellido = ValidarNombreApellido(value); 
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado dni
        /// </summary>
        public int DNI
        {
            get 
            { 
                return this.dni; 
            }

            set 
            { 
                this.dni = ValidarDni(this.nacionalidad, value); 
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get 
            { 
                return this.nacionalidad; 
            }

            set 
            { 
                this.nacionalidad = value; 
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado nombre
        /// </summary>
        public string Nombre
        {
            get 
            { 
                return this.nombre; 
            }
            set 
            { 
                this.nombre = ValidarNombreApellido(value); 
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado dni, valida internamente la carga correcta del dato
        /// </summary>
        public string StringToDNI
        {
            set 
            { 
                this.dni = ValidarDni(this.Nacionalidad, value); 
            }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extrajero </param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extrajero </param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Retorna nombre completo y su nacionalidad
        /// </summary>
        /// <returns> cadena con datos de la persona  </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Valida el DNI dependiendo su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        /// <param name="valor"> DNI tipo int </param>
        /// <returns> retorna si el DNI es valido </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int respuesta = ValidarDni(nacionalidad, dato.ToString());
            return respuesta;
        }

        /// <summary>
        /// Valida el rango del DNI dependiendo su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> Argentino, Extranjero  </param>
        /// <param name="valor"> DNI tipo string </param>
        /// <returns> retorna si el DNI es valido </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int respuesta = 0;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:

                    if (int.TryParse(dato, out dni))
                    {
                        if (dni > 0 && dni < 90000000)
                        {
                            respuesta = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }
                    }
                    else
                    {
                        throw new DniInvalidoException();
                    }

                    break;

                case ENacionalidad.Extranjero:

                    if (int.TryParse(dato, out dni))
                    {
                        if (dni >= 90000000 && dni < 100000000)
                        {
                            respuesta = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }
                    }
                    else
                    {
                        throw new DniInvalidoException();
                    }

                    break;
            }

            return respuesta;
        }

        /// <summary>
        /// Valida si es correcto el tipo de dato para nombre y apellido
        /// </summary>
        /// <param name="dato"> Nombre/Apellido </param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string respuesta = "";
            bool invalido = false;

            foreach (char item in dato)
            {
                if (!char.IsLetter(item) && !char.IsWhiteSpace(item))
                {
                    invalido = true;
                    break;
                }
            }

            if (!invalido)
            {
                respuesta = dato;
            }

            return respuesta;
        }
        #endregion
    }
}