
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
        {
            var sb = new StringBuilder();
            var type = Type.GetType(className);
            sb.AppendLine($"Class under investigation: {type.FullName}");
            var test = Activator.CreateInstance(type);
            foreach (var fieldToSpy in fieldsToInvestigate)
            {
                var field = type.GetField(fieldToSpy, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                string spiedValue = field.GetValue(test).ToString();
                sb.AppendLine($"{field.Name} = {spiedValue}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
