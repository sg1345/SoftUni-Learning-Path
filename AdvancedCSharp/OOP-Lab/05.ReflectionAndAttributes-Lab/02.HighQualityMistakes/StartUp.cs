﻿namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers(className: "Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
