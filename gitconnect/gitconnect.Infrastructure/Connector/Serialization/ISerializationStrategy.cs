using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.Serialization
{
    public interface ISerializationStrategy<T>
    {
        T Deserialize(string json);
    }
}
