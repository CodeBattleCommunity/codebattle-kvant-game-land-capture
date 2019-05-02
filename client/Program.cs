using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleClient
{
    class Program
    {
        private const string APP_PATH = "http://localhost:5000";
        private static string token;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите логин:");
            string userName = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();

            var registerResult = Register(userName, password);

            Console.WriteLine("Статусный код регистрации: {0}", registerResult);

            Console.Read();
        }

        // регистрация
        static string Register(string email, string password)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(1, 1);

            dic.Add(2, 2);

            var registerModel = new
            {
                id = 1,
                ignore_point = dic
            };
            
            using (var client = new HttpClient())
            {
                //Console.WriteLine(JsonConvert.SerializeObject(registerModel).ToString());
                var response = client.PostAsJsonAsync(APP_PATH + "/api-v1/map", registerModel).Result;
                var result = response.Content.ReadAsStringAsync();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
}