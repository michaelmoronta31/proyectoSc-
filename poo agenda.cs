using System;
using System.Collections.Generic;

class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }

    public void Mostrar()
    {
        Console.WriteLine($"ID: {Id} / Nombre: {Nombre} / Teléfono: {Telefono} / Email: {Email} / Dirección: {Direccion}");
    }
}

class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();
    private int contadorId = 1;

    public void AggContacto()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        contactos.Add(new Contacto(contadorId++, nombre, telefono, email, direccion));
        Console.WriteLine("Contacto agregado con éxito.\n");
    }

    public void VerContactos()
    {
        Console.WriteLine("\nLista de contactos:");
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos.");
        }
        else
        {
            foreach (var contacto in contactos)
            {
                contacto.Mostrar();
            }
        }
        Console.WriteLine();
    }

    public void Buscar_Contacto()
    {
        Console.Write("Ingrese ID del contacto a buscar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contacto = contactos.Find(c => c.Id == id);
            if (contacto != null)
            {
                contacto.Mostrar();
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
        Console.WriteLine();
    }

    public void EditarContacto()
    {
        Console.Write("Ingrese ID del contacto a editar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contacto = contactos.Find(c => c.Id == id);
            if (contacto != null)
            {
                Console.Write($"Nuevo nombre ({contacto.Nombre}): ");
                contacto.Nombre = Console.ReadLine();
                Console.Write($"Nuevo teléfono ({contacto.Telefono}): ");
                contacto.Telefono = Console.ReadLine();
                Console.Write($"Nuevo email ({contacto.Email}): ");
                contacto.Email = Console.ReadLine();
                Console.Write($"Nueva dirección ({contacto.Direccion}): ");
                contacto.Direccion = Console.ReadLine();
                Console.WriteLine("Contacto actualizado con éxito.\n");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.\n");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.\n");
        }
    }

    public void EliminarContacto()
    {
        Console.Write("Ingrese ID del contacto a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var contacto = contactos.Find(c => c.Id == id);
            if (contacto != null)
            {
                contactos.Remove(contacto);
                Console.WriteLine("Contacto eliminado con éxito.\n");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.\n");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();
        bool corriendo = true;

        while (corriendo)
        {
            Console.WriteLine("Mi Agenda Perrón");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Modificar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        agenda.AggContacto();
                        break;
                    case 2:
                        agenda.VerContactos();
                        break;
                    case 3:
                        agenda.Buscar_Contacto();
                        break;
                    case 4:
                        agenda.EditarContacto();
                        break;
                    case 5:
                        agenda.EliminarContacto();
                        break;
                    case 6:
                        corriendo = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
        }
    }
}
