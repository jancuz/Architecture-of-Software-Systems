using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class TemperatureSignalLowSensor: ISignalLowSensor
    {
        public Sensor createSensorKitchen()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Кухня, TypeOfSignal.Ниже_нормы);
        }
        public Sensor createSensorRoom()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Комната, TypeOfSignal.Ниже_нормы);
        }
        public Sensor createSensorHall()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Коридор, TypeOfSignal.Ниже_нормы);
        }
        public Sensor createSensorGarage()
        {
            return new Sensor(TypeOfSensor.Температуры, PlaceOfSensor.Гараж, TypeOfSignal.Ниже_нормы);
        }
    }
}
