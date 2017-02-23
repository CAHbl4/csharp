using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Model
{
    public class RatesFileRepository : IRatesRepository
    {
        readonly ICurrencyRepository currencies;
        readonly string path;


        readonly Dictionary<Tuple<Currency, Currency>, decimal> rates =
            new Dictionary<Tuple<Currency, Currency>, decimal>();

        public RatesFileRepository(string path, ICurrencyRepository currencies)
        {
            this.path = path;
            this.currencies = currencies;
            LoadRates();
        }

        public decimal? GetRate(Currency from, Currency to)
        {
            return (rates.First(x => x.Key.Item1 == from && x.Key.Item2 == to).Value);
        }

        public IEnumerable<Currency> GetFrom()
        {
            var result = from rate in rates.Keys
                         select rate.Item1;
            return result.Distinct();
        }

        public IEnumerable<Currency> GetTo(Currency from)
        {
            var result = from rate in rates.Keys
                         where rate.Item1 == @from
                         select rate.Item2;
            return result.Distinct();
        }

        void LoadRates()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split(';');
                    rates.Add(
                        new Tuple<Currency, Currency>(
                            currencies.GetCurrencyByCode(int.Parse(parts[0])),
                            currencies.GetCurrencyByCode(int.Parse(parts[1]))
                        ),
                        decimal.Parse(parts[2]));
                }
            }
        }
    }
}