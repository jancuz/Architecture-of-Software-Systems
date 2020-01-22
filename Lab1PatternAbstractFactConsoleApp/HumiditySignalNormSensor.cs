using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class HumiditySignalNormSensor: ISignalNormSensor
    {
        public Sensor createSensorKitchen()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Кухня, TypeOfSignal.Норма);
        }
        public Sensor createSensorRoom()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Комната, TypeOfSignal.Норма);
        }
        public Sensor createSensorHall()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Коридор, TypeOfSignal.Норма);
        }
        public Sensor createSensorGarage()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Гараж, TypeOfSignal.Норма);
        }
    }
}
