using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryprion
{
    class Program
    {
        static void Main(string[] args)
        {
            const String AngAlf = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            const String SpecialSimbol = "!@#$%^&*()_+-=,./?|';:<>[]{}№";
            const String Kirilica = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХчЦцЧчШшЩщЪъЫыЬьЭэЮюЯя" + "ІіЇїЄє";
            const String Number = "0123456789";
            const String AllOut = AngAlf + SpecialSimbol + Kirilica + Number;
            Console.WriteLine("Enter path: ");
            string path = Console.ReadLine();
            Console.WriteLine("Enter key: ");
            string key = Console.ReadLine();
            string all = Read(path, key);
            Console.WriteLine(all);
            string ffout = Transform(AllOut, key,all);
            Console.WriteLine(ffout);
            write(path, ffout);
        }

        static void write(string path, string file)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(file);
            }
        }

        static string Transform(string From, string To, string Text)
        {
            String TextOut = "";
            int size = Text.Length, lic = 0, bufer;
            while (size != 0)
            {
                if (From.Contains(Text[lic].ToString()))
                {
                    bufer = From.IndexOf(Text[lic].ToString());
                    TextOut += To[bufer].ToString();
                }
                else
                {
                    TextOut += Text[lic].ToString();
                }
                lic++;
                size--;
            }
            return TextOut;
        }

        static string Read(string path, string kay)
        {
            string all = "";
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251)))
                {
                    all = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return all;
        }
    }
}
