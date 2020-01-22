using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AofSSLab1ConsoleApp
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Sensor sens = new Sensor();
            sens.SelectTypeOfSensor(ETypeOfSensor.Влажности);
            sens.SelectTypeOfSignal(ETypeOfSignal.Норма);
            sens.SelectPlaceOfSensor(EPlaceOfSensor.Кухня);
            //Console.WriteLine(sens.Type.NameType);
            //Console.WriteLine(sens.Signal.NameSignal);
            //Console.WriteLine(sens.Place.NamePlace);
            Console.WriteLine(sens.ToString());

            // у нас не получится изменить тип, сигнал и место, так как объект уже создан   
            Console.WriteLine("Попытка изменения объекта");
            sens.Type = SensorType.getType(ETypeOfSensor.Освещенности);
            //Console.WriteLine(sens.Type.NameType);
            sens.Signal = SensorSignal.getSignal(ETypeOfSignal.Выше_нормы);
            //Console.WriteLine(sens.Signal.NameSignal);
            sens.Place = SensorPlace.getPlace(EPlaceOfSensor.Комната);
            //Console.WriteLine(sens.Place.NamePlace);
            Console.WriteLine(sens.ToString());

            Console.ReadLine();
        }
    }
}
