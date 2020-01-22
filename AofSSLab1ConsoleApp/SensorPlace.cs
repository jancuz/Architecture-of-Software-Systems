using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AofSSLab1ConsoleApp
{
    class SensorPlace
    {
        private static SensorPlace Place;
        public EPlaceOfSensor NamePlace { get; private set; }
        protected SensorPlace(EPlaceOfSensor namePlace)
        {
            this.NamePlace = namePlace;
        }
        public static SensorPlace getPlace(EPlaceOfSensor namePlace)
        {
            if (Place == null)
                Place = new SensorPlace(namePlace);
            return Place;
        }
    }
}
