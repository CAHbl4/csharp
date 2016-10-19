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
            object[] attrs = type.GetCustomAttributes(false);
            bool isDisp=false;
            foreach(object a in attrs)
            {
                if (a is StatusAttribute)
                {
                    StatusAttribute stAtr = (StatusAttribute)a;

                    if (stAtr.IsSecret)
                        info = "Secret";
                    if (stAtr.Status == ObjectStatus.Vip)
                        info = info.ToUpper();
                    else
                        if (stAtr.Status == ObjectStatus.Looser)
                            info = info.ToLower();
                }
                else if(a is DisplayedAttribute)
                {
                    isDisp = true;
                }
            }
            
            if (!isDisp)
                info = "**********";
            Console.WriteLine(info);
        }
        static void Main(string[] args)
        {
            Person p = new Person("Толстой","Лев");
            Show(p);
            Show("Привет, Вася");
            Console.WriteLine(p);
            Document doc = new Document { Title = "Секреты демокр. партии ", Price = 1000000, Shifr = "S123$$$" };
            Show(doc);
            Console.ReadKey();
        }
    }
}
