using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            personas.Add(persona);
            direcciones.Add(address);
            try
            {
                BinaryFormatter binf = new BinaryFormatter();
                FileStream fs = File.Open("personas.txt", FileMode.Open);
                personas = (List<Person>)binf.Deserialize(fs);
                BinaryFormatter binf1 = new BinaryFormatter();
                FileStream fs1 = File.Open("autos.txt", FileMode.Open);
                autos = (List<Car>)binf.Deserialize(fs1);
                BinaryFormatter binf2 = new BinaryFormatter();
                FileStream fs2 = File.Open("direcciones.txt", FileMode.Open);
                direcciones = (List<Address>)binf.Deserialize(fs2);
                fs.Close();
                fs1.Close();
                fs2.Close();
            }
            catch
            {

            }
            Console.WriteLine("Bienvenido al Registro Civil.\n");
            INICIO:;
            Console.WriteLine("Elija una opción:\n\t0.-Salir\n\t1.-Crear Persona.\n\t2-Crear dirección.\n\t3.-Crear auto.\n\t4.-Agregar banhos\n\t5.-Agregar dormitorios\n\t6.-Opciones para usted");
            int hola = int.Parse(Console.ReadLine());
            if (hola == 1)
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

            if (hola == 2)
            {
                #region CREARADDRESS;
                Address d1 = null;
                Console.WriteLine("Ingrese nombre de la calle: "); string calle = Console.ReadLine();
                Console.WriteLine("Ingrese numero "); int numero = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la comuna a la que pertenece "); string comuna = Console.ReadLine();
                Console.WriteLine("Ingrese ciudad a cual pertenece: "); string ciudad = Console.ReadLine();
                Console.WriteLine("Ingrese año construcción "); int año = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese cantidad de dormitorios "); int br = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese cantidad de baños "); int bñr = int.Parse(Console.ReadLine());
                Console.WriteLine("Tiene patio? "); string q = Console.ReadLine();
                Console.WriteLine("Tiene piscina? "); string q0 = Console.ReadLine();
                bool q1;
                bool q2;
                if (q == "si") { q1 = true; }
                else { q1 = false; }
                if (q0 == "si") { q2 = true; }
                else { q2 = false; }
                Console.WriteLine("Ingrese el rut del propietario: "); string rut = Console.ReadLine();
                foreach (Person p in personas)
                {
                    if (p.Rut == rut)
                    {
                        d1 = new Address(calle, numero, comuna, ciudad, p, año, br, bñr, q1, q2);
                        Console.WriteLine("Dirección creada satisfactoriamente.");
                    }
                    else
                    {
                        Console.WriteLine("El rut ingresado no es valido, que desea?\n1.-Dejarlo vacio\n2.-Asignar de nuevo");
                        string aa = Console.ReadLine();
                        while (aa == "2")
                        {
                            Console.WriteLine("Ingrese un rut valido: ");
                            foreach (Person qw in personas)
                            {
                                if (qw.Rut == rut)
                                {
                                    d1.changeOwner(qw);
                                    Console.WriteLine("Propietario ingresado correctamente");
                                }
                                else
                                {
                                    Console.WriteLine("El rut ingresado no es valido, que desea?\n1.-Dejarlo vacio\n2.-Asignar de nuevo");
                                    aa = Console.ReadLine();
                                }
                            }
                        }
                        if (aa == "1")
                        {
                            d1 = new Address(calle, numero, comuna, ciudad, null, año, br, bñr, q1, q2);
                        }

                    }

                    direcciones.Add(d1);
                }
                #endregion;
            }
            if (hola == 3)
            {
                #region CREARAUTOS
                Car c1 = null;
                Console.WriteLine("Ingrese nombre de la marca: "); string marca = Console.ReadLine();
                Console.WriteLine("Ingrese el anho"); int anho = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el modelo "); string modelo = Console.ReadLine();
                Console.WriteLine("Ingrese la patente:  "); string patente = Console.ReadLine();
                Console.WriteLine("Ingrese cantidad de asientos "); int sb = int.Parse(Console.ReadLine());
                Console.WriteLine("Es diesel? (si/no) ");
                bool sa;
                if (Console.ReadLine() == "si") { sa = true; }
                else { sa = false; }
                Console.WriteLine("Ingrese el rut del propietario: "); string rut = Console.ReadLine();
                foreach (Person p in personas)
                {
                    if (p.Rut == rut)
                    {
                        c1 = new Car(marca, modelo, anho, p, patente, sb, sa);
                        Console.WriteLine("Auto creado satisfactoriamente.");
                        autos.Add(c1);
                    }
                    else
                    {
                        Console.WriteLine("El rut ingresado no es valido\nVolviendo al menu principal.");
                        goto INICIO;

                    }
                }
                #endregion
            }
            if (hola == 4)
            {
                #region AGREGARBANHOS;
                Console.WriteLine("Ingrese comuna que vive: "); string comuna = Console.ReadLine();
                Console.WriteLine("Ingrese numero propiedad: "); int numero = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese calle que vive: "); string calle = Console.ReadLine();
                foreach (Address ad in direcciones)
                {
                    if (ad.Commune == comuna && ad.Number == numero && ad.Street == calle)
                    {
                        Console.WriteLine("Ingrese cuantos banhos desea agregar");
                        int b = int.Parse(Console.ReadLine());
                        ad.addBathrooms(b);
                    }
                }
                #endregion
            }
            if (hola == 5)
            {
                #region AGREGARDORMS;
                Console.WriteLine("Ingrese comuna que vive: "); string comuna = Console.ReadLine();
                Console.WriteLine("Ingrese numero propiedad: "); int numero = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese calle que vive: "); string calle = Console.ReadLine();
                foreach (Address ad in direcciones)
                {
                    if (ad.Commune == comuna && ad.Number == numero && ad.Street == calle)
                    {
                        Console.WriteLine("Ingrese cuantos dormitorios desea agregar");
                        int b = int.Parse(Console.ReadLine());
                        ad.addBeedrooms(b);
                    }
                }
                #endregion
            }
            if (hola == 6)
            {
                #region COSASPERSONA
                Console.WriteLine("Ingrese su rut. ");
                string rut = Console.ReadLine();
                foreach (Person p1 in personas)
                {
                    if (p1.Rut == rut)
                    {
                        Console.WriteLine("\tIngrese la accion que desea hacer:\n\t\t1.-Cambiar nombre\n\t\t2.-Cambiar Apellido\n\t\t3.-Ser abandonado");
                        int q = int.Parse(Console.ReadLine());
                        if (q == 1)
                        {
                            Console.WriteLine("Ingrese su nuevo nombre ");
                            p1.changeFirstName(Console.ReadLine());
                            Console.WriteLine("Listo, volviendo al menu principal.");
                            goto INICIO;
                        }
                        if (q == 2)
                        {
                            Console.WriteLine("Ingrese su nuevo Apellido ");
                            p1.changeLastName(Console.ReadLine());
                            Console.WriteLine("Listo, volviendo al menu principal.");
                        }
                        if (q == 3)
                        {
                            p1.getAbandoned();
                            Console.WriteLine("Listo, volviendo al menu principal.");
                            goto INICIO;
                        }
                    }
                }
                #endregion
            }
            if (hola == 0)
            {
                Console.WriteLine("Gracias por visitarnos, nos vemos.");
                BinaryFormatter binF = new BinaryFormatter();
                FileStream fs = File.Open("personas.txt", FileMode.OpenOrCreate);
                binF.Serialize(fs, personas);
                BinaryFormatter binF1 = new BinaryFormatter();
                FileStream fs1 = File.Open("direcciones.txt", FileMode.OpenOrCreate);
                binF.Serialize(fs, direcciones);
                BinaryFormatter binF2 = new BinaryFormatter();
                FileStream fs2 = File.Open("autos.txt", FileMode.OpenOrCreate);
                binF.Serialize(fs, autos);
                fs.Close();
                fs1.Close();
                fs2.Close();
            }
        }
    }
}
