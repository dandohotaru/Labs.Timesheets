using System;
using System.Collections;
using System.Text;

namespace Labs.Timesheets.Tests.Common.Extensions
{
    public static class DebugExtensions
    {
        public static void Dump<T>(this T instance)
        {
            var collection = instance as IEnumerable;
            if (collection != null)
            {
                When(collection);
                return;
            }

            When(instance);
        }

        private static void When(IEnumerable instance)
        {
            var builder = new StringBuilder();
            foreach (var item in instance)
            {
                builder.AppendFormat("{0}", item);
                builder.AppendFormat("\n");
            }
            Console.WriteLine(builder.ToString());
        }

        private static void When(object instance)
        {
            var builder = new StringBuilder()
                .Append(instance);

            Console.WriteLine(builder.ToString());
        }
    }
}