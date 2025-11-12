using System;

namespace SistemaDeVentas
{
    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public double Subtotal
        {
            get { return Cantidad * PrecioUnitario; }
        }

        public void MostrarProducto()
        {
            Console.WriteLine($"Nombre: {Nombre} | Cantidad: {Cantidad} | Precio: S/.{PrecioUnitario:F2} | Subtotal: S/.{Subtotal:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Producto[] productos = new Producto[5];
            int contador = 0;
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE VENTAS ===");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Listar productos y total general");
                Console.WriteLine("3. Buscar producto por nombre");
                Console.WriteLine("4. Modificar precio de un producto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        if (contador < productos.Length)
                        {
                            productos[contador] = new Producto();

                            Console.Write("Ingrese nombre del producto: ");
                            productos[contador].Nombre = Console.ReadLine();

                            Console.Write("Ingrese cantidad vendida: ");
                            productos[contador].Cantidad = int.Parse(Console.ReadLine());

                            Console.Write("Ingrese precio unitario: ");
                            productos[contador].PrecioUnitario = double.Parse(Console.ReadLine());

                            contador++;
                            Console.WriteLine("\nProducto registrado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Ya se han registrado los 5 productos permitidos.");
                        }
                        break;

                    case 2:
                        double total = 0;
                        Console.WriteLine("=== LISTA DE PRODUCTOS ===");
                        for (int i = 0; i < contador; i++)
                        {
                            productos[i].MostrarProducto();
                            total += productos[i].Subtotal;
                        }
                        Console.WriteLine($"\nTOTAL GENERAL: S/.{total:F2}");
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre del producto a buscar: ");
                        string nombreBuscado = Console.ReadLine();
                        bool encontrado = false;
                        for (int i = 0; i < contador; i++)
                        {
                            if (productos[i].Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                            {
                                productos[i].MostrarProducto();
                                encontrado = true;
                                break;
                            }
                        }
                        if (!encontrado)
                            Console.WriteLine("Producto no encontrado.");
                        break;

                    case 4:
                        Console.Write("Ingrese el nombre del producto a modificar: ");
                        string nombreModificar = Console.ReadLine();
                        bool modificado = false;
                        for (int i = 0; i < contador; i++)
                        {
                            if (productos[i].Nombre.Equals(nombreModificar, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Ingrese el nuevo precio unitario: ");
                                productos[i].PrecioUnitario = double.Parse(Console.ReadLine());
                                Console.WriteLine("Precio actualizado correctamente.");
                                modificado = true;
                                break;
                            }
                        }
                        if (!modificado)
                            Console.WriteLine("Producto no encontrado.");
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 5);
        }
    }
}
