using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOne
{
    //使用 internal 修饰的类型或成员只能在同一程序集中访问。程序集是一组相关的代码文件的集合，通常是一个项目或一个库
    //如果不指定任何访问修饰符，则类型和成员的默认访问级别是 internal
    internal class Constructor
   
    {
        public Constructor()   //Constructor类的 构造函数 是类的一个特殊的成员函数，当创建类的新对象时执行。
                               //构造函数的名称与类的名称完全相同，它没有任何返回类型。
        {
            Console.WriteLine("");
        }
    }
}
