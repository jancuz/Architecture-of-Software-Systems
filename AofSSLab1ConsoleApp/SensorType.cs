using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AofSSLab1ConsoleApp
{
    class SensorType
    {
        private static SensorType Type;
        public ETypeOfSensor NameType { get; private set; }
        protected SensorType(ETypeOfSensor nameType)
        {
            this.NameType = nameType;
        }
        public static SensorType getType(ETypeOfSensor nameType)
        {
            if (Type == null)
                Type = new SensorType(nameType);
            return Type;
        }
    }
}
