using System.Collections.Generic;
using System.Xml.Linq;

namespace BL
{
    public interface IRepository
    {
        void Save(IEnumerable<AbstractMovie> movies);
        IEnumerable<AbstractMovie> Load();
    }
}