using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    interface ISignalPlace
    {
        Sensor createSensorKitchen();
        Sensor createSensorRoom();
        Sensor createSensorHall();
        Sensor createSensorGarage();
    }
}
