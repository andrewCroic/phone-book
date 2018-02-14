using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication39
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string>nomer=new List<string>();
            List<string> surname = new List<string>();
            List<string> adress = new List<string>();
            StreamReader doc = new StreamReader(@"C:\Users\Андрей\Desktop\a.txt");
            string text;
            while ((text = doc.ReadLine()) != null)
            {
                string[] split = text.Split(new char[] { ';', ';' });
                nomer.Add(split[0]);
                surname.Add(split[1]);
                adress.Add(split[2]);
                
            }
            
            for (int i = 0; i < nomer.Count; i++)
            {
                Console.WriteLine("{0}", adress[i]);
            }
            Console.ReadLine();
        }
    }
}
