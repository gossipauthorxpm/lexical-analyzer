using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lecsec_new
{
    internal class Lecsic
    {
        private string path;
        public Lecsic(string path_to_file)
        {
            this.path = path_to_file;
        }        
        public string ReadFileToStr()
        {
            try
            {
                using StreamReader reader = new StreamReader(path, Encoding.UTF8);
                {
                    string new_str = "";
                    new_str = reader.ReadToEnd();                    
                    reader.Close();

                    return new_str;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение - " + e);
                return null;
            }
        }
        public void Analyz(string[] delimeters, string[] constants, string[] keywords,string[] operators, string new_str, string[] main_lecsem)
        {
            Console.WriteLine("Поиск лексем!");
            string str = DeleteTrashInString(new_str);
            string dump = "";
            for(int i = 0; i<str.Length; i++)
            {
                if (!str[i].Equals(' '))
                {
                    dump += str[i];
                }
                foreach(string delimeter in delimeters)
                {
                    if (delimeter.Equals(dump))
                    {
                        Console.WriteLine(dump + " Разделитель");
                        dump = "";

                    }
                }
                foreach(string constant in constants)
                {
                    if (constant.Equals(dump))
                    {
                        Console.WriteLine(dump + " Константа");
                        dump = "";
                    }
                }
                foreach(string key in keywords)
                {
                    if (key.Equals(dump))
                    {
                        Console.WriteLine(dump + " Ключевое слово");
                        dump = "";
                    }
                }
                foreach(string oper in operators)
                {
                    if (oper.Equals(dump))
                    {
                        Console.WriteLine(dump + " Оператор");
                        dump = "";
                    }
                }
            }
            bool error = FindError(dump, main_lecsem);
            if (error)
            {
                Console.WriteLine("Неправильный синтаксис!: " + dump);
            }
            else
            {
                Console.WriteLine("Успех!");
            }

        }
        private string DeleteTrashInString(string new_str)
        {
            string str;
            str = new_str.Replace("\n", " ");
            str = str.Replace("\r", " ");
            str = str.Replace("\t", " ");
            return str;
        }
        private bool FindError(string dump, string[] main_lecsem)
        {
            string[] strs = dump.Split(main_lecsem, StringSplitOptions.None);
            foreach(string str in strs)
            {
                if(!str.Equals(""))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
