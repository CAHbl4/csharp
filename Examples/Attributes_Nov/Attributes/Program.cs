using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Show(object obj)
        {
            string info = obj.ToString();
            Type type = obj.GetType();
            object[] attrs = type.GetCustomAttributes(false);   //получаем массив объектов типа object
            bool IsDispl = false;
            foreach (object item in attrs)
            {
                if (item is StatusAttribute)
                {
                    StatusAttribute stAtr = (StatusAttribute)item;
                    if (stAtr.IsSecret)        //инфо секретная
                        info = "Secret";
                    if (stAtr.Status == ObjectStatus.Vip)     //выводим инфо
                        info = info.ToUpper();
                    else if (stAtr.Status == ObjectStatus.Looser)     //выводим инфо
                        info = info.ToLower();
                }
                else if (item is DisplayedAttribute)
                    IsDispl = true; 
            }
            if (!IsDispl)
                info = "********";
            //if(attrs.Length!=0)     //проверяем существует ли объект
            //{
            //    StatusAttribute stAttr = (StatusAttribute)attrs[0]; //object преобразуем в нужный нам тип, чтобы получить доступ к Status, IsSecret...
            //    if (stAttr.Status == "Vip")     //выводим инфо
            //        info = info.ToUpper();  //выводит в ЗАГЛАВНЫХ буквах
            //    if (stAttr.IsSecret)        //инфо секретная
            //        info = "Secret";
            //}
            Console.WriteLine(info);
        }
        static void Main(string[] args)
        {
            Person p = new Person("Tolstoi", "Lev");
            //    Person p1 = new Person("Krin", "Olga");
            Show(p);
            Show("Hello");

            Document d = new Document { Title = "Secret partii", Price = 1000000, Shifr = "f521456" };
            Show(d);



            Console.ReadKey();
        }
    }
}
