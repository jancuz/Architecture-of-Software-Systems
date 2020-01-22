using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class TemperatureSensorFactory : ISensorsFactory
    {
        public ISignalHighSensor createSignalHighSensor()
        {
            return new TemperatureSignalHighSensor();
        }

        public ISignalLowSensor createSignalLowSensor()
        {
            return new TemperatureSignalLowSensor();
        }

        public ISignalNormSensor createSignalNormSensor()
        {
            return new TemperatureSignalNormSensor();
        }
    }
}
