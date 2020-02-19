using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9PatternObserverConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenary scenary = new Scenary();
            Kitchen kitchen = new Kitchen("Кухня1", scenary);
            Garage garage = new Garage("Гараж1", scenary);
            // имитация создания сценария для умного дома
            scenary.CreaateScenary();
            // отключение кухни от системы умного дома
            kitchen.StopFollowScenary();
            // имитация создания сценария для умного дома
            scenary.CreaateScenary();

            Console.Read();
        }
    }

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class Scenary : IObservable
    {
        ScenaryInfo sInfo; // информация о торгах

        List<IObserver> observers;
        public Scenary()
        {
            observers = new List<IObserver>();
            sInfo = new ScenaryInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void CreaateScenary()
        {
            Random rnd = new Random();
            ScenaryInfo si = new ScenaryInfo();
            int countDevices = rnd.Next(1, si.devices.Count() + 1);
            sInfo.Devices = new List<int>();
            for (int i = 0; i < countDevices; i++)
                sInfo.Devices.Add(rnd.Next(1, si.devices.Count() + 1));

            NotifyObservers();
        }
    }

    class ScenaryInfo
    {
        public Dictionary<int, string> devices = new Dictionary<int, string>();

        public ScenaryInfo()
        {
            devices.Add(1, "Датчик");
            devices.Add(2, "Исполнительный механизм");
            devices.Add(3, "Панель оператора");
            devices.Add(4, "Мультимедиа системы");
            devices.Add(5, "Сетевые устройства");
        }


        public List<int> Devices { get; set; }


    }

    class Kitchen : IObserver
    {
        public Random rnd;
        public string Name { get; set; }
        IObservable scenaryToFollow;
        public Kitchen(string name, IObservable obs)
        {
            this.Name = name;
            scenaryToFollow = obs;
            scenaryToFollow.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            ScenaryInfo sInfo = (ScenaryInfo)ob;
            rnd = new Random();
            Console.WriteLine("Помещение: " + Name);
            // девайсы
            foreach(var d in sInfo.Devices)
                switch (d)
                {
                    case 1:
                        Sensor sensor = new Sensor("Сенсор", Sensor.TypesOfSensors.ElementAt(rnd.Next(0, Sensor.TypesOfSensors.Count())),
                                                    Sensor.TypesOfSignals.ElementAt(rnd.Next(0, Sensor.TypesOfSignals.Count())));
                        sensor.GetFunction();
                        break;
                    case 2:
                        Actuator actuator = new Actuator("Исполнительный механизм", Actuator.TypesOfActuators.ElementAt(rnd.Next(2, Actuator.TypesOfActuators.Count())));
                        actuator.GetFunction();
                        break;
                    case 3:
                        OperatorPanel operatorPanel = new OperatorPanel("Панель оператора", OperatorPanel.TypesOfOperatorPanes.ElementAt(rnd.Next(0, OperatorPanel.TypesOfOperatorPanes.Count())));
                        operatorPanel.GetFunction();
                        break;
                    case 4:
                        MultimediaSystem multimediaSystem = new MultimediaSystem("Мультимедиа система", MultimediaSystem.TypesOfMultimediaSystems.ElementAt(rnd.Next(0, MultimediaSystem.TypesOfMultimediaSystems.Count())));
                        multimediaSystem.GetFunction();
                        break;
                    case 5:
                        NetworkDevice networkDevice = new NetworkDevice("Сетевое устройство", NetworkDevice.TypesOfNetDevices.ElementAt(rnd.Next(0, NetworkDevice.TypesOfNetDevices.Count())));
                        networkDevice.GetFunction();
                        break;
                }
        }
        public void StopFollowScenary()
        {
            scenaryToFollow.RemoveObserver(this);
            scenaryToFollow = null;
        }
    }

    class Garage : IObserver
    {
        public Random rnd;
        public string Name { get; set; }
        IObservable scenaryToFollow;
        public Garage(string name, IObservable obs)
        {
            this.Name = name;
            scenaryToFollow = obs;
            scenaryToFollow.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            ScenaryInfo sInfo = (ScenaryInfo)ob;
            rnd = new Random();
            Console.WriteLine("Помещение: " + Name);
            // девайсы
            foreach (var d in sInfo.Devices)
                switch (d)
                {
                    case 1:
                        Sensor sensor = new Sensor("Сенсор", Sensor.TypesOfSensors.ElementAt(rnd.Next(0, Sensor.TypesOfSensors.Count())),
                                                    Sensor.TypesOfSignals.ElementAt(rnd.Next(0, Sensor.TypesOfSignals.Count())));
                        sensor.GetFunction();
                        break;
                    case 2:
                        Actuator actuator = new Actuator("Исполнительный механизм", Actuator.TypesOfActuators.ElementAt(rnd.Next(0, 5)));
                        actuator.GetFunction();
                        break;
                    case 3:
                        OperatorPanel operatorPanel = new OperatorPanel("Панель оператора", OperatorPanel.TypesOfOperatorPanes.ElementAt(rnd.Next(0, OperatorPanel.TypesOfOperatorPanes.Count())));
                        operatorPanel.GetFunction();
                        break;
                    case 4:
                        MultimediaSystem multimediaSystem = new MultimediaSystem("Мультимедиа система", MultimediaSystem.TypesOfMultimediaSystems.ElementAt(rnd.Next(0, MultimediaSystem.TypesOfMultimediaSystems.Count())));
                        multimediaSystem.GetFunction();
                        break;
                    case 5:
                        NetworkDevice networkDevice = new NetworkDevice("Сетевое устройство", NetworkDevice.TypesOfNetDevices.ElementAt(rnd.Next(0, NetworkDevice.TypesOfNetDevices.Count())));
                        networkDevice.GetFunction();
                        break;
                }
        }
    }


    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void GetFunction()
        {
            Console.WriteLine(name);
        }
    }
    // Датчик
    public class Sensor : Component
    {
        public static List<string> TypesOfSensors = new List<string>() { "Влажность", "Температура", "Освещенность" };
        public static List<string> TypesOfSignals = new List<string>() { "Ниже нормы", "Норма", "Выше нормы" };

        public string TypeOfSensor { get; set; }
        public string TypeOfSignal { get; set; }

        public Sensor(string name, string typeOfSensor, string typeOfSignal) : base(name)
        {
            TypeOfSensor = typeOfSensor;
            TypeOfSignal = typeOfSignal;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfSensor + " " + TypeOfSignal);
        }
    }

    // Исполнительный механизм
    class Actuator : Component
    {
        public static List<string> TypesOfActuators = new List<string>() { "Электромеханические приводы открытия/закрытия ворот", "Электромеханические приводы открытия/закрытия калиток",
    "Электромеханические приводы открытия/закрытия дверей", "Электромеханические приводы открытия/закрытия окон", "Электромеханические приводы открытия/закрытия жалюзей и штор",
    "Встроенные в мебель электромеханические детали", "Клапаны низкого, среднего и высокого давления"};
        public string TypeOfActuator { get; set; }
        public Actuator(string name, string typeOfActuator) : base(name)
        {
            TypeOfActuator = typeOfActuator;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfActuator);
        }
    }

    // Панель оператора
    class OperatorPanel : Component
    {
        public static List<string> TypesOfOperatorPanes = new List<string>() { "Пульт", "Панель управления", "Мобильные устройства" };
        public string TypeOfOperatorPanel { get; set; }
        public OperatorPanel(string name, string typeOfOperatorPanel) : base(name)
        {
            TypeOfOperatorPanel = typeOfOperatorPanel;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfOperatorPanel);
        }
    }

    // Мультимедиа системы
    class MultimediaSystem : Component
    {
        public static List<string> TypesOfMultimediaSystems = new List<string>() { "Домашний кинотеатр", "Аудио-оборудование", "Видео-оборудование" };
        public string TypeOfMS { get; set; }
        public MultimediaSystem(string name, string typeOfMS) : base(name)
        {
            TypeOfMS = typeOfMS;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfMS);
        }
    }

    // Сетевые устройства
    class NetworkDevice : Component
    {
        public static List<string> TypesOfNetDevices = new List<string>() { "ПК", "Планшет", "Смартфон" };
        public string TypeOfNetDevice { get; set; }
        public NetworkDevice(string name, string typeOfNetDevice) : base(name)
        {
            TypeOfNetDevice = typeOfNetDevice;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfNetDevice);
        }
    }
}
