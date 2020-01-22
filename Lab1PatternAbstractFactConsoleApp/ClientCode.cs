using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class ClientCode
    {
        private List<Sensor> sensors = new List<Sensor>();

        static Random rnd = new Random();
        public ClientCode(ISensorsFactory factory, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int typeOfSignal = rnd.Next(0, 3);

                ISignalLowSensor signalLowSensor = null;
                ISignalNormSensor signalNormSensor = null;
                ISignalHighSensor signalHighSensor = null;

                switch (typeOfSignal)
                {
                    case 0:
                        signalLowSensor = factory.createSignalLowSensor();
                        break;
                    case 1:
                        signalNormSensor = factory.createSignalNormSensor();
                        break;
                    case 2:
                        signalHighSensor = factory.createSignalHighSensor();
                        break;
                }

                int typeOfPlace = rnd.Next(0, 4);
                if (signalLowSensor != null)
                {
                    switch (typeOfPlace)
                    {
                        case 0:
                            sensors.Add(signalLowSensor.createSensorKitchen());
                            break;
                        case 1:
                            sensors.Add(signalLowSensor.createSensorRoom());
                            break;
                        case 2:
                            sensors.Add(signalLowSensor.createSensorHall());
                            break;
                        case 3:
                            sensors.Add(signalLowSensor.createSensorGarage());
                            break;
                    }
                }

                if (signalNormSensor != null)
                {
                    switch (typeOfPlace)
                    {
                        case 0:
                            sensors.Add(signalNormSensor.createSensorKitchen());
                            break;
                        case 1:
                            sensors.Add(signalNormSensor.createSensorRoom());
                            break;
                        case 2:
                            sensors.Add(signalNormSensor.createSensorHall());
                            break;
                        case 3:
                            sensors.Add(signalNormSensor.createSensorGarage());
                            break;
                    }
                }

                if (signalHighSensor != null)
                {
                    switch (typeOfPlace)
                    {
                        case 0:
                            sensors.Add(signalHighSensor.createSensorKitchen());
                            break;
                        case 1:
                            sensors.Add(signalHighSensor.createSensorRoom());
                            break;
                        case 2:
                            sensors.Add(signalHighSensor.createSensorHall());
                            break;
                        case 3:
                            sensors.Add(signalHighSensor.createSensorGarage());
                            break;
                    }
                }
            }

        }

        public void WriteInfoAboutSensors()
        {
            foreach (var s in sensors)
                Console.WriteLine(s.ToString());
        }
    }
}
