using System.Collections.Generic;

namespace UI
{
    public interface IContainer
    {
        ICollection<IElement> Container { get; }
    }
}