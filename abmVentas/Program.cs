using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abmVentas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int opcionElegida;
            bool seguir = true;
            bool continuar = true;
            int cantidadProductosStock = 4;
            int cantidadVentas = 1;
            string sn = "";
            int indice = -1;

            //Variables de ingreso de producto
            string nombreProductoIngresado = "";
            string descripcionProductoIngresado = "";
            float precioProductoIngresado = 0;
            float cantidadProductoIngresado = 0;

            //Variables de venta
            float precioVenta = 0;
            float cantidadVenta = 0;
            float totalVenta = 0;
            float totalRecaudado = 0;

            //Arrays
            /* string[] stockNombre = new string[cantidadProductosStock];
            string[] stockDescripcion = new string[cantidadProductosStock];
            float[] stockCantidades = new float[cantidadProductosStock];
            float[] stockPrecios = new float[cantidadProductosStock]; */

            //Arrays testeo
            string[] stockNombre = { "Banana", "", "Manzana Roja", "Pera" };
            string[] stockDescripcion = { "Brasil", "", "Misiones", "Colombia" };
            float[] stockCantidades = { 10, 0, 5, 7 };
            float[] stockPrecios = { 20, 0, 10, 25 };

            string[] ventaNombres = new string[cantidadVentas];
            float[] ventaCantidades = new float[cantidadVentas];
            float[] ventaPrecios = new float[cantidadVentas];
            float[] acumuladoCantidades = new float[cantidadProductosStock];
            string[] acumuladoVentas = new string[cantidadVentas];
            float[] acumuludadoPrecios = new float[cantidadVentas];

            //Programa            
            do
            {
                Metodos.titulo();
                Metodos.menuOpcionesPrincipal();
                opcionElegida = Metodos.validarOpcion("¿Qué desea hacer?: ", 1, 6);

                switch (opcionElegida)
                {
                    case 1:
                        do
                        {
                            Metodos.cargarProducto(nombreProductoIngresado, stockNombre, descripcionProductoIngresado, cantidadProductoIngresado, precioProductoIngresado, sn, continuar, indice, cantidadProductosStock, acumuladoCantidades, stockDescripcion, stockCantidades, stockPrecios);
                            
                            //Continuar
                            sn = Metodos.validarSN("Ingresar otro producto (s/n)");

                            if (sn == "n")
                            {
                                continuar = false;
                            }

                            Console.Clear();

                        } while (continuar);

                        break;

                    case 2:

                        Console.Clear();
                        Metodos.titulo();

                        //Mostrar Stock
                        Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                        sn = Metodos.validarSN("\nPara modificar presione s. Para volver al menu principal presione n");

                        if (sn == "s")
                        {
                            Console.Clear();
                            Metodos.titulo();

                            //Mostrar Stock
                            Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                            do
                            {
                                //Modificación                   
                                Metodos.modificarProducto(indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                //Salir
                                sn = Metodos.validarSN("¿Desea modificar otro producto? (s/n)");

                                if (sn == "n")
                                {
                                    continuar = false;
                                }

                            } while (continuar);

                            Console.Clear();
                        }
                        else
                        {
                            //Volver al menu principal
                            Console.Clear();
                        }

                        break;

                    case 3:

                        Console.Clear();
                        Metodos.titulo();

                        //Mostrar Stock
                        Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                        sn = Metodos.validarSN("\nPara borrar presione s. Para volver al menu principal presione n");

                        if (sn == "s")
                        {
                            //Borrar
                            Metodos.borrarProducto(indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios, sn, continuar);
                            
                        }
                        else
                        {
                            //Volver al menu principal
                            Console.Clear();

                        }

                        break;

                    case 4:

                        do
                        {
                            //Venta
                            Metodos.ventaProducto(indice, stockCantidades, stockNombre, cantidadVenta, cantidadVentas, ventaNombres, acumuladoCantidades, ventaCantidades, precioVenta,  stockPrecios, ventaPrecios, totalVenta, sn, continuar,  totalRecaudado);

                            //Salir
                            sn = Metodos.validarSN("Presione s para volver al menu principal o n para seguir vendiendo");

                            if (sn == "s")
                            {
                                continuar = false;
                                Console.Clear();
                            }

                        } while (continuar);

                        break;

                    case 5:

                        //Acumulados
                        Metodos.mostrarAcumulados(opcionElegida, stockNombre, acumuladoCantidades, continuar, sn, totalRecaudado);

                        break;

                    case 6:

                        //Salir
                        Console.Clear();
                        Metodos.titulo();

                        //Confirmar salida del programa
                        sn = Metodos.validarSN("Para salir persione s. Para volver al menu principal precione n");

                        if (sn == "s")
                        {
                            seguir = false;
                            Console.Clear();
                        }

                        break;

                    default:
                        break;
                }

            } while (seguir);

            Console.Clear();
            Metodos.titulo();
            Console.Write("Gracias por utilizar nuestro sistema. Presione cualquier tecla para cerrar el programa");

            Console.ReadKey();
        }

    }
}
