using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class HumiditySensorFactory: ISensorsFactory
    {
        public ISignalHighSensor createSignalHighSensor()
        {
            return new HumiditySignalHighSensor();
        }

        public ISignalLowSensor createSignalLowSensor()
        {
            return new HumiditySignalLowSensor();
        }

        public ISignalNormSensor createSignalNormSensor()
        {
            return new HumiditySignalNormSensor();
        }
    }
}
