using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class Sensor
    {
        TypeOfSensor Type;
        PlaceOfSensor Place;
        TypeOfSignal Signal;
        public Sensor(TypeOfSensor t, PlaceOfSensor p, TypeOfSignal s)
        {
            Type = t;
            Place = p;
            Signal = s;
        }
        public override string ToString()
        {
            return "Датчик: " + Type + " Место: " + Place + " Сигнал: " + Signal;
        }
    }

    public enum TypeOfSensor { Температуры, Влажности, Освещенности }
    public enum PlaceOfSensor { Кухня, Комната, Коридор, Гараж }
    public enum TypeOfSignal { Ниже_нормы, Норма, Выше_нормы }
}
