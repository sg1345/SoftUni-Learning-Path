
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(Tracker);

            MethodInfo[] methods = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic)
                .Where(m => m.GetCustomAttributes<AuthorAttribute>().Count() > 0)
                .ToArray();

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(n=>n.AttributeType == typeof(AuthorAttribute)))
                {
                    AuthorAttribute[] attributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}