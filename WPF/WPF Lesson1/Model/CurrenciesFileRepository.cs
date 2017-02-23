using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class CurrenciesFileRepository : ICurrencyRepository
    {
        readonly List<Currency> currencies = new List<Currency>();
        readonly string path;

        public CurrenciesFileRepository(string path)
        {
            this.path = path;
            currencies.AddRange(LoadCurrencies());
        }


        public IEnumerable<Currency> GetAllCurrencies()
        {
            return currencies;
        }

        public Currency GetCurrencyByCode(int code)
        {
            return (currencies.Find(currency => currency.Code == code));
        }


        IEnumerable<Currency> LoadCurrencies()
        {
            List<Currency> result = new List<Currency>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    result.Add(CreateCurrencyFromCSV(reader.ReadLine()));
                }
            }
            return result;
        }

        static Currency CreateCurrencyFromCSV(string line)
        {
            string[] parts = line.Split(';');
            return new Currency {Code = int.Parse(parts[0]), Short = parts[1], Full = parts[2]};
        }
    }
}