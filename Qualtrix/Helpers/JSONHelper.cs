using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Qualtrix.Helpers
{
    /// <summary>
    /// Contains methods to help serialize and deserialize objects into/from json, to
    /// their equivalent .net object. This class is generic for faster use.
    /// </summary>
    /// <typeparam name="T">Type to which the object will be converted from/into.</typeparam>
    public class JSONHelper<T> where T: JsonEntities.SurveyResult
    {
        /// <summary>
        /// Deserializes an object.
        /// </summary>
        /// <param name="data">Data that needs deserializing.</param>
        /// <returns>Deserialized object.</returns>
        public static T Deserialize(string data)
        {
            try
            {
                var stream = new MemoryStream { Position = 0 };
                var writer = new StreamWriter(stream);

                writer.Write(data);
                writer.Flush();
                stream.Position = 0;

                var ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject(stream);
            }
            catch(Exception)
            {
                //TODO: handle
            }
            return null;
        }
    }
}
