using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.Serialization
{
    public class JSONNetSerializationStrategy<T> : ISerializationStrategy<T>
    {
        public T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
