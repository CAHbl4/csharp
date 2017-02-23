using System.Collections.Generic;

namespace Model
{
    public class Converter
    {
        readonly ICurrencyRepository currencies;
        readonly IRatesRepository rates;

        public Converter(ICurrencyRepository currencies, IRatesRepository rates)
        {
            this.currencies = currencies;
            this.rates = rates;
        }

        public decimal? Convert(Currency from, Currency to, decimal amount)
        {
            return (rates.GetRate(from, to) * amount);
        }
    }
}