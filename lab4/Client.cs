using System;


namespace lab4
{
    /// <summary>
    /// Класс Client, зависит от Service
    /// </summary>
    class Client
    {
        Service serv;
        public Client(Service s)
        {
            serv = s;
        }
        public void GetServ(string serviceName)
        {
            switch (serviceName)
            {
                case "Maps":
                    serv.Maps();
                    break;
                case "Translator":
                    serv.Translator();
                    break;
                case "Mail":
                    serv.Mail();
                    break;
                case "Disk":
                    serv.Disk();
                    break;
                case "Calendar":
                    serv.Calendar();
                    break;

                case "Taxi":
                    serv.Taxi();
                    break;
                case "Music":
                    serv.Music();
                    break;
                case "Weather":
                    serv.Weather();
                    break;
                case "News":
                    serv.News();
                    break;
                case "Images":
                    serv.Images();
                    break;

                default:
                    throw new ArgumentException("Неверный сервис");
            }
        }
    }
}
