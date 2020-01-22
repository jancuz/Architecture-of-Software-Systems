using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class HumiditySignalLowSensor: ISignalLowSensor
    {
        public Sensor createSensorKitchen()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Кухня, TypeOfSignal.Ниже_нормы);
        }
        public Sensor createSensorRoom()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Комната, TypeOfSignal.Ниже_нормы);
        }
        public Sensor createSensorHall()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Коридор, TypeOfSignal.Ниже_нормы);
        }
        public Sensor createSensorGarage()
        {
            return new Sensor(TypeOfSensor.Влажности, PlaceOfSensor.Гараж, TypeOfSignal.Ниже_нормы);
        }
    }
}
