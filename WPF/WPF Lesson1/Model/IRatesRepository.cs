using System.Collections.Generic;

namespace Model
{
    public interface IRatesRepository
    {
        decimal? GetRate(Currency from, Currency to);
        IEnumerable<Currency> GetFrom();
        IEnumerable<Currency> GetTo(Currency from);
    }
}