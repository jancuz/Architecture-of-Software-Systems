using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class TemperatureSignalNormSensor: ISignalNormSensor
    {
        public Sensor createSensorKitchen()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Кухня, TypeOfSignal.Норма);
        }
        public Sensor createSensorRoom()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Комната, TypeOfSignal.Норма);
        }
        public Sensor createSensorHall()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Коридор, TypeOfSignal.Норма);
        }
        public Sensor createSensorGarage()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Гараж, TypeOfSignal.Норма);
        }
    }
}
