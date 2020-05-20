using System;
using System.IO;

namespace Crear_Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("¿Nombre del programa?");
            string nombre = Console.ReadLine();
            ejecutar($"/C dotnet new console -o {nombre}");
            while(true){
                if(File.Exists($"{nombre}\\Program.cs")){
                    // Falta añadir cabecera y nombrificador
                    nombre += "\\Program.cs";
                    System.Threading.Thread.Sleep(1000);
                    string f1 = File.ReadAllText($"{nombre}");
                    f1 = "using static System.Console;\n"+f1;
                    File.Delete($"{nombre}");
                    StreamWriter f3 = File.AppendText($"{nombre}");
                    f3.Write(f1);
                    f3.Close();
                    break;
                };
            }
            System.Threading.Thread.Sleep(500);
            Console.Clear();            
        }

        public static void ejecutar(string argumento){
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"{argumento}";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
