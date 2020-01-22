using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class LightSensorFactory: ISensorsFactory
    {
        public ISignalHighSensor createSignalHighSensor()
        {
            return new LightSignalHighSensor();
        }

        public ISignalLowSensor createSignalLowSensor()
        {
            return new LightSignalLowSensor();
        }

        public ISignalNormSensor createSignalNormSensor()
        {
            return new LightSignalNormSensor();
        }
    }
}
