using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
     class GatherInfo
    {
        public string Name = "aaa";
        public static void Getinfo() 
        {
            Console.WriteLine("请输入你的姓名");
            string name =   Console.ReadLine();

            if (name!="")
            {
                name = "222";
            }
            Console.WriteLine("请输入的年龄");
            int age = int.Parse( Console.ReadLine());
            Console.WriteLine("请输入你的爱好");
            string hobby = Console.ReadLine();
            Console.WriteLine("你的姓名是：" + name);
            Console.WriteLine("你的年龄是：" + age);
            Console.WriteLine("你的爱好是：" + hobby);
            Console.ReadKey();
        } 
        public  void GetinfoTwo() 
        {
            Console.WriteLine("请输入你的姓名");
            string name =   Console.ReadLine();

            if (name!="")
            {
                name = "222";
            }
            Console.WriteLine("请输入的年龄");
            int age = int.Parse( Console.ReadLine());
            Console.WriteLine("请输入你的爱好");
            string hobby = Console.ReadLine();
            Console.WriteLine("你的姓名是：" + name);
            Console.WriteLine("你的年龄是：" + age);
            Console.WriteLine("你的爱好是：" + hobby);
            Console.ReadKey();
        }
       
    }
}
