using System;
using System.Collections;
using System.Text;

namespace Labs.Timesheets.Tests.Common
{
    public static class FixtureExtensions
    {
        public static void Dump<T>(this T instance)
        {
            var collection = instance as IEnumerable;
            if (collection != null)
            {
                Dump(collection);
                return;
            }

            Dump((object) instance);
        }

        private static void Dump(IEnumerable instance)
        {
            var builder = new StringBuilder();
            foreach (var item in instance)
            {
                builder.AppendFormat("{0}", item);
                builder.AppendFormat("\n");
            }
            Console.WriteLine(builder.ToString());
        }

        private static void Dump(object instance)
        {
            var builder = new StringBuilder()
                .Append(instance);

            Console.WriteLine(builder.ToString());
        }
    }
}