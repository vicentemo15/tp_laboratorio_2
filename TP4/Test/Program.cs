using Entidades;
using System;
using System.Collections.Generic;
using static Entidades.Bazar;
using static Entidades.Venta<Entidades.Producto>;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            Congelado c1 = new Congelado(1, "Espinaca", "Carrefour", 50, DateTime.Now.AddDays(30));
            Congelado c2 = new Congelado(2, "Hamburguesas", "Paty", 150.50, DateTime.Now.AddDays(10));
            Congelado c3 = new Congelado(3, "Espinaca", "Carrefour", 50, DateTime.Now.AddDays(20));

            Bazar b1 = new Bazar(4, "Balde", "Colombraro", 300, EMaterial.Plastico);
            Bazar b2 = new Bazar(5, "Jarra", "Luxury", 122.35, EMaterial.Vidrio);
            Bazar b3 = new Bazar(6, "Silla", "Maderera San Juan", 1500, EMaterial.Madera);

            Comercio c = new Comercio();

            try
            {
                Venta<Producto> v1 = new Venta<Producto>(1, "Juan Perez", ECaja.CajaUno);
                v1.CambioEstado += venta_EventoCambioEstado;
                v1 += c1;
                v1 += b1;

                Console.WriteLine("Nueva venta: \n{0}", v1.ToString());
                c += v1;

                Venta<Producto> v2 = new Venta<Producto>(2, "Jorge Rojas", ECaja.CajaDos);
                v2.CambioEstado += venta_EventoCambioEstado;
                v2 += c2;
                v2 += c3;

                Console.WriteLine("Nueva venta: \n{0}", v2.ToString());
                c += v2;

                Venta<Producto> v3 = new Venta<Producto>(1, "Pedro Gonzales", ECaja.CajaTres);
                v3.CambioEstado += venta_EventoCambioEstado;
                v3 += b2;
                v3 += b3;

                Console.WriteLine("Nueva venta: \n{0}", v3.ToString());
                c += v3;
            }
            catch (FacturaRepetidaException ex)
            {
                Console.WriteLine(ex.Message);
            }

            System.Threading.Thread.Sleep(11000);
            Console.WriteLine("Presione una tecla para continuar ...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine(c.ToString());
            Console.WriteLine("Presione una tecla para continuar ...");
            Console.ReadKey();

            Console.Clear();
            Exportador<List<Venta<Producto>>> exp = new Exportador<List<Venta<Producto>>>();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ventas.xml";
            try
            {
                exp.Exportar(archivo, c.Ventas);
                Console.WriteLine("Se ha exportado los datos de ventas al archivo '{0}'", archivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Fin del test. Presione una tecla para terminar ...");
            Console.ReadKey();
        }

        private static void venta_EventoCambioEstado(object sender, EventArgs e)
        {
            Venta<Producto> v = sender as Venta<Producto>;
            Console.WriteLine("La venta {0} cambio de estado a {1}.", v.factura, v.Estado);
            Logger.Guardar("La venta " + v.factura + " cambio de estado a " + v.Estado);
        }
    }
}