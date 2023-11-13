namespace demo
{
    // 单一服务的注入
    public class OnlyCalculator
    {
        public string[] files;
        public OnlyCalculator()
        { 
            this.files = new string[0];
            //假设这里很慢 第一次调用CesCalculator类里的Add1方法时，因为OnlyCalculator(类)服务在被接收CesCalculator的构造方法接收的时候就会实例创建
            //虽然注册只会创建一次 第二次调用Add2的时候就很快，但是是因为缓存了 并没有达到我们首次调用Add2的时候 首次加载这个(很慢的服务)
            //而要做的是Add2方法需要的时候才去创建这个服务
        }
        public int Count 
        { 
            get { return this.files.Length; }
        }
    }
}
