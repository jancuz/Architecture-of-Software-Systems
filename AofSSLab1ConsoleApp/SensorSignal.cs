using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AofSSLab1ConsoleApp
{
    class SensorSignal
    {
        private static SensorSignal Signal;
        public ETypeOfSignal NameSignal { get; private set; }
        protected SensorSignal(ETypeOfSignal nameSignal)
        {
            this.NameSignal = nameSignal;
        }
        public static SensorSignal getSignal(ETypeOfSignal nameSignal)
        {
            if (Signal == null)
                Signal = new SensorSignal(nameSignal);
            return Signal;
        }
    }
}
