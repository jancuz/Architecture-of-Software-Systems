using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AofSSLab1ConsoleApp
{
    public enum ETypeOfSensor { Температуры, Влажности, Освещенности }
    public enum EPlaceOfSensor { Кухня, Комната, Коридор, Гараж }
    public enum ETypeOfSignal { Ниже_нормы, Норма, Выше_нормы }

    class Sensor
    {
        public SensorType Type { get; set; }
        public SensorPlace Place { get; set; }
        public SensorSignal Signal { get; set; }

        public void SelectTypeOfSensor(ETypeOfSensor nameType)
        {
            Type = SensorType.getType(nameType);
        }
        public void SelectPlaceOfSensor(EPlaceOfSensor namePlace)
        {
            Place = SensorPlace.getPlace(namePlace);
        }
        public void SelectTypeOfSignal(ETypeOfSignal nameSignal)
        {
            Signal = SensorSignal.getSignal(nameSignal);
        }

        public override string ToString()
        {
            return "Датчик: " + Type.NameType.ToString() + " Место: " + Place.NamePlace.ToString() + " Сигнал: " + Signal.NameSignal.ToString();
        }
    }
}