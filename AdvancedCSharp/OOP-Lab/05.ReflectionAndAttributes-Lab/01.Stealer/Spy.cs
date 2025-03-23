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
    }
}
