using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfTheClass, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(nameOfTheClass);

            FieldInfo[] classFields = classType.GetFields
                (BindingFlags.Instance |BindingFlags.Static |BindingFlags.NonPublic| BindingFlags.Public);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {nameOfTheClass}");

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            foreach (FieldInfo field in classFields.Where(f=> fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] clasFields = classType.GetFields
                (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            MethodInfo[] classNonPublicMethods = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.NonPublic);

            MethodInfo[] classPublicMethods = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in clasFields)
            {
                sb.AppendLine(($"{field.Name} must be private "));
            }
            foreach (MethodInfo method in classNonPublicMethods.Where(f => f.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach(MethodInfo method in classPublicMethods.Where(f=> f.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
