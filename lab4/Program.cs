using System;
using System.IO;

namespace lab4
{
    /// <summary>
    /// Класс для решения задачи.</summary>
    /// <remarks>
    ///Предположим, нам требуется написать приложение, в котором поддерживается возможность работы со стандартными веб-сервисами Google, Yandex и Baidu 
    ///(карты, поисковая система, почта и т.д.). Напишите часть программы, которая позволяет работать с веб-сервисами компании,выбираемой пользователем.
    ///Программа должна состоять из трёх классов-контроллеров для веб-сервисов компаний (Google, Yandex и Baidu) и класса, в который данные сервисы встраиваются.
    ///Реализовывать реальную работу с сервисами не требуется, достаточно выводить на консоль сообщение, в котором будет указано, какой метод какой класса был вызван.
    ///На вход программе подаётся строка с названием компании и список команд (работа с веб-сервисами). Минимальное количество веб-сервисов у классов Google, Yandex и Baidu: 10.
    ///Для решения задачи потребуется применение шаблона "Внедрение зависимости".
    ///Пример корректного ввода: 
    ///Yandex Maps Translator Mail 
    /// </remarks>
    class Program
    {
        /// <summary>
        /// Точка входа для приложения.
        /// </summary>
        /// <remarks>
        /// Читает входной файл и, в зависимости от названия компании, выводит результат попытки вызвать сервис.
        /// </remarks>
        static void Main(string[] args)
        {
            Console.WriteLine("ВВедите строку:");
            string stInp = Console.ReadLine();

            string[] elements = stInp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Service s;

            try
            {
                switch (elements[0].ToLower())
                {
                    case "yandex":
                        s = new Yandex();
                        break;
                    case "google":
                        s = new Google();
                        break;
                    case "baidu":
                        s = new Baidu();
                        break;
                    default:
                        throw new ArgumentException("Wrong company");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            Client c = new Client(s);
            string NameOfService;
            try
            {
                for (int i = 1; i < elements.Length; i++)
                {
                    NameOfService = elements[i];
                    c.GetServ(NameOfService);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }


            Console.ReadKey();
        }
    }
}
