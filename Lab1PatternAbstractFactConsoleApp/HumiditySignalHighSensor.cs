using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class HumiditySignalHighSensor: ISignalHighSensor
    {
        public Sensor createSensorKitchen()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Кухня, TypeOfSignal.Выше_нормы);
        }
        public Sensor createSensorRoom()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Комната, TypeOfSignal.Выше_нормы);
        }
        public Sensor createSensorHall()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Коридор, TypeOfSignal.Выше_нормы);
        }
        public Sensor createSensorGarage()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Гараж, TypeOfSignal.Выше_нормы);
        }
    }
}
