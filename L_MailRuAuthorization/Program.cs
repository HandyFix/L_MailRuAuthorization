using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xNet;

namespace L_MailRuAuthorization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Check("myrauthorization@mail.ru", "190190aA"));
            Console.ReadKey();
        }

        public static string Check(string email, string password)
        {
            //Создаём экземпляр класса
            HttpRequest req = new HttpRequest();

            //Добавляем параметры
            req.AddParam("grant_type", "password");
            req.AddParam("client_id", "742736");
            req.AddParam("client_secret", "188219ddfca99f8ff1c3a859e0f0b0fd");
            req.AddParam("username", email);
            req.AddParam("password", password);

            try
            {
                //Ебошим запрос на mail.ru
                var response = req.Post("https://appsmail.ru/oauth/token").ToString();

                if (response.Contains("access_token"))
                {
                    return "good";
                }
                else
                {
                    return "bad";
                }
            }
            catch
            {
                //Если пароль неправильный, то эта хуйня нам вернёт ошибку 400
                return "error";
            }
        }
    }
}
