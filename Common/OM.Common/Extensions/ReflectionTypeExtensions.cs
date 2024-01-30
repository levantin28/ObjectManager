using System.Reflection;

namespace OM.Common.Extensions
{
    public static class ReflectionTypeExtensions
    {
        /// <summary>
        /// When called with the type of an generic interface (i.e. <see cref="IEventHandler{TEvent}"/>), searches the given assembly for all implementations of the interface
        /// and returns a list of the classes implementing said interface (i.e. LocationEventHandler)
        /// </summary>
        /// <param name="type">A generic interface (i.e. <see cref="IEventHandler{TEvent}"/>)</param>
        /// <param name="assembly">The assembly in which to search implementations, if null will default to calling assembly</param>
        /// <returns>A list of the handlers implementing said interface</returns>
        public static IEnumerable<Type> GetImplementationsOfType(this Type type, Assembly assembly = null)
        {
            assembly ??= Assembly.GetCallingAssembly();

            return assembly.DefinedTypes.Where(t => t.ImplementedInterfaces.Contains(type)).Select(t => t.AsType());
        }

        /// <summary>
        /// When called with the type of an generic interface (i.e. <see cref="IEventHandler{TEvent}"/>), searches the given assembly for all implementations of the interface
        /// and returns a dictionary containing containing as the key the specific interface (i.e. <see cref="IEventHandler{Event}"/>) and as value it's implementation
        /// (i.e. LocationEventHandler)
        /// </summary>
        /// <param name="type">A generic interface (i.e. <see cref="IEventHandler{TEvent}"/>)</param>
        /// <param name="assembly">The assembly in which to search implementations, if null will default to calling assembly</param>
        /// <returns> { <see cref="IEventHandler{Event}"/>, LocationEventHandler } </returns>
        public static Dictionary<Type, Type> GetDefinitionAndImplementationsOfType(this Type type,//ICommandHandler<>
            Assembly assembly = null)
        {
            assembly ??= Assembly.GetCallingAssembly();

            var result = new Dictionary<Type, Type>();

            //Iterate all implementations of type
            foreach (var typeInfo in assembly.DefinedTypes.Where(t => t.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition().Equals(type))))
            {
                var implementationType = typeInfo.AsType();
                var interfaces = implementationType.GetInterfaces();

                foreach (var def in interfaces)
                {
                    var paramTypes = def.GetGenericArguments();
                    result.Add(type.MakeGenericType(paramTypes), implementationType);
                }
            }

            return result;
        }

        public static MethodInfo GetMethodWithParameterType(this Type type, string methodName, Type paramType)
        {
            return type.GetMethods().FirstOrDefault(t => t.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase)
                                                         && t.GetParameters().FirstOrDefault().ParameterType ==
                                                         paramType);
        }

        public static async Task<object> InvokeAsync(this object @this, object obj, string methodName, params object[] parameters)
        {
            var task = (Task)@this.GetType().GetMethodWithParameterType(methodName, parameters.First().GetType()).Invoke(obj, parameters);
            await task.ConfigureAwait(false);

            var resultProp = task.GetType().GetProperty("Result");
            return resultProp.GetValue(task);
        }
    }
}
