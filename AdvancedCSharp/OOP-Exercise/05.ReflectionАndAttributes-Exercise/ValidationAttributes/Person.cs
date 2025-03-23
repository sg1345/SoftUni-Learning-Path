using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.FullName = name;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; }
        [MyRange(12,90)]
        public int Age { get; }
    }
}