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
            string sn;
            int indice = -1;

            //Variables de ingreso de producto
            string nombreProductoIngresado;
            string descripcionProductoIngresado;
            float precioProductoIngresado;
            float cantidadProductoIngresado;

            //Variables de venta
            float precioVenta = 0;
            float cantidadVenta;
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

            string[] ventaNombres = new string[cantidadProductosStock];
            float[] ventaCantidades = new float[cantidadProductosStock];
            float[] ventaPrecios = new float[cantidadProductosStock];
            float[] acumuladoCantidades = new float[cantidadProductosStock];

            //Programa            
            do
            {
                titulo();
                menuOpcionesPrincipal();
                opcionElegida = validarOpcion("¿Qué desea hacer?", 1, 6);

                switch (opcionElegida)
                {
                    case 1:
                        do
                        {
                            do
                            {
                                Console.Clear();
                                titulo();

                                //Carga de datos
                                Console.WriteLine("Agregar producto\n\n");
                                Console.WriteLine("Complete los siguientes datos:\n");
                                nombreProductoIngresado = validarNombre("Ingrese nombre del producto: ", stockNombre);
                                Console.Write("Ingrese descripción del producto: ");
                                descripcionProductoIngresado = Console.ReadLine();
                                cantidadProductoIngresado = validarPrecioCantidad("Ingrese cantidad del producto (máximo 3 decimales. Use coma para separar los decimales): ");
                                precioProductoIngresado = validarPrecioCantidad("Ingrese precio del producto (máximo 3 decimales. Use coma para separar los decimales): ");

                                //Confirmación de carga
                                Console.Clear();
                                titulo();

                                Console.WriteLine($"Detalle de producto ingresado:\n\nNombre: {nombreProductoIngresado}\nDescripción: {descripcionProductoIngresado}\nCantidad: {cantidadProductoIngresado}Kgs\nPrecio: ${precioProductoIngresado}xKg");

                                sn = validarSN("Si es correcto precione s. Para modificar presione n");
                                if (sn == "s")
                                {
                                    continuar = false;
                                }

                            } while (continuar);

                            continuar = true;//reseteo de variable

                            //Carga de stock
                            indice = -1;

                            //Comprobar si hay elementos null/empty en el array
                            for (int i = 0; i < stockNombre.Length; i++)
                            {
                                if (string.IsNullOrEmpty(stockNombre[i]))
                                {

                                    indice = i;
                                    break;
                                }
                            }

                            if (indice == -1)
                            {//Si no hay elementos null/empty

                                cantidadProductosStock++;//Modificar indice de los array
                                //Cambiar tamaño array nombreStock
                                Array.Resize(ref stockNombre, stockNombre.Length + 1);
                                //Agregar nombre al array
                                for (int i = 0; i < stockNombre.Length; i++)
                                {
                                    if (string.IsNullOrEmpty(ventaNombres[i]))
                                    {

                                        stockNombre[i] = nombreProductoIngresado;
                                        indice = i;
                                    }
                                }
                                //Cambiar tamaño array stockDescripcion
                                Array.Resize(ref stockDescripcion, stockDescripcion.Length + 1);
                                //Agregar descripción al array
                                //for (int i = 0; i < stockDescripcion.Length; i++)
                                {
                                    //if(string.IsNullOrEmpty(ventaNombres[i]))
                                    {

                                        //stockDescripcion[i] = descripcionProductoIngresado;
                                        stockDescripcion[indice] = descripcionProductoIngresado;
                                    }

                                }
                                //Cambiar tamaño array stockCantidades
                                Array.Resize(ref stockCantidades, stockCantidades.Length + 1);
                                //Agregar cantidad al array
                                //for (int i = 0; i < stockCantidades.Length; i++)
                                {
                                    //if(stockCantidades[i] == 0)
                                    {

                                        //stockCantidades[i] = cantidadProductoIngresado;
                                        stockCantidades[indice] = cantidadProductoIngresado;

                                    }
                                }
                                //Cambiar tamaño del array stockPrecios
                                Array.Resize(ref stockPrecios, stockPrecios.Length + 1);
                                //Agregar precio al array
                                //for (int i = 0; i < stockPrecios.Length; i++)
                                {
                                    //if(stockPrecios[i] == 0)
                                    {

                                        //stockPrecios[i] = precioProductoIngresado;
                                        stockPrecios[indice] = precioProductoIngresado;
                                    }
                                }

                            }
                            else
                            {//Si hay elementos null/empty

                                //Agregar nombre al array
                                //for (int i = 0; i < stockNombre.Length; i++)
                                {
                                    //if(string.IsNullOrEmpty(ventaNombres[i]))
                                    {
                                        //stockNombre[i] = nombreProductoIngresado;
                                        //break;
                                        stockNombre[indice] = nombreProductoIngresado;
                                    }
                                }
                                //Agregar descripción al array
                                //for (int i = 0; i < stockDescripcion.Length; i++)
                                {
                                    //if(string.IsNullOrEmpty(ventaNombres[i]))
                                    {
                                        //stockDescripcion[i] = descripcionProductoIngresado;
                                        //break;
                                        stockDescripcion[indice] = descripcionProductoIngresado;
                                    }

                                }
                                //Agregar cantidad al array
                                //for (int i = 0; i < stockCantidades.Length; i++)
                                {
                                    //if(stockCantidades[i] == 0)
                                    {
                                        //stockCantidades[i] = cantidadProductoIngresado;
                                        //break;
                                        stockCantidades[indice] = cantidadProductoIngresado;

                                    }
                                }
                                //Agregar precio al array
                                //for (int i = 0; i < stockPrecios.Length; i++)
                                {
                                    //if(stockPrecios[i] == 0)
                                    {
                                        //stockPrecios[i] = precioProductoIngresado;
                                        //break;
                                        stockCantidades[indice] = cantidadProductoIngresado;
                                    }
                                }
                            }

                            //Continuar
                            sn = validarSN("Ingresar otro producto (s/n)");

                            if (sn == "n")
                            {
                                continuar = false;
                            }

                            Console.Clear();

                        } while (continuar);

                        break;

                    case 2:

                        Console.Clear();
                        titulo();

                        //Mostrar Stock
                        mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                        sn = validarSN("\nPara modificar presione s. Para volver al menu principal presione n");

                        if (sn == "s")
                        {

                            Console.Clear();
                            titulo();

                            //Mostrar Stock
                            mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                            //Modificar
                            do
                            {
                                indice = -1;

                                Console.Clear();
                                titulo();
                                mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                //Selección de producto
                                indice = seleccionarProducto("Escriba nombre del producto a modificar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                //Validación de producto

                                while (indice == -1)
                                {
                                    Console.Clear();
                                    titulo();
                                    mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                                    Console.WriteLine("Producto no encontrado.");
                                    indice = seleccionarProducto("Escriba nombre del producto a modificar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                }

                                //Modificación                   
                                modificarProducto(indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                //Salir
                                sn = validarSN("¿Desea modificar otro producto? (s/n)");
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
                        titulo();

                        //Mostrar Stock
                        mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                        sn = validarSN("\nPara borrar presione s. Para volver al menu principal presione n");

                        if (sn == "s")
                        {

                            //Borrar
                            do
                            {
                                indice = -1;
                                int indiceNuevo = 0;

                                Console.Clear();
                                titulo();
                                mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                //Selección de producto
                                indice = seleccionarProducto("Escriba nombre del producto a borrar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                //Validación de producto

                                while (indice == -1)
                                {
                                    Console.Clear();
                                    titulo();
                                    mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                                    Console.WriteLine("Producto no encontrado.");
                                    indice = seleccionarProducto("Escriba nombre del producto a borrar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                }

                                Console.Clear();
                                titulo();

                                //Confirmar producto a borrar
                                Console.WriteLine($"\nProducto a borrar:\n\nNombre: {stockNombre[indice]}\nDescripción: {stockDescripcion[indice]}\nCantidad: {stockCantidades[indice]}\nPrecio: {stockPrecios[indice]}");

                                //Validacion de producto a borrar
                                sn = validarSN("\nSi es correcto presione s. De lo contrario presione n");

                                if (sn == "n")//Cambio de producto
                                {
                                    do
                                    {
                                        Console.Clear();
                                        titulo();
                                        mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                                        indiceNuevo = seleccionarProducto("Escriba nombre del producto a borrar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                        //Confirmar producto a borrar
                                        Console.WriteLine($"Producto a borrar:\n\nNombre: {stockNombre[indiceNuevo]}\nDescripción: {stockDescripcion[indiceNuevo]}\nCantidades: {stockCantidades[indiceNuevo]}\nPrecio: {stockPrecios[indiceNuevo]}");

                                        //Continuar
                                        sn = validarSN("Si es correcto presione s. De lo contrario presione n");
                                        if (sn == "s")
                                        {
                                            continuar = false;
                                        }

                                    } while (continuar);

                                    continuar = true;//reseteo de variable

                                    //Borrar
                                    stockNombre[indiceNuevo] = "";
                                    stockDescripcion[indiceNuevo] = "";
                                    stockCantidades[indiceNuevo] = 0;
                                    stockPrecios[indiceNuevo] = 0;

                                    Console.Clear();
                                    titulo();
                                    Console.WriteLine("Producto borrado. Precione una tecla para continuar");

                                }
                                else
                                {//Sin cambio de producto

                                    //Borrar
                                    stockNombre[indice] = "";
                                    stockDescripcion[indice] = "";
                                    stockCantidades[indice] = 0;
                                    stockPrecios[indice] = 0;

                                    Console.Clear();
                                    titulo();
                                    Console.WriteLine("Producto borrado. Precione una tecla para continuar");
                                }

                                //Salir
                                sn = validarSN("¿Desea borrar otro producto? (s/n)");
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

                    case 4:

                        do
                        {
                            Console.Clear();
                            titulo();

                            //Productos en venta
                            Console.WriteLine("Productos disponibles:\n");
                            for (int i = 0; i < stockCantidades.Length; i++)
                            {
                                if (stockCantidades[i] != 0)
                                {

                                    Console.WriteLine($"{stockNombre[i]}");
                                }
                            }

                            do
                            {
                                //Seleccionar producto a vender
                                indice = -1;

                                Console.Clear();
                                titulo();
                                for (int i = 0; i < stockCantidades.Length; i++)
                                {
                                    if (stockCantidades[i] != 0)
                                    {

                                        Console.WriteLine($"{stockNombre[i]}");
                                    }
                                }
                                indice = seleccionarProducto("\nEscriba nombre de producto: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                //Validación de producto                                
                                while (indice == -1)
                                {
                                    Console.Clear();
                                    titulo();
                                    Console.WriteLine("Producto no encontrado. Seleccionar alguno de los siguientes:\n");
                                    for (int i = 0; i < stockCantidades.Length; i++)
                                    {
                                        if (stockCantidades[i] != 0)
                                        {

                                            Console.WriteLine($"{stockNombre[i]}");
                                        }
                                    }
                                    indice = seleccionarProducto("\nEscriba nombre del producto a vender: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                                }

                                //Seleccionar cantidades
                                cantidadVenta = validarPrecioCantidad("Ingrese cantidad a vender: ");

                                //Validar cantidades
                                while (stockCantidades[indice] - cantidadVenta < 0)
                                {
                                    Console.WriteLine($"No hay stock suficiente para realizar la venta. El stock actual es: {stockCantidades[indice]}");
                                    cantidadVenta = validarPrecioCantidad("Ingrese nueva cantidad: ");
                                }

                                //Acumulado en venta
                                //Nombre
                                for (int i = 0; i < ventaNombres.Length; i++)
                                {
                                    if (string.IsNullOrEmpty(ventaNombres[i]))
                                    {
                                        ventaNombres[i] = stockNombre[indice];
                                        break;
                                    }
                                }
                                //Cantidades
                                acumuladoCantidades[indice] += cantidadVenta;//Acumulado cantidades
                                for (int i = 0; i < stockCantidades.Length; i++)
                                {
                                    if (ventaCantidades[i] == 0)
                                    {
                                        ventaCantidades[i] = cantidadVenta;
                                        break;

                                    }
                                }
                                stockCantidades[indice] -= cantidadVenta;//Restar cantidad en stock
                                //Precios
                                precioVenta = stockPrecios[indice] * cantidadVenta;
                                for (int i = 0; i < stockPrecios.Length; i++)
                                {
                                    if (ventaPrecios[i] == 0)
                                    {
                                        ventaPrecios[i] = precioVenta;
                                        break;

                                    }
                                }
                                totalVenta += precioVenta;

                                //Confirmación de producto
                                Console.Clear();
                                titulo();
                                Console.WriteLine("Va a realizar la venta de los siguientes productos: ");
                                for (int i = 0; i < ventaNombres.Length; i++)
                                {
                                    if (!string.IsNullOrEmpty(ventaNombres[i]))
                                    {
                                        Console.WriteLine($"{ventaNombres[i]}");
                                    }
                                }

                                sn = validarSN("\nPersione s para continuar. Presione n para agregar otro producto");

                                //Continuar
                                if (sn == "s")
                                {

                                    continuar = false;
                                }

                            } while (continuar);

                            continuar = true;//reseteo de variable      

                            Console.Clear();
                            titulo();
                            Console.WriteLine("Detalle de la venta:\n\n ");
                            for (int i = 0; i < ventaNombres.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(ventaNombres[i]))
                                {
                                    Console.Write($"{i + 1}. Nombre del Producto: {ventaNombres[i]}\nCantidad Vendida: {ventaCantidades[i]}Kgs\nCantidad a pagar: ${ventaPrecios[i]}\n");
                                }
                            }
                            Console.Write($"\nValor total: ${totalVenta}\n\n\n");
                            totalRecaudado += totalVenta;//Acumulado de recaudación

                            //Salir
                            sn = validarSN("Presione s para volver al menu principal o n para seguir vendiendo");
                            if (sn == "s")
                            {
                                continuar = false;
                            }
                        } while (continuar);

                        break;

                    case 5:

                        do
                        {
                            Console.Clear();
                            titulo();
                            Console.WriteLine("Elegir opción:\n\n1. Ver resumen de productos vendidos\n2. Ver total recaudado\n");
                            opcionElegida = validarOpcion("Opción elegida", 1, 2);

                            switch (opcionElegida)
                            {
                                case 1:

                                    Console.Clear();
                                    titulo();
                                    Console.WriteLine($"Resumen de productos vendidos:\n");
                                    for (int i = 0; i < stockNombre.Length; i++)
                                    {
                                        if (acumuladoCantidades[i] != 0)
                                        {

                                            Console.WriteLine($"Producto: {stockNombre[i]}\nCantidad vendida: {acumuladoCantidades[i]}Kgs");
                                            Console.WriteLine("--------------------");
                                        }
                                    }

                                    //Salir
                                    sn = validarSN("\n\n\nPresione s para volver al menu anterior o n para volver al menu principal");
                                    if (sn == "n")
                                    {
                                        continuar = false;
                                    }

                                    break;

                                case 2:

                                    Console.Clear();
                                    titulo();
                                    Console.WriteLine("Recaudación diaria:\n");
                                    Console.WriteLine($"El día de hoy se vendieron un total de: ${totalRecaudado}");

                                    //Salir
                                    sn = validarSN("\n\n\nPresione s para volver al menu anterior o n para volver al menu principal");
                                    if (sn == "n")
                                    {
                                        continuar = false;
                                    }

                                    break;

                                default:
                                    break;
                            }

                        } while (continuar);


                        break;

                    case 6:

                        Console.Clear();
                        titulo();
                        //Confirmar salida del programa
                        sn = validarSN("Para salir persione s. Para volver al menu principal precione n");
                        if (sn == "s")
                        {
                            seguir = false;
                        }

                        break;

                    default:
                        break;
                }

            } while (seguir);

            Console.Clear();
            titulo();
            Console.Write("Gracias por utilizar nuestro sistema. Presione cualquier tecla para cerrar el programa");

            Console.ReadKey();
        }

        //Procedimientos de escritura
        static void titulo()
        {
            Console.WriteLine(".~~~~~~~~~~~~~~~~~~~.");
            Console.WriteLine("| Verdulería OnLine |");
            Console.WriteLine("'~~~~~~~~~~~~~~~~~~~'\n");
        }
        static void menuOpcionesPrincipal()
        {
            Console.WriteLine("Ingrese opción:\n\n1. Agregar producto al Stock\n2. Ver/Modificar Stock\n3. Borrar producto del Stock\n4. Realizar ventas\n5. Ver informe de ventas\n6. Salir\n");
        }
        static void mostrarStock(string[] stockNombre, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios)
        {
            Console.WriteLine("Productos en Stock:");
            for (int i = 0; i < stockNombre.Length; i++)
            {
                if (!string.IsNullOrEmpty(stockNombre[i]))
                {

                    Console.WriteLine($"\nNombre: {stockNombre[i]}\nDescripción: {stockDescripcion[i]}\nCantidad: {stockCantidades[i]}Kgs\nPrecio: ${stockPrecios[i]}xKg");
                    Console.WriteLine("--------------------");

                }
            }
        }

        //Procedimientos de validación
        static int validarOpcion(string mensaje, int min, int max)
        {

            Console.WriteLine(mensaje);

            int aux;

            while (!int.TryParse(Console.ReadLine(), out aux) || aux < min || aux > max)
            {
                Console.Clear();
                titulo();
                menuOpcionesPrincipal();
                Console.WriteLine("Error, reingresar un valor correcto");
            }

            return aux;

        }
        static string validarNombre(string mensaje, string[] stockNombre)
        {

            Console.Write(mensaje);
            string nombre = Console.ReadLine();

            for (int i = 0; i < stockNombre.Length; i++)
            {
                while (stockNombre[i].ToLower().Trim().Contains(nombre.ToLower().Trim()))
                {

                    Console.WriteLine("El nombre del producto ya se encuentra en stock. Por favor, elija otro nombre");
                    nombre = Console.ReadLine();
                }

            }

            return nombre;
        }
        static float validarPrecioCantidad(string mensaje)
        {

            Console.Write(mensaje);
            float aux;
            bool aux1 = float.TryParse(Console.ReadLine(), out aux);

            while (aux1 == false)
            {

                Console.WriteLine("Valor no permitido. Ingrese un nuevo valor: ");
                aux1 = float.TryParse(Console.ReadLine(), out aux);

            }

            string cantidadDecimales = aux.ToString();

            if (cantidadDecimales.Contains(","))
            {
                int offset = cantidadDecimales.IndexOf(",");
                string suffix = cantidadDecimales.Substring(offset + 1);
                Console.WriteLine(aux);

                while (suffix.Length > 3)
                {

                    Console.WriteLine("Valor no permitido. Ingrese un nuevo valor");
                    aux1 = float.TryParse(Console.ReadLine(), out aux);

                }
            }

            return aux;
        }
        static string validarSN(string mensaje)
        {

            Console.WriteLine(mensaje);

            string aux = Console.ReadLine().ToLower();

            while (aux != "s" && aux != "n")
            {
                Console.WriteLine("Debe ingresar s o n");
                aux = Console.ReadLine();
            }

            return aux;
        }

        //Procedimientos de implementación
        static int seleccionarProducto(string mensaje, int indice, string[] stockNombre, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios)
        {

            Console.Write(mensaje);
            string nombre = Console.ReadLine().ToLower().Trim();
            nombre = nombre.Replace(" ", String.Empty);


            for (int i = 0; i < stockNombre.Length; i++)
            {
                if (stockNombre[i].ToLower().Trim().Replace(" ", String.Empty).Contains(nombre))
                {

                    indice = i;
                    break;
                }
            }

            return indice;
        }
        static void modificarProducto(int indice, string[] stockNombre, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios)
        {

            string sn = "";
            int indiceNuevo = 0;
            int opcion;
            string nombre = "";
            string descripcion = "";
            float cantidad = 0;
            float precio = 0;

            Console.Clear();
            titulo();
            Console.WriteLine($"\nProducto a modificar:\n\nNombre: {stockNombre[indice]}\nDescripción: {stockDescripcion[indice]}\nCantidad: {stockCantidades[indice]}\nPrecio: {stockPrecios[indice]}");

            //Validación de producto a modificar
            sn = validarSN("\nSi es correcto presione s. De lo contrario presione n");

            if (sn == "n")//Cambio de producto
            {
                bool continuar = true;
                do
                {
                    Console.Clear();
                    titulo();
                    mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                    indiceNuevo = seleccionarProducto("Escriba nombre del producto a modificar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                    Console.WriteLine($"Producto a modificar:\n\nNombre: {stockNombre[indiceNuevo]}\nDescripción: {stockDescripcion[indiceNuevo]}\nCantidades: {stockCantidades[indiceNuevo]}\nPrecio: {stockPrecios[indiceNuevo]}");
                    sn = validarSN("Si es correcto presione s. De lo contrario presione n");
                    if (sn == "s")
                    {
                        continuar = false;
                    }

                } while (continuar);

                //Modificación
                Console.Clear();
                titulo();
                opcion = validarOpcion("Elija el dato que quiere modificar:\n\n1. Nombre\n2. Descripcion\n3. Cantidad\n4. Precio", 1, 4);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"Nombre Actual: {stockNombre[indiceNuevo]}");
                        nombre = validarNombre("Nuevo Nombre: ", stockNombre);
                        stockNombre[indiceNuevo] = nombre;
                        break;
                    case 2:
                        Console.WriteLine($"Descripción Actual: {stockDescripcion[indiceNuevo]}");
                        Console.Write("Nueva descripcion: ");
                        descripcion = Console.ReadLine();
                        stockDescripcion[indiceNuevo] = descripcion;
                        break;
                    case 3:
                        Console.WriteLine($"Cantidad Actual: {stockCantidades[indiceNuevo]}");
                        cantidad = validarPrecioCantidad("Nueva cantidad: ");
                        stockCantidades[indiceNuevo] = cantidad;
                        break;
                    case 4:
                        Console.WriteLine($"Precio Actual: {stockPrecios[indiceNuevo]}");
                        precio = validarPrecioCantidad("Nuevo precio: ");
                        stockPrecios[indiceNuevo] = precio;
                        break;
                    default:
                        break;
                }
                //Volver
                Console.Clear();
                titulo();
                Console.WriteLine("Producto modificado. Precione una tecla para volver al menu principal");

            }
            else
            {//Sin cambio de producto

                //Modificación
                Console.Clear();
                titulo();
                opcion = validarOpcion("Elija el dato que quiere modificar:\n\n1. Nombre\n2. Descripcion\n3. Cantidad\n4. Precio", 1, 4);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"Nombre Actual: {stockNombre[indice]}");
                        nombre = validarNombre("Nuevo Nombre: ", stockNombre);
                        stockNombre[indice] = nombre;
                        break;
                    case 2:
                        Console.WriteLine($"Descripción Actual: {stockDescripcion[indice]}");
                        Console.Write("Nueva descripcion: ");
                        descripcion = Console.ReadLine();
                        stockDescripcion[indice] = descripcion;
                        break;
                    case 3:
                        Console.WriteLine($"Cantidad Actual: {stockCantidades[indice]}");
                        cantidad = validarPrecioCantidad("Nueva cantidad: ");
                        stockCantidades[indice] = cantidad;
                        break;
                    case 4:
                        Console.WriteLine($"Precio Actual: {stockPrecios[indice]}");
                        precio = validarPrecioCantidad("Nuevo precio: ");
                        stockPrecios[indice] = precio;
                        break;
                    default:
                        break;
                }

                //Volver
                Console.Clear();
                titulo();
                Console.WriteLine("Producto modificado. Precione una tecla para volver al menu principal");
            }
        }
    }
}
