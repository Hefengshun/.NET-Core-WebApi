namespace demo
{
    public record Person(string Name,int Age);

    //等同于
    //public class Person
    //{
    //    public string Name { get; }
    //    public int Age { get; }

    //    public Person(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //    }
    //}
}
