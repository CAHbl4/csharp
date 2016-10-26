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

        public void Save(AbstractMovie[] movies)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                foreach (AbstractMovie movie in movies)
                    formatter.Serialize(stream, movie);
            }
        }

        public AbstractMovie[] Load()
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (AbstractMovie[]) formatter.Deserialize(stream);
            }
        }
    }
}