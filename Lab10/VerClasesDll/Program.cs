using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly archivoAssembly = Assembly.LoadFile(@"C:/Users/Jorge/Desktop/municipality-library-jpcortez/ClassLibrary1.dll");
            foreach (Type type in archivoAssembly.GetTypes())
            {
                if (type.IsClass) Console.WriteLine("class");
                else if (type.IsInterface) Console.WriteLine("interface");
                else Console.WriteLine("otro tipo");
                Console.WriteLine(type.Name);
                MethodInfo[] properties = type.GetMethods();
                Console.WriteLine("metodos: ");
                foreach (MethodInfo prop in properties)
                {
                    Console.WriteLine("\t" + prop.Name);
                }

                Console.WriteLine();


            }
            Console.ReadKey();
        }

    }
}