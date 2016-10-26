using System.Xml.Linq;

namespace BL
{
    public interface IRepository
    {
        void Save(AbstractMovie[] movies);
        AbstractMovie[] Load();
    }
}