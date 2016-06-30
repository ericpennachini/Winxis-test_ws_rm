using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestConsola.wsRM;

namespace TestConsola
{
    public class Program
    {
        private static WSIntComSoapClient ws = new WSIntComSoapClient();

        public static void Main(string[] args)
        {
            string _cliente = "100";
            string _clave = "Yh78kloar";

            Console.WriteLine("MÉTODOS: ");
            Console.WriteLine(">> 1. reglasActivasAgencia");
            Console.WriteLine(">> 2. desactivaRegla");
            Console.WriteLine(">> 3. aplicarInt");
            Console.WriteLine(">> 4. articuloDatosCompletos");
            Console.WriteLine(">> 5. promocionDatosCompletos");
            Console.WriteLine(">> 6. ventasRealizadas");
            Console.Write("Elija una opción [1 .. 6] ....... ");
            string res = Console.ReadLine();
            switch (res)
            {
                case "1":
                    Console.Clear();
                    Test_reglasActivasAgencia("", _cliente, _clave);
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Regla a desactivar: ");
                    string regla = Console.ReadLine();
                    Test_desactivaRegla(regla, "24/06/2016", _cliente, _clave);
                    break;
                case "3":
                    Console.Clear();
                    List<Tservicios> servicios = new List<Tservicios>();
                    Tservicios tserv = new Tservicios();
                    #region datos
		            tserv.id = 1; // código CDP ¿?¿?
                    tserv.empresa = "2";
                    tserv.servicio = "F001";
                    tserv.origen = "6254";
                    tserv.destino = "6273";
                    tserv.salida = "30/06/16 12:00";
                    tserv.monto = 300F;
                    tserv.calidad = "2"; // Semi cama SC
                    tserv.butacas = 0;
                    tserv.LibresTotal = 2;
                    tserv.agencia = ""; 
	                #endregion
                    servicios.Add(tserv);
                    Test_aplicarInt(servicios, _cliente, _clave);
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("Cod. de articulo: ");
                    string articulo = Console.ReadLine();
                    Test_articuloDatosCompletos(articulo, _cliente, _clave);
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Cod. de promoción: ");
                    string promocion = Console.ReadLine();
                    Test_promocionDatosCompletos(promocion, _cliente, _clave);
                    break;
                case "6":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("ERROR...");
                    Console.ReadKey();
                    break;
            }
            
        }

        // - 1 -
        private static void Test_reglasActivasAgencia(string agencia, string _cliente, string _clave)
        {
            TreglasActivasResp reglasActivas = ws.reglasActivasAgencia(agencia, _cliente, _clave);

            Console.WriteLine("RESULTADOS: ");
            foreach (var r in reglasActivas.reglas)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id -> " + r.id);
                Console.WriteLine("Descripción -> " + r.descripcion);
                Console.WriteLine("Origen -> " + r.origen);
                Console.WriteLine("Destino -> " + r.destino);
                Console.Write("Fechas -> ");
                foreach (var f in r.fechas)
                {
                    Console.Write(f + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("\n\nErrores: " + reglasActivas.error + " -> " + reglasActivas.descError);

            Console.ReadKey();
        }

        // - 2 -
        private static void Test_desactivaRegla(string regla, string fecha, string _cliente, string _clave)
        {
            Tresp resDesactivaRegla = ws.desactivaRegla(regla, fecha, _cliente, _clave);
            Console.WriteLine(resDesactivaRegla.error + " -> " + resDesactivaRegla.descError);
            Console.ReadKey();
        }

        // - 3 -
        private static void Test_aplicarInt(List<Tservicios> listaServicios, string _cliente, string _clave)
        {
            TAplicarIntResp response = ws.aplicarInt(listaServicios.ToArray(), _cliente, _clave);
            List<TserviciosResp> itemsResponse = response.servicios.ToList<TserviciosResp>();
            if (itemsResponse.Count > 0)
            {
                Console.WriteLine("RESULTADOS: ");
                foreach (TserviciosResp tsr in itemsResponse)
                {
                    #region resultados
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("Id (código CDP) -> " + tsr.id);
                    Console.WriteLine("Empresa -> " + tsr.empresa);
                    Console.WriteLine("Servicio -> " + tsr.servicio);
                    Console.WriteLine("Monto -> " + tsr.monto);
                    Console.WriteLine("Calidad -> " + tsr.calidad);
                    Console.WriteLine("Código 1 -> " + tsr.codigo1);
                    Console.WriteLine("Código 2 -> " + tsr.codigo2);
                    Console.WriteLine("Texto 1 -> " + tsr.texto1);
                    Console.WriteLine("Texto 2 -> " + tsr.texto2);
                    if (tsr.articulo1 != null)
                    {
                        Console.WriteLine("Artículo 1");
                        Console.WriteLine("    Id -> " + tsr.articulo1.id);
                        Console.WriteLine("    Nombre -> " + tsr.articulo1.nombre);
                        Console.WriteLine("    Precio -> $" + tsr.articulo1.precio); 
                    }
                    if (tsr.articulo2 != null)
                    {
                        Console.WriteLine("Artículo 2");
                        Console.WriteLine("    Id -> " + tsr.articulo2.id);
                        Console.WriteLine("    Nombre -> " + tsr.articulo2.nombre);
                        Console.WriteLine("    Precio -> $" + tsr.articulo2.precio); 
                    }
                    if (tsr.promocion != null)
                    {
                        Console.WriteLine("Promoción");
                        Console.WriteLine("    Id -> " + tsr.promocion.id);
                        Console.WriteLine("    Código -> " + tsr.promocion.codigo);
                        Console.WriteLine("    Tipo de descuento ->" + tsr.promocion.descripcion);
                        Console.WriteLine("    Descuento -> " + tsr.promocion.descuento); 
                    }
                    if (tsr.packDescuentos != null)
                    {
                        Console.WriteLine("Pack de descuentos");
                        Console.WriteLine("    Desc. x 2 pasajeros -> " + tsr.packDescuentos.descuento2);
                        Console.WriteLine("    Desc. x 3 pasajeros -> " + tsr.packDescuentos.descuento3);
                        Console.WriteLine("    Desc. x 4 pasajeros -> " + tsr.packDescuentos.descuento4);
                        Console.WriteLine("    Desc. x +4 pasajeros -> " + tsr.packDescuentos.descuento5); 
                    }
                    #endregion
                }
            }
            else
            {
                Console.WriteLine("Error -> " + response.error);
                Console.WriteLine("Descripción del error -> " + response.descError);
            }
            Console.ReadKey();
        }

        // - 4 -
        private static void Test_articuloDatosCompletos(string articulo, string _cliente, string _clave)
        {
            TarticuloResp response = ws.articuloDatosCompletos(articulo, _cliente, _clave);

            Console.WriteLine("RESULTADOS: ");
            Console.WriteLine("Descripcion -> " + response.descripcion);
            Console.WriteLine("Detalle -> " + response.detalle);
            Console.WriteLine("Medida -> " + response.medida);
            Console.WriteLine("Precio -> $" + response.precio);
            Console.WriteLine("Legales -> " + response.legales);
            Console.WriteLine("Plantilla e-mail proveedor -> " + response.plantillaEmailProveedor);
            Console.WriteLine("Plantilla voucher proveedor -> " + response.plantillaVoucherProveedor);
            Console.WriteLine("Plantilla e-mail pasajero -> " + response.plantillaEmailPasajero);
            Console.WriteLine("Link de la imagen -> " + response.imagen);
            Console.WriteLine("ERROR:");
            Console.WriteLine("_ Error -> " + response.error);
            Console.WriteLine("_ Desc. del error -> " + response.descError);

            Console.ReadKey();
        }

        // - 5 -
        private static void Test_promocionDatosCompletos(string promocion, string _cliente, string _clave)
        {
            TpromocionResp response = ws.promocionDatosCompletos(promocion, _cliente, _clave);

            Console.WriteLine("RESULTADOS: ");
            Console.WriteLine("Código -> " + response.codigo);
            Console.WriteLine("Descripción -> " + response.descripcion);
            Console.WriteLine("Detalle -> " + response.detalle);
            Console.WriteLine("Descuento -> " + response.descuento);
            Console.WriteLine("Legales -> " + response.legales);
            Console.WriteLine("Imagen -> " + response.imagen);
            Console.WriteLine("Porcentaje mayorista -> " + response.porcentajeMayorista);
            Console.WriteLine("Porcentaje transportista -> " + response.porcentajeTransportista);
            Console.WriteLine("ERROR:");
            Console.WriteLine("_ Error -> " + response.error);
            Console.WriteLine("_ Desc. del error -> " + response.descError);

            Console.ReadKey();
        }

    }
}
