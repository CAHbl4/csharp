using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Model
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAllCurrencies();
        Currency GetCurrencyByCode(int code);

    }
}