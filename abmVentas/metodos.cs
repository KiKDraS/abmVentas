using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abmVentas
{
    public static class Metodos
    {
        //Procedimientos de escritura
        public static void titulo()
        {
            Console.WriteLine(".~~~~~~~~~~~~~~~~~~~.");
            Console.WriteLine("| Verdulería OnLine |");
            Console.WriteLine("'~~~~~~~~~~~~~~~~~~~'\n");
        }
        public static void menuOpcionesPrincipal()
        {
            Console.WriteLine("Ingrese opción:\n\n1. Agregar producto al Stock\n2. Ver/Modificar Stock\n3. Borrar producto del Stock\n4. Realizar ventas\n5. Ver informe de ventas\n6. Salir\n");
        }
        public static void mostrarStock(string[] stockNombre, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios)
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
        public static int validarOpcion(string mensaje, int min, int max)
        {
            Console.Write(mensaje);

            int aux;

            while (!int.TryParse(Console.ReadLine(), out aux) || aux < min || aux > max)
            {
                Console.Clear();
                Metodos.titulo();
                Metodos.menuOpcionesPrincipal();
                Console.WriteLine("Error, reingresar un valor correcto");
            }

            return aux;

        }
        public static string validarNombre(string mensaje, string[] stockNombre)
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
        public static float validarPrecioCantidad(string mensaje)
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

                while (suffix.Length > 3)
                {

                    Console.WriteLine("Valor no permitido. Ingrese un nuevo valor");
                    aux1 = float.TryParse(Console.ReadLine(), out aux);

                }
            }

            return aux;
        }
        public static string validarSN(string mensaje)
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
        public static void cargarProducto(string nombreProductoIngresado, string[] stockNombre, string descripcionProductoIngresado, float cantidadProductoIngresado, float precioProductoIngresado, string sn, bool continuar, int indice, int cantidadProductosStock, float[] acumuladoCantidades, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios)
        {
            do
            {
                Console.Clear();
                Metodos.titulo();

                //Carga de datos
                Console.WriteLine("Agregar producto\n\n");
                Console.WriteLine("Complete los siguientes datos:\n");
                nombreProductoIngresado = Metodos.validarNombre("Ingrese nombre del producto: ", stockNombre);
                Console.Write("Ingrese descripción del producto: ");
                descripcionProductoIngresado = Console.ReadLine();
                cantidadProductoIngresado = Metodos.validarPrecioCantidad("Ingrese cantidad del producto (máximo 3 decimales. Use coma para separar los decimales): ");
                precioProductoIngresado = Metodos.validarPrecioCantidad("Ingrese precio del producto (máximo 3 decimales. Use coma para separar los decimales): ");

                //Confirmación de carga
                Console.Clear();
                Metodos.titulo();

                Console.WriteLine($"Detalle de producto ingresado:\n\nNombre: {nombreProductoIngresado}\nDescripción: {descripcionProductoIngresado}\nCantidad: {cantidadProductoIngresado}Kgs\nPrecio: ${precioProductoIngresado}xKg");

                sn = Metodos.validarSN("Si es correcto precione s. Para modificar presione n");
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

            if (indice == -1)//Si no hay elementos null/empty
            {
                cantidadProductosStock++;//Modificar indice de los array

                //Cambiar tamaño array nombreStock 
                Array.Resize(ref stockNombre, stockNombre.Length + 1);
                //Cambiar tamaño del acumuladoCantidades para recorrerlo en la impresión de acumulados
                Array.Resize(ref acumuladoCantidades, acumuladoCantidades.Length + 1);

                //Agregar nombre al array
                for (int i = 0; i < stockNombre.Length; i++)
                {
                    if (string.IsNullOrEmpty(stockNombre[i]))
                    {
                        stockNombre[i] = nombreProductoIngresado;
                        indice = i;
                    }
                }

                //Cambiar tamaño array stockDescripcion
                Array.Resize(ref stockDescripcion, stockDescripcion.Length + 1);

                //Agregar descripción al array
                stockDescripcion[indice] = descripcionProductoIngresado;

                //Cambiar tamaño array stockCantidades
                Array.Resize(ref stockCantidades, stockCantidades.Length + 1);

                //Agregar cantidad al array
                stockCantidades[indice] = cantidadProductoIngresado;

                //Cambiar tamaño del array stockPrecios y ventaPrecios
                Array.Resize(ref stockPrecios, stockPrecios.Length + 1);

                //Agregar precio al array
                stockPrecios[indice] = precioProductoIngresado;

            }
            else //Si hay elementos null/empty
            {

                //Agregar nombre al array                                
                stockNombre[indice] = nombreProductoIngresado;

                //Agregar descripción al array
                stockDescripcion[indice] = descripcionProductoIngresado;

                //Agregar cantidad al array
                stockCantidades[indice] = cantidadProductoIngresado;

                //Agregar precio al array
                stockCantidades[indice] = cantidadProductoIngresado;

            }
        }
        public static int seleccionarProducto(string mensaje, int indice, string[] stockNombre, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios)
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
        public static void modificarProducto(int indice, string[] stockNombre, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios)
        {

            string sn = "";
            int indiceNuevo = 0;
            int opcion;
            string nombre = "";
            string descripcion = "";
            float cantidad = 0;
            float precio = 0;

            indice = -1;

            Console.Clear();
            Metodos.titulo();
            Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);

            //Selección de producto
            indice = Metodos.seleccionarProducto("Escriba nombre del producto a modificar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

            //Validación de producto

            while (indice == -1)
            {
                Console.Clear();
                Metodos.titulo();
                Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                Console.WriteLine("Producto no encontrado.");
                indice = Metodos.seleccionarProducto("Escriba nombre del producto a modificar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

            }

            Console.Clear();
            Metodos.titulo();
            Console.WriteLine($"\nProducto a modificar:\n\nNombre: {stockNombre[indice]}\nDescripción: {stockDescripcion[indice]}\nCantidad: {stockCantidades[indice]}\nPrecio: {stockPrecios[indice]}");

            //Validación de producto a modificar
            sn = Metodos.validarSN("\nSi es correcto presione s. De lo contrario presione n");

            if (sn == "n")//Cambio de producto
            {
                bool continuar = true;
                do
                {
                    Console.Clear();
                    Metodos.titulo();
                    Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                    indiceNuevo = Metodos.seleccionarProducto("Escriba nombre del producto a modificar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                    Console.WriteLine($"Producto a modificar:\n\nNombre: {stockNombre[indiceNuevo]}\nDescripción: {stockDescripcion[indiceNuevo]}\nCantidades: {stockCantidades[indiceNuevo]}\nPrecio: {stockPrecios[indiceNuevo]}");
                    sn = Metodos.validarSN("Si es correcto presione s. De lo contrario presione n");
                    if (sn == "s")
                    {
                        continuar = false;
                    }

                } while (continuar);

                //Modificación
                Console.Clear();
                Metodos.titulo();
                opcion = Metodos.validarOpcion("Elija el dato que quiere modificar:\n\n1. Nombre\n2. Descripcion\n3. Cantidad\n4. Precio\n\n\n", 1, 4);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"Nombre Actual: {stockNombre[indiceNuevo]}");
                        nombre = Metodos.validarNombre("Nuevo Nombre: ", stockNombre);
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
                        cantidad = Metodos.validarPrecioCantidad("Nueva cantidad: ");
                        stockCantidades[indiceNuevo] = cantidad;
                        break;
                    case 4:
                        Console.WriteLine($"Precio Actual: {stockPrecios[indiceNuevo]}");
                        precio = Metodos.validarPrecioCantidad("Nuevo precio: ");
                        stockPrecios[indiceNuevo] = precio;
                        break;
                    default:
                        break;
                }
                //Volver
                Console.Clear();
                Metodos.titulo();
                Console.WriteLine("Producto modificado. Precione una tecla para volver al menu principal");

            }
            else //Sin cambio de producto
            {
                //Modificación
                Console.Clear();
                Metodos.titulo();
                opcion = Metodos.validarOpcion("Elija el dato que quiere modificar:\n\n1. Nombre\n2. Descripcion\n3. Cantidad\n4. Precio", 1, 4);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"Nombre Actual: {stockNombre[indice]}");
                        nombre = Metodos.validarNombre("Nuevo Nombre: ", stockNombre);
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
                        cantidad = Metodos.validarPrecioCantidad("Nueva cantidad: ");
                        stockCantidades[indice] = cantidad;
                        break;
                    case 4:
                        Console.WriteLine($"Precio Actual: {stockPrecios[indice]}");
                        precio = Metodos.validarPrecioCantidad("Nuevo precio: ");
                        stockPrecios[indice] = precio;
                        break;
                    default:
                        break;
                }

                //Volver
                Console.Clear();
                Metodos.titulo();
                Console.WriteLine("Producto modificado. Precione una tecla para volver al menu principal");
            }
        }
        public static void borrarProducto(int indice, string[] stockNombre, string[] stockDescripcion, float[] stockCantidades, float[] stockPrecios, string sn, bool continuar)
        {
            do
            {
                indice = -1;
                int indiceNuevo = 0;

                Console.Clear();
                Metodos.titulo();
                Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                //Selección de producto
                indice = Metodos.seleccionarProducto("Escriba nombre del producto a borrar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                //Validación de producto

                while (indice == -1)
                {
                    Console.Clear();
                    Metodos.titulo();
                    Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                    Console.WriteLine("Producto no encontrado.");
                    indice = Metodos.seleccionarProducto("Escriba nombre del producto a borrar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                }

                Console.Clear();
                Metodos.titulo();

                //Confirmar producto a borrar
                Console.WriteLine($"\nProducto a borrar:\n\nNombre: {stockNombre[indice]}\nDescripción: {stockDescripcion[indice]}\nCantidad: {stockCantidades[indice]}\nPrecio: {stockPrecios[indice]}");

                //Validacion de producto a borrar
                sn = Metodos.validarSN("\nSi es correcto presione s. De lo contrario presione n");

                if (sn == "n")//Cambio de producto
                {
                    do
                    {
                        Console.Clear();
                        Metodos.titulo();
                        Metodos.mostrarStock(stockNombre, stockDescripcion, stockCantidades, stockPrecios);
                        indiceNuevo = Metodos.seleccionarProducto("Escriba nombre del producto a borrar: ", indice, stockNombre, stockDescripcion, stockCantidades, stockPrecios);

                        //Confirmar producto a borrar
                        Console.WriteLine($"Producto a borrar:\n\nNombre: {stockNombre[indiceNuevo]}\nDescripción: {stockDescripcion[indiceNuevo]}\nCantidades: {stockCantidades[indiceNuevo]}\nPrecio: {stockPrecios[indiceNuevo]}");

                        //Continuar
                        sn = Metodos.validarSN("Si es correcto presione s. De lo contrario presione n");
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
                    Metodos.titulo();
                    Console.WriteLine("Producto borrado. Precione una tecla para continuar");

                }
                else //Sin cambio de producto
                {
                    //Borrar
                    stockNombre[indice] = "";
                    stockDescripcion[indice] = "";
                    stockCantidades[indice] = 0;
                    stockPrecios[indice] = 0;

                    Console.Clear();
                    Metodos.titulo();
                    Console.WriteLine("Producto borrado. Precione una tecla para continuar");
                }

                //Salir
                sn = Metodos.validarSN("¿Desea borrar otro producto? (s/n)");
                if (sn == "n")
                {
                    continuar = false;
                }

            } while (continuar);

            Console.Clear();
        }
        public static void ventaProducto(int indice, float[] stockCantidades, string[] stockNombre, float cantidadVenta, int cantidadVentas, string[] ventaNombres, float[] acumuladoCantidades, float[] ventaCantidades, float precioVenta, float[] stockPrecios, float[] ventaPrecios, float totalVenta, string sn, bool continuar, float totalRecaudado)
        {
            do
            {
                //Seleccionar producto a vender
                indice = -1;
                int aux = -1;

                Console.Clear();
                Metodos.titulo();
                for (int i = 0; i < stockCantidades.Length; i++)
                {
                    if (stockCantidades[i] != 0)
                    {
                        Console.WriteLine($"{i}) {stockNombre[i]}");
                        aux = i;
                    }
                }
                indice = Metodos.validarOpcion("\nIndique número del producto: ", 0, aux);

                //Validación de producto                        
                while (indice == -1)
                {
                    Console.Clear();
                    Metodos.titulo();
                    Console.WriteLine("Producto no encontrado. Seleccionar alguno de los siguientes:\n");
                    for (int i = 0; i < stockCantidades.Length; i++)
                    {
                        if (stockCantidades[i] != 0)
                        {
                            Console.WriteLine($"{stockNombre[i]}");
                        }
                    }
                    indice = Metodos.validarOpcion("\nIndique número del producto: ", 0, aux);
                }

                //Seleccionar cantidades
                cantidadVenta = Metodos.validarPrecioCantidad("Ingrese cantidad a vender: ");

                //Validar cantidades
                while (stockCantidades[indice] - cantidadVenta < 0)
                {
                    Console.WriteLine($"No hay stock suficiente para realizar la venta. El stock actual es: {stockCantidades[indice]}");
                    cantidadVenta = Metodos.validarPrecioCantidad("Ingrese nueva cantidad: ");
                }

                //Acumulado en venta
                cantidadVentas++;
                int indiceVenta = -1;

                //Nombre
                Array.Resize(ref ventaNombres, ventaNombres.Length + 1);
                for (int i = 0; i < ventaNombres.Length; i++)
                {
                    if (string.IsNullOrEmpty(ventaNombres[i]))
                    {
                        ventaNombres[i] = stockNombre[indice];
                        indiceVenta = i;
                        break;
                    }
                }

                //Cantidades
                for (int i = 0; i < acumuladoCantidades.Length; i++)
                {
                    if (acumuladoCantidades[i] == 0)
                    {
                        acumuladoCantidades[indiceVenta] += cantidadVenta;//Acumulado cantidades
                        break;
                    }
                }
                Array.Resize(ref ventaCantidades, ventaCantidades.Length + 1);
                for (int i = 0; i < ventaCantidades.Length; i++)
                {
                    if (ventaCantidades[i] == 0)
                    {
                        ventaCantidades[indiceVenta] = cantidadVenta;
                        break;
                    }
                }
                stockCantidades[indice] -= cantidadVenta;//Restar cantidad en stock

                //Precios
                precioVenta = stockPrecios[indice] * cantidadVenta;
                Array.Resize(ref ventaPrecios, ventaPrecios.Length + 1);
                for (int i = 0; i < ventaPrecios.Length; i++)
                {
                    if (ventaPrecios[i] == 0)
                    {
                        ventaPrecios[indiceVenta] = precioVenta;
                        break;
                    }
                }
                totalVenta += precioVenta;

                //Confirmación de venta
                Console.Clear();
                Metodos.titulo();
                Console.WriteLine("Va a realizar la venta de los siguientes productos: ");
                for (int i = 0; i < ventaNombres.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ventaNombres[i]))
                    {
                        Console.WriteLine($"{ventaNombres[i]}");
                    }
                }

                sn = Metodos.validarSN("\nPersione s para continuar. Presione n para agregar otro producto");

                //Continuar
                if (sn == "s")
                {
                    continuar = false;
                    Console.Clear();
                }

            } while (continuar);

            continuar = true;//reseteo de variable      

            Console.Clear();
            Metodos.titulo();
            Console.WriteLine("Detalle de la venta:\n\n ");
            for (int i = 0; i < ventaNombres.Length; i++)
            {
                if (!string.IsNullOrEmpty(ventaNombres[i]))
                {
                    Console.Write($"{i + 1}. Nombre del Producto: {ventaNombres[i]}\nCantidad Vendida: {ventaCantidades[i]}Kgs\nCantidad a pagar: ${ventaPrecios[i]}\n-----------------------------\n");
                }
            }
            Console.Write($"\nValor total: ${totalVenta}\n\n\n");
            totalRecaudado += totalVenta;//Acumulado de recaudación
        }
        public static void mostrarAcumulados(int opcionElegida, string[] stockNombre, float[] acumuladoCantidades, bool continuar, string sn, float totalRecaudado)
        {
            do
            {
                Console.Clear();
                Metodos.titulo();
                Console.WriteLine("Elegir opción:\n\n1. Ver resumen de productos vendidos\n2. Ver total recaudado\n3. Volver\n");
                opcionElegida = Metodos.validarOpcion("Opción elegida: ", 1, 3);

                switch (opcionElegida)
                {
                    case 1:

                        Console.Clear();
                        Metodos.titulo();
                        Console.WriteLine($"Resumen de productos vendidos:\n");
                        for (int i = 0; i < stockNombre.Length; i++)
                        {
                            if (acumuladoCantidades[i] != 0)
                            {
                                Console.WriteLine($"Producto: {stockNombre[i]}\nCantidad vendida: {acumuladoCantidades[i]}Kgs");
                                Console.WriteLine("--------------------");
                            }
                        }

                        continuar = true; //Reseteo de variable

                        //Salir
                        sn = Metodos.validarSN("\n\n\nPresione s para volver al menu anterior o n para volver al menu principal");
                        if (sn == "n")
                        {
                            continuar = false;
                            Console.Clear();
                        }

                        break;

                    case 2:

                        Console.Clear();
                        Metodos.titulo();
                        Console.WriteLine("Recaudación diaria:\n");
                        Console.WriteLine($"El día de hoy se vendieron un total de: ${totalRecaudado}");

                        continuar = true; //REseteo de variable

                        //Salir
                        sn = Metodos.validarSN("\n\n\nPresione s para volver al menu anterior o n para volver al menu principal");
                        if (sn == "n")
                        {
                            continuar = false;
                            Console.Clear();
                        }

                        break;
                    case 3:
                        continuar = false;
                        Console.Clear();
                        break;

                    default:
                        break;
                }

            } while (continuar);
        }
    }
}
