using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Test que comprueba alumno repetido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void Test_AlumnoRepetido_LanzaExcepcion()
        {
            Alumno a1 = new Alumno(1, "Nombre1", "Apellido1", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(1, "Nombre2", "Apellido2", "29777555", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Universidad u = new Universidad();

            u += a1;
            u += a2;
        }

        /// <summary>
        /// Test que valida DNI dependiendo de su nacionalidad y genera una excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Test_NacionalidadInvalida_LanzaExcepcion()
        {
            Alumno a1 = new Alumno(1, "Nombre1", "Apellido1", "29777555", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Universidad u = new Universidad();

            u += a1;
        }

        /// <summary>
        /// Test valida el formato del DNI
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Test_DNIInvalido_LanzaExcepcion()
        {
            Alumno a1 = new Alumno(1, "Nombre1", "Apellido1", "2977755B", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Universidad u = new Universidad();

            u += a1;
        }

        /// <summary>
        /// Test que valida un lista de alumnos no es null
        /// </summary>
        [TestMethod]
        public void Test_ListaAlumnosNull_IsFalse()
        {
            Universidad u = new Universidad();

            Assert.IsNotNull(u.Alumnos);
        }
    }
}
