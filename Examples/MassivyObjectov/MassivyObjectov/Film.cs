using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassivyObjectov
{
    //Класс «Фильм» должен содержать следующие элементы: поле название, поле фамилия режиссера, поле жанр (сериал, боевик, комедия и т.д.), поле затраты на каждую серию (массив), поле затраты на постановку трюков, конструктор с параметрами, метод  для получения затрат на съемку фильма, конструктор с параметрами, свойства для чтения полей класса.
    class Film
    {
        string title, director;
        string genre;
        decimal[] cost;
        decimal trukCost;
        public Film(string tit="",string dir="",string gnr="",decimal[] cst=null,decimal tCost=0)
        {
            title = tit;
            director = dir;
            genre = gnr;
            cost = cst;
            trukCost = tCost;
        }
        //метод для получения всех затрат
        public decimal GetSumCost()
        {
            decimal sum = cost.Sum()+trukCost;
            return sum;
        }
        public string Title
        {
            get { return title; }
        }
        public string Director
        {
            get { return director; }
        }
        public string Genre
        {
            get { return genre; }
        }
    }
}
