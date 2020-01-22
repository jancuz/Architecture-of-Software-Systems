using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class LightSignalNormSensor: ISignalNormSensor
    {
        public Sensor createSensorKitchen()
        {
            return new Sensor(TypeOfSensor.Освещенности, PlaceOfSensor.Кухня, TypeOfSignal.Норма);
        }
        public Sensor createSensorRoom()
        {
            return new Sensor(TypeOfSensor.Освещенности, PlaceOfSensor.Комната, TypeOfSignal.Норма);
        }
        public Sensor createSensorHall()
        {
            return new Sensor(TypeOfSensor.Освещенности, PlaceOfSensor.Коридор, TypeOfSignal.Норма);
        }
        public Sensor createSensorGarage()
        {
            return new Sensor(TypeOfSensor.Освещенности, PlaceOfSensor.Гараж, TypeOfSignal.Норма);
        }
    }
}
