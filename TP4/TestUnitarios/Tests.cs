using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestUnitarios
{
    /// <summary>
    /// Clase que contiene test unitarios
    /// </summary>
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Test que genera dos facturas iguales y genera una excepcion 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FacturaRepetidaException))]
        public void FacturaRepetidaException()
        {
            Venta<Producto> v1 = new Venta<Producto>();
            Venta<Producto> v2 = new Venta<Producto>();
            v1.factura = 1;
            v1.CambioEstado += mockEventoEstado;
            v2.factura = 1;

            Comercio c = new Comercio();
            c += v1;
            c += v2;
        }

        /// <summary>
        /// Test que genera dos productos iguales y chequea la sobrecarga del operador ==
        /// </summary>
        [TestMethod]
        public void ProductosIguales()
        {
            Congelado c1 = new Congelado(1, "c1", "marca1", 1, DateTime.Now);
            Congelado c2 = new Congelado(1, "c2", "marca2", 2, DateTime.Now);

            Assert.AreEqual(c1, c2);
        }

        private void mockEventoEstado(object sender, EventArgs e)
        {
            return;
        }
    }
}
