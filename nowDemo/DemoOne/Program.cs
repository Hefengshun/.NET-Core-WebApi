

// 命名空间 名称空间
//internal class Program
// using 使用
using System;
using System.Collections.Generic;
using System.Globalization;
using demo;
using ChangFileSpace;
using System.IO;
using System.Linq;
using System.ComponentModel;

namespace DemoOne
{


// 类型
class Program
    {
         // 函数 方法
        //static void Main(string[] args)
          static void Main(string[] args) //Main 是程序的入口
        {

            ChangFile gc = new ChangFile();
            gc.GetFile();

            string path = "C:/Users/51138/Desktop";
            // 获取这个路径下的所有文件
            DirectoryInfo root  = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            List<FileInfo> listFiles = files.ToList();

            // 循环文件

            for (int i = 0; i < listFiles.Count; i++)
            {
                string fileName = listFiles[i].Name;
                Console.WriteLine(listFiles[i].FullName);
                Console.WriteLine(listFiles[i].Name);
                if (listFiles[i].Name == "123.text")
                {
                    //System.IO.File.Delete(listFiles[i].FullName);
                }

               bool isHave =    fileName.Contains("Hellow"); //Contains 方法判断是否包含有 Hellow 返回布尔

                if (isHave)
                {
                    //给文件改名字
                    string  srcFileName = listFiles[i].Name;
                    string dstFileName = listFiles[i].Directory.FullName+"\\ddd"+ listFiles[i].Extension; //listFiles[i].Directory.FullName文件夹 +  名字 + 后缀名
                    File.Move(srcFileName, dstFileName);

                }
            }


            Console.ReadKey();
            return;

            GatherInfo getinfo = new GatherInfo();
            string GatherName = getinfo.Name;  // *** 引入另一个文件 先引入命名空间 使用其中变量 需要实例化或者加上 static 静态
            GatherInfo.Getinfo();  // *** 引入另一个文件 先引入命名空间 使用静态方法||变量 不需要实例化 
            getinfo.GetinfoTwo();  // *** 引入另一个文件 先引入命名空间 使用不是静态方法||变量 需要实例化 




            //  循环 调用方法
            for (int i = 0; i < 4; i++)
        {
            GetuserInfo();
        }
       


        // var 语法糖 自动推导类型
        // 变量类型 就是告诉cpu 字符类型
        var n = 100;
        int numONe = 100;
        int numOFFe = 200;
        int sum = 0;
        List<int> list = new List<int>(); //int 类型的集合 (泛型集合) list.Count 与 list.length 的区别
        list.Add(n);

       




        // defaultSum 这样写默认是赋值0
        int defaultSum;
        // cpu 拿到后存的是 文字对应的代号
        string name = "你好";
        sum  = numONe + numOFFe;
        //System.Console.WriteLine(sum);
        Console.WriteLine(sum);
        Console.WriteLine(name);
        //Console.ReadKey(); // 暂停 按任意字符结束


        Console.WriteLine("请输入一个文字：");

          string str =   Console.ReadLine();  // 控制台输入 注意输入的类型
        Console.WriteLine(str);
        //str str 也要是数字字符串
        int sunThree  =  int.Parse( str) + 20;
        Console.WriteLine(sunThree);


        Console.WriteLine("请输入一个数字：");
        string s = Console.ReadLine();  // 控制台输入 注意输入的类型
        Console.WriteLine(s);
        //str str 也要是数字字符串
        string sumStr = s + 20; // 这时候加的20就成字符串类型
        Console.WriteLine(sumStr);
        Console.ReadKey();
        }


    //  public 公共的都可以使用 public 不写就是private(只能在此类型里使用)  static代表静态的  void代表返回值 没有或者null就写void
    public static void GetuserInfo() {


           

            Console.WriteLine("请输入你的姓名");
        string name = Console.ReadLine();
        string disposeName =  ReceiveParams(name); // ReceiveParams方法返回了一个string 定义一个disposeName接收string
        Console.WriteLine(disposeName);
        if (name != "")
        {
            name = "222";
        }
        Console.WriteLine("请输入的年龄");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("请输入你的爱好");
        string hobby = Console.ReadLine();
        Console.WriteLine("你的姓名是：" + name);
        Console.WriteLine("你的年龄是：" + age);
        Console.WriteLine("你的爱好是：" + hobby);
        Console.ReadKey();
    }
    static string  ReceiveParams(string name) // 接收一定要加类型
    {
        Console.WriteLine("请输入的年龄"+ name);
        return name;
    }
}
}
