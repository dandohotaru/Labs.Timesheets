using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Labs.Extensions
{
    public static class DumpExtensions
    {
        public static string Dump<T>(this T instance)
        {
            if (instance is string)
            {
                return Dump(instance.ToString());
            }
            if (instance is IQueryable)
            {
                return Dump(instance.ToString());
            }
            if (instance is IEnumerable)
            {
                return Dump(instance as IEnumerable);
            }
            return Dump((object) instance);
        }

        private static string Dump(IEnumerable instance)
        {
            var builder = new StringBuilder();
            foreach (var item in instance)
            {
                builder.AppendFormat("{0}", item);
                builder.AppendFormat("\n");
            }
            var result = builder.ToString();
            Console.WriteLine(result);
            return result;
        }

        private static string Dump(object instance)
        {
            var builder = new StringBuilder()
                .Append(instance);

            var result = builder.ToString();
            Console.WriteLine(result);
            return result;
        }

        private static string Dump(string instance)
        {
            Console.WriteLine(instance);
            return instance;
        }
    }
}