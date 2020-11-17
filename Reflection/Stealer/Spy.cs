
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();
            var type = Type.GetType(className);
            var publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            foreach (var field in publicFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            var nonpublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in nonpublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in publicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            
            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();
            var type = Type.GetType(className);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            
            foreach (var method in privateMethods)
            {               
                sb.AppendLine(method.Name);
            }
            return sb.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();
            var type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{ method.Name} will return {method.ReturnType.FullName}");
            }
            
            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
