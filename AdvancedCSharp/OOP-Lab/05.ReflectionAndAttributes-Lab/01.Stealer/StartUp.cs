namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo
                (nameOfTheClass: "Stealer.Hacker", fieldsToInvestigate: new[] { "username", "password" });

            Console.WriteLine(result);
        }
    }
}
