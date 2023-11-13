using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CesCalculator : ControllerBase
    {

        // 构造函数注入
        private readonly Calculator calculator;
        private readonly OnlyCalculator onlyCalculator;

        public CesCalculator(Calculator calculator, OnlyCalculator onlyCalculator) //1. 接收calculator参数为Calculator实列类型
                                                                                   //CesCalculator方法是CesCalculator类的 构造函数 是类的一个特殊的成员函数，当创建类的新对象时执行。
                                                                                   //构造函数的名称与类的名称完全相同，它没有任何返回类型。
        {
            Console.WriteLine(calculator);//这里使用的时候calculator已经实列化了 在Program.cs文件查看 那里注入的时候只会实例化一次 后面就是谁(类)引入就可以使用
            this.calculator = calculator;
            this.onlyCalculator = onlyCalculator;
        }
        [HttpGet]
        public int Add1()
        {
            return calculator.Add(3, 8); //calculator属性里面里面的方法是private私有的 所以只在CesCalculator类里面使用 不会照成命名污染
        } 
        [HttpPost]
        public int Add2([FromServices] OnlyCalculator onlyCalculator)    // 单一服务的注入  *** 注意测试时需要把上面CesCalculator构造函数里面不能在接收OnlyCalculator服务了 而是在Add2方法里面直接注入服务
        {
            return onlyCalculator.Count; //calculator属性里面里面的方法是private私有的 所以只在CesCalculator类里面使用 不会照成命名污染
        }
        //总结 构造方法里面注入 里面调用任意方法 都会走服务 而单一服务的注入是指定到莫格具体方法调用时 才会启动的服务
    }
}
