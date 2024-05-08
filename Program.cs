using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HastagGenerator
{
    internal class Program
    {
        public static string pathToFile = "ighastag.txt";
        public static string pathToFile1 = "ighastag1.txt";
        static void Main(string[] args)
        {
            SelectHastag();
            Console.ReadLine();

        }

        public static void TextReader()
        {
            foreach (var myString in File.ReadAllLines(pathToFile1))
                if (!myString.StartsWith("#"))
                {
                    TextWriter('#' + myString);
                }
        }

        public static void TextWriter(string hastag)
        {
            using (StreamWriter sw = File.AppendText(pathToFile1))
            {
                sw.WriteLine(hastag);
            }
        }
        public static void REadAndWriteText()
        {
            string[] satirlar = File.ReadAllLines(pathToFile1);

            string duzenlenmisMetin = "";
            foreach (string satir in satirlar)
            {
                string duzenlenmisSatir = satir.Replace(" ", "");
                if (!duzenlenmisSatir.StartsWith("#"))
                {
                    duzenlenmisSatir = "#" + duzenlenmisSatir;
                }
                duzenlenmisMetin += duzenlenmisSatir + Environment.NewLine;
            }


            string yeniDosyaYolu = "duzenlenmis_metin.txt";
            File.WriteAllText(yeniDosyaYolu, duzenlenmisMetin);
        }
        public static void SelectHastag()
        {
            List<string> hastags = new List<string>();

            string[] satirlar = File.ReadAllLines(pathToFile1);
            Random random = new Random();
            for (int i = 0; i < 25; i++)
            {
                int randomchars = random.Next(satirlar.Length);
                hastags.Add(satirlar[randomchars]);

            }
            foreach (var item in hastags)
            {
                Console.Write(item + " ");
            }
        }
    }
}
