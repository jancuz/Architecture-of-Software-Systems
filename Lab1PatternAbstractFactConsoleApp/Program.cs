using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1PatternAbstractFactConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание датчиков температуры
            ClientCode cc1 = new ClientCode(new TemperatureSensorFactory(), 5);
            cc1.WriteInfoAboutSensors();

            // Создание датчиков влажности
            ClientCode cc2 = new ClientCode(new HumiditySensorFactory(), 5);
            cc2.WriteInfoAboutSensors();

            // Создание датчиков освещенности
            ClientCode cc3 = new ClientCode(new LightSensorFactory(), 5);
            cc3.WriteInfoAboutSensors();

            Console.ReadLine();
        }
    }
}
