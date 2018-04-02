namespace Reflection
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            var fields = Type
                .GetType(classToInvestigate)
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            var classInstance = Activator.CreateInstance(Type.GetType(classToInvestigate));

            foreach (var field in fields)
            {
                if (fieldsToInvestigate.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string classToInvestigate)
        {
            var type = Type.GetType(classToInvestigate);
            var classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            var classPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var classPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var sb = new StringBuilder();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classPrivateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string classToInvestigate)
        {
            var classType = Type.GetType(classToInvestigate);
            var classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {classToInvestigate}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in classMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            var targetType = Type.GetType(className);
            var methods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var sb = new StringBuilder();

            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}