using System.IO;
using System.Runtime.Serialization;

namespace Labs.Timesheets.Domain.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T instance) where T : class
        {
            var serializer = new DataContractSerializer(typeof (T), null, int.MaxValue, false, true, null);
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, instance);
                stream.Position = 0;
                return (T) serializer.ReadObject(stream);
            }
        }
    }
}