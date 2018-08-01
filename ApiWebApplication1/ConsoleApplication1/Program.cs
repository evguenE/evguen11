using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    //class Garbage
    //{
    //   public Garbage(){ Console.WriteLine("ReserveMemoey");  }

    //   ~Garbage() { Console.WriteLine("destructor"); }

    //}

    class A 
    {

      public  A() { Console.WriteLine("class A"); }
    
    };
    
    class B: A 
    {
      public  B() { Console.WriteLine("class B"); }
    
    };



    class Program
    {

        //Dictionary<string, string> dic = new Dictionary<string, string>();            
        static void Main(string[] args)
        {
           object o = new A();

           //B b = new B();

           //A aa = new B();

           A oo = (B)o;

           //var sss = null;


           string menuchoice="";
           List<card> dic = new List<card>();   
           
              Console.WriteLine("\n");
              Console.WriteLine("МЕНЮ  \n");
               Console.WriteLine(" I. Ввод");
               Console.WriteLine(" R. Отчет/информация");
               Console.WriteLine(" L. Выгрузка данных");                           
               Console.WriteLine(" Q. Exit");
               Console.WriteLine("\n");

               //if (string...is(menuchoice)  
            while (!menuchoice.Equals("Q"))
            {
                Console.Write("Выберите одно из значений меню: ");
                //menuchoice = int.Parse(Console.ReadLine());
               menuchoice = Console.ReadLine();
               switch (menuchoice)
               {
                   case "I":

                       ConsoleKeyInfo cki;
                      
                       string input_nom,input_ncard = "";
                       //int temperature;
                       //while (!Int32.TryParse(Console.ReadLine(), out temperature))
                       //{
                       //    Console.WriteLine("Неправильное число, please enter again the № карты");
                       //    Console.Write("Введите карту: (####-#### ) ");
                       //}
                       
                       do 
                          {
                             cki = Console.ReadKey();
                             //Console.WriteLine (" --- You pressed ");
                             ////if((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                             ////if((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                             ////if((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
                             //Console.Write(cki.KeyChar);
                             Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                             Console.WriteLine("  ");
                             Console.Read();
                           
                       } while (cki.Key != ConsoleKey.Escape);
    
                        //do {
                        //    Console.Write("Введите номинал: (#### ):");
                        //    input_nom = Console.ReadLine();
                        //  }
                        //  while (!Regex.IsMatch(input_nom, @"^[0-9]\d{3}$")); // <- four digits expected
                       //do {

                       //    cki = Console.ReadKey();
                       //    Console.WriteLine(" --- You pressed ");
                           
                       //    Console.Write("Введите номер: (####-#### ):");
                       //     input_ncard = Console.ReadLine();
                             
                       //}
                      // while (!Regex.IsMatch(input_ncard, @"^[0-9]\d{3}[-][0-9]\d{3}$")); // <- four digits expected
                          
                       //    //if(input.Length == 5)
                       //    //   Console.Write("-");

                       //  Console.Write("Введите карту(loop): (####-#### ) ");

                       //} while (int.TryParse(input, out n) == false && input.Length != 7);
                       
                       Console.WriteLine("Карта успешно введена \n");
                       //dic.Add( new card{ncard = input_ncard,nom = input_nom, dat = DateTime.Today.ToString("dd/MM/yyyy") });

                       break;
                   case "R":
                       Console.Write("Отчет/информация \n");
                       //foreach(var di in dic )
                       //{
                       //    Console.WriteLine(" карта = {0} дата = {1}",di.Key,di.Value);  
                       //}                       
                       break;
                   case "L":
                       
                       Console.WriteLine("Выгрузка данных");
                       StringBuilder sb = new StringBuilder();
                       sb.Append("<?xml version='1.0' encoding='windows-1251'?>");
                       sb.Append("<payments>");
                       //foreach (var di in dic)
                       //{
                       //    sb.Append("<payment doc-date =" +  di.Value + ">");
                       //    //Console.WriteLine(" карта = {0} дата = {1}", di.Key, di.Value);
                                                    
                           
                       //    sb.Append("</payment>");
                       
                       //}
                       sb.Append("</payments>");
                       break;
                   default:
                       Console.WriteLine("Sorry, invalid selection");
                       break;
               }
           }

        }
     
        //static void Save(){            
        //    Console.Write("Введите карту: (####-#### ) ");
        //    string choice =   Console.ReadLine();
        //    dic.add(choice);
        //}

        //static void Report()
        //{
        //    foreach (var numCard in card)
        //    { }
        //    Console.WriteLine();

        //} 
  
    }
    
    public class card
    {
       public string ncard { get; set; }
       public string nom { get; set; }
       public string dat { get; set; }
    }
}
