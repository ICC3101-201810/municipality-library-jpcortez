using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address("Calle1", 2, "Paine", "Santiago", null, 1950, 2, 2, true, true);
            Person persona = new Person("juanito", "perez", Convert.ToDateTime("03 / 03 / 1990"), null, "1", null, null);

            List<Address> direcciones = new List<Address>();
            List<Person> personas = new List<Person>();
            List<Car> autos = new List<Car>();
            direcciones.Add(address);
            Console.WriteLine("Bienvenido al Registro Civil.\n");
            INICIO:;
            Console.WriteLine("Elija una opción:\n\t1.-Crear Persona.\n\t2-Crear dirección.");

            if (int.Parse(Console.ReadLine()) == 1)
            {
                #region CREARPERSONAS;
                int n = 0;
                foreach (Address a in direcciones)
                {
                    n++;
                }
                if (n == 0)
                {
                    Console.WriteLine("No puede crear a un ciudadano si aún no hay direcciones creadas.\n");
                    goto INICIO;
                }
                else
                {
                    Person p1 = null;
                    Console.WriteLine("Ingrese primer nombre "); string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese apellido "); string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese fecha nacimiento (DD/MM/AAAA) "); string fn = Console.ReadLine();
                    Console.WriteLine("Igrese rut "); string rut = Console.ReadLine();
                    Console.WriteLine("Ingrese comuna que vive: "); string comuna = Console.ReadLine();
                    Console.WriteLine("Ingrese numero propiedad: "); int numero = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese calle que vive: "); string calle = Console.ReadLine();

                    foreach (Address ad in direcciones)
                    {
                        if (ad.Commune == comuna && ad.Number == numero && ad.Street == calle)
                        {
                            p1 = new Person(nombre, apellido, Convert.ToDateTime(fn), ad, rut, null, null);
                            personas.Add(p1);
                        }
                        else
                        {
                            Console.WriteLine("La dirección es errónea.\nVolviendo al menú principal.\n");
                            goto INICIO;
                        }
                    }
                    Console.WriteLine("Ingrese el rut de la madre");
                    foreach (Person person in personas)
                    {
                        if (person.Rut == Console.ReadLine())
                        {
                            Console.WriteLine("Ingrese el rut del padre");
                            foreach (Person person1 in personas)
                            {
                                if (person1.Rut == Console.ReadLine())
                                {
                                    p1.getAdopted(person, person1);
                                }

                            }
                        }
                    }
                }
                #endregion;
            }

            else if (int.Parse(Console.ReadLine()) == 2)
            {
                Address d1 = null;
                Console.WriteLine("Ingrese nombre de la calle: "); string calle = Console.ReadLine();

            }
        }
    }
}
