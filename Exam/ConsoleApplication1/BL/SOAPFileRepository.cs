using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace BL
{
    public class SOAPFileRepository : IRepository
    {
        readonly string filePath;
        readonly SoapFormatter formatter = new SoapFormatter();

        public SOAPFileRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save(IEnumerable<AbstractMovie> movies)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(stream, movies);
            }
        }

        public IEnumerable<AbstractMovie> Load()
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (IEnumerable<AbstractMovie>) formatter.Deserialize(stream);
            }
        }
    }
}