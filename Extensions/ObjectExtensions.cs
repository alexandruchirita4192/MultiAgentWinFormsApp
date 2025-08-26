
using System.Reflection;

namespace MultiAgentWinFormsApp.Extensions
{
    public static class ObjectExtensions
    {
        public static void SetPropertyUsingReflection<T, V>(this T instance, string propertyName, V propertyValue)
        {
            if (instance == null)
                return;

            var instanceType = instance.GetType();
            var property = instanceType.GetProperties()
                ?.FirstOrDefault(property => property.Name == propertyName);

            if (property == null)
                property = instanceType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.FirstOrDefault(property => property.Name == propertyName);

            if (property?.CanWrite ?? false)
            {
                property.SetValue(instance, propertyValue);
            }
        }

        public static V GetPropertyUsingReflection<T, V>(this T instance, string propertyName)
        {
            if (instance == null)
                return default;

            var instanceType = instance.GetType();
            var property = instanceType.GetProperties()
                ?.FirstOrDefault(property => property.Name == propertyName);

            if (property == null)
                property = instanceType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.FirstOrDefault(property => property.Name == propertyName);

            return property?.CanRead ?? false
                ? (V)property.GetValue(instance)
                : default(V);
        }

        public static V GetFieldUsingReflection<T, V>(this T instance, string fieldName)
        {
            if (instance == null)
                return default;

            var instanceType = instance.GetType();
            var field = instanceType.GetFields()
                ?.FirstOrDefault(field => field.Name == fieldName);

            if (field == null)
                field = instanceType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.FirstOrDefault(field => field.Name == fieldName);

            return (V)field.GetValue(instance);
        }

        public static void SetFieldUsingReflection<T, V>(this T instance, string fieldName, V fieldValue)
        {
            if (instance == null)
                return;
            var instanceType = instance.GetType();
            var field = instanceType.GetFields()
                ?.FirstOrDefault(field => field.Name == fieldName);

            if (field == null)
                field = instanceType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.FirstOrDefault(field => field.Name == fieldName);

            if (field != null)
            {
                field.SetValue(instance, fieldValue);
            }
        }

        public static object? CallMethodUsingReflection<T>(this T instance, string methodName, params object[] parameters)
        {
            if (instance == null)
                return null;
            
            var instanceType = instance.GetType();
            var method = instanceType.GetMethods()
                ?.FirstOrDefault(method => method.Name == methodName);

            if (method == null)
                method = instanceType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.FirstOrDefault(method => method.Name == methodName);

            return method?.Invoke(instance, parameters);
        }
    }
}
