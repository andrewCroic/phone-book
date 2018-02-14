using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication39
{
    class Program
    {
        static void print(List<string> nomer, List<string> surname, List<string> adress)//метод печати
        {
            Console.Clear();
            for (int i = 0; i < nomer.Count; i++)//цикл для вывода справочника на монитор
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}      |", nomer[i]);//печать номера с пробелом
                Console.Write(surname[i]);//печать фамилии
                for (int j = 0; j < 15 - surname[i].Length; j++)
                {
                    Console.Write(" ");//цикл, в котором добавляются пробелы после фамилии, пока количество символов не будет равно 15
                }
                Console.Write("|");
                Console.WriteLine(adress[i]);
                Console.WriteLine("-------------------------------------------------------------------------------");
               
                Console.ResetColor();
            }
            main1(nomer, surname, adress);
        }
        static void found(List<string>nomer,List<string>surname,List<string>adress)//метод поиска
        {
            int kol = 0;//целочисленная переменная понадобится нам для подсчета номеров, не совпадающих с веденными данными
            Console.WriteLine("Введите номер или фамилию абонента");
            string s = Console.ReadLine();
            s = s.ToUpper();
            Console.Clear();//очистка текста на мониторе        
            for (int i = 0; i < surname.Count; i++)
            {
                if (nomer[i].Contains(s) || surname[i].Contains(s))//условие, которое ищет совпадение введенных нами данных и данных,записанных в list
                {                  
                    Console.ForegroundColor = ConsoleColor.Yellow;//изменение цвета текста                   
                    Console.Write("{0}      |", nomer[i]);//вывод номера
                    Console.Write(surname[i]);//вывод фамилии
                    for (int j = 0; j < 15 - surname[i].Length; j++)//цикл, в котором к фамилии лобавляются пробелы, пока длина не станет равна 15
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                    Console.WriteLine(adress[i]);//вывод найденных аюонентов
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.ResetColor();
                }
                else
                {
                    kol++;//если совпадений не найдено, переменная увеличивается на 1
                    if(kol==nomer.Count)//когда переменная равна количеству абонентов в справочнике, в справочнике нет ни одного совпадения
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Абонент не найден");
                        Console.ResetColor();
                        Console.WriteLine("Желаете найти еще одного абонента?\n1-Да\n2-Нет");
                        int d = int.Parse(Console.ReadLine());
                        if (d == 1)
                        {
                            found(nomer, surname, adress);//повтор метода поиска
                        }
                        if (d == 2)
                        {
                            main1(nomer, surname, adress);//переход в главный метод
                        }
                        else
                        {
                            Console.WriteLine("неверно введено значение");
                            main1(nomer, surname, adress);
                        }
                    }
                }   
            }
            main1(nomer,surname,adress);//переход в начало программы
        }
        static void adding(ref List<string> nomer,ref List<string> surname,ref List<string> adress)//метод добавления
        {
            
            Console.WriteLine("Введите фамилию нового абонента");
             string sur = Console.ReadLine();
             sur = sur.ToUpper();
            Console.WriteLine("Введите номер(длина номера 9 символов(2 цифры префикса и номер)");
            string nom = Console.ReadLine();
            if (nom.Length != 9)//условие, ограничивающее длину номера
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА!!!Повторите ввод");
                Console.ResetColor();
                adding(ref nomer,ref surname,ref adress);//повторение метода добавления, связанное с допущенной ошибкой при вводе номера
            }
            nomer.Add(nom);//добавление в list<string>nomer
            surname.Add(sur);
            Console.WriteLine("Хотите ли добавить адрес?\n1-Да\n2-Нет");
            string dobavl = Console.ReadLine();
            if (dobavl == "1")
            {
                Console.WriteLine("Введите город");
                string gorod = Console.ReadLine();
                gorod = "г."+gorod+", ";
                Console.WriteLine("Введите улицу");
                string street = Console.ReadLine();
                street = "ул." + street+", ";
                Console.WriteLine("Введите номер дома");
                string house = Console.ReadLine();
                house ="д."+house+", ";
                Console.WriteLine("Введите номер квартиры");
                string flat=Console.ReadLine();
                flat = "кв." + flat;
                adress.Add(gorod + street + house + flat);
            }
            if (dobavl == "2")
            {
                adress.Add(" ");
            }
            Console.WriteLine("Абонент успешно добавлен");
            main1(nomer,surname,adress);//переход в главное меню
        }
        static void removing(ref List<string> nomer, ref List<string> surname, ref List<string> adress)//метод удаления
        {
           
            int sovp = 0;//переменная, для подсчета совпадений
            Console.WriteLine("Введите фамилию или номер абонента, данные которого необходимо удалить, чтобы перейти в главное меню - нажмите 2");            
            string s=Console.ReadLine();
            s = s.ToUpper();          
            if (s == "2")
            {
                main1(nomer, surname, adress);//если введем 2, нас переместит в главное меню
                return;//выход из блока
            }
            for (int i = 0; i < nomer.Count; i++)
            {
                if (nomer[i].Contains(s) || surname[i].Contains(s))
                {
                    sovp++;//подсчет совпадений
                }
            }
            if (sovp == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Абонент не найден");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < nomer.Count; i++)
                {
                    if (nomer[i].Contains(s) || surname[i].Contains(s))
                    {
                        if (sovp == 1)//если было найдено одно совпадение, номер будет удален
                        {
                            nomer.RemoveAt(i);//удаление из list с номерами i-ого элемента
                            surname.RemoveAt(i);
                            adress.RemoveAt(i);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Абонент удален");
                            Console.ResetColor();
                        }
                        else//если совпадений больше одного, программа оповестит об этом, и предложит ввести более точные данные 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Найдено несколько номеров по вашему запросу, введите более точные данные");
                            Console.ResetColor();
                            removing(ref nomer, ref surname, ref adress);
                        }
                    }
                }
            }
            main1(nomer, surname, adress);//переход в главное меню
        }
        static void saving(List<string> nomer, List<string> surname, List<string> adress)//метод сохранения и выхода
        {
            string path = Environment.CurrentDirectory + "/"; //определяет местоположение каталога
            Console.WriteLine("Хотите ли сохранить изменения?\n1-Да\n2-Просто выйти");
            int k = int.Parse(Console.ReadLine());
            if (k == 1)
            {
                FileInfo fi = new FileInfo(@path + "a.txt");//указание пути
                StreamWriter w = fi.CreateText();//создание текстового документа
                for (int i = 0; i < nomer.Count; i++)
                {
                    w.WriteLine("{0};{1};{2}", nomer[i], surname[i], adress[i]);//запись в документ
                }
                w.Close();//закрытие текстового потока
                Environment.Exit(0);//выход из консоли
            }
            if (k == 2)
            {
                Environment.Exit(0);//выход из консоли
            }
            else
            {
                Console.WriteLine("Повторите ввод");
                saving(nomer, surname, adress);
            }
        }
        static void Main()//Главный метод, в котором считываются данные из текстового документа, и происходит запись в list
        {
            string path = Environment.CurrentDirectory + "/"; 
            Console.WriteLine("Добро пожаловать в телефонный справочник");
            List<string>nomer=new List<string>();//создаем list, в который впоследствии будут записываться номера,list можно считать динамическим массивом
            List<string> surname = new List<string>();//создаем list, в который впоследствии будут записываться фамилии
            List<string> adress = new List<string>();//создаем list, в который впоследствии будут записываться адреса
            StreamReader doc = new StreamReader(@path+"a.txt");//построчно считываем данные из текстового файла
            string text;//создаем строковую переменную, в которую будем записывать данные
            while ((text = doc.ReadLine()) != null)//массив, в котором нашей строковой переменной придается значение и одновременно проверяется ее отличие от нуля
            {
                string[] split = text.Split(new char[] { ';', ';' });//с помощью метода split мы разбиваем один массив на несколько элементов, это происходит при нахождении знака ";"
                nomer.Add(split[0]);//записываем 1-ый элемент в list с номерами
                surname.Add(split[1]);//записываем 2-ый элемент в list с фамилиями
                adress.Add(split[2]);//записываем 3-ый элемент в list с адрессами                 
            }
            doc.Close();//закрытие текстового потока
            main1(nomer,surname,adress);
        }
        static void main1(List<string> nomer, List<string> surname, List<string> adress)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1-Вывод всех контактов на монитор;\n2-Поиск контакта;\n3-Добавление контакта;\n4-Удаление контакта\n5-Выход");
            string n = Console.ReadLine();//вводим целочисленную переменную, от которой будет зависеть дальнейшее действие программы
            if (n == "1")//переход в метод печати
            {
                print(nomer, surname, adress);
            }
            if (n == "2")
            {
                found(nomer,surname,adress);//переход в метод поиска, если введено 2
            }
            if (n == "3")
            {
                adding(ref nomer,ref surname,ref adress);//переход в метод добавления, если введено 3
            }
            if (n == "4")
            {
                removing(ref nomer, ref surname, ref adress);//переход в метод удаления, если введено 4
            }
            if (n == "5")
            {
                saving(nomer, surname, adress);//переход в метод сохранения
            }
            else//исключение, если пользователь ошибается при вводе
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Данной функции нет!!!");
                Console.ResetColor();
                main1(nomer, surname, adress);
            }
            Console.ReadLine();
        }
    }
}
