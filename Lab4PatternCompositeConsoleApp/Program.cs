using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4PatternCompositeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Component lightSystem = new Composite("Автоматическая система освещения");
            // определяем систему освещения на улице
            Component lightSystemStreet = new Composite("Автоматическая система освещения на улице");
            // новые датчики, операционная панель и контроллер управления
            Component sensor1Str = new Sensor("Сенсор", Sensor.TypesOfSensors[2].ToString(), Sensor.TypesOfSignals[0].ToString());
            Component sensor2Str = new Sensor("Сенсор", Sensor.TypesOfSensors[2].ToString(), Sensor.TypesOfSignals[1].ToString());
            Component sensor3Str = new Sensor("Сенсор", Sensor.TypesOfSensors[2].ToString(), Sensor.TypesOfSignals[2].ToString());
            OperatorPanel operatorPanel = new OperatorPanel("Операционная панель", OperatorPanel.TypesOfOperatorPanes[0]);
            ManagmentController managmentController = new ManagmentController("Контроллер управления", ManagmentController.TypesOfControllers[0]);
            // добавляем созданные элементы системы автоматического овещения на улице
            lightSystemStreet.Add(sensor1Str);
            lightSystemStreet.Add(sensor2Str);
            lightSystemStreet.Add(sensor3Str);
            lightSystemStreet.Add(operatorPanel);
            lightSystemStreet.Add(managmentController);
            // добавляем уличнную систему освещения в автоматическую систему освещения
            lightSystem.Add(lightSystemStreet);
            // выводим все данные
            lightSystem.GetFunction();
            Console.WriteLine();
            // удаляем из системы уличного освещения датчик 1
            lightSystemStreet.Remove(sensor1Str);
            // создаем новую систему освещения для парка
            Component lightSystemPark = new Composite("Автоматическая система освещения парка");
            // добавляем в нее новые датчики
            Component sensor1Park = new Sensor("Сенсор", Sensor.TypesOfSensors[2].ToString(), Sensor.TypesOfSignals[0].ToString());
            Component sensor2Park = new Sensor("Сенсор", Sensor.TypesOfSensors[2].ToString(), Sensor.TypesOfSignals[0].ToString());
            lightSystemPark.Add(sensor1Park);
            lightSystemPark.Add(sensor2Park);
            lightSystem.Add(lightSystemPark);

            lightSystem.GetFunction();

            Console.Read();
        }
    }

    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void GetFunction()
        {
            Console.WriteLine(name);
        }
    }

    public class Composite : Component
    {
        private List<Component> children = new List<Component>();

        public Composite(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void GetFunction()
        {
            Console.WriteLine(name);

            foreach (Component component in children)
            {
                component.GetFunction();
            }
        }
    }

    // Датчик
    public class Sensor: Component
    {
        public static List<string> TypesOfSensors = new List<string>() { "Влажность", "Температура", "Освещенность" };
        public static List<string> TypesOfSignals = new List<string>() { "Ниже нормы", "Норма", "Выше нормы" };

        public string TypeOfSensor { get; set; }
        public string TypeOfSignal { get; set; }

        public Sensor(string name, string typeOfSensor, string typeOfSignal): base(name)
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
    class Actuator: Component
    {
        public static List<string> TypesOfActuators = new List<string>() { "Электромеханические приводы открытия/закрытия ворот", "Электромеханические приводы открытия/закрытия калиток",
    "Электромеханические приводы открытия/закрытия дверей", "Электромеханические приводы открытия/закрытия окон", "Электромеханические приводы открытия/закрытия жалюзей и штор",
    "Встроенные в мебель электромеханические детали", "Клапаны низкого, среднего и высокого давления"};
        public string TypeOfActuator { get; set; }
        public Actuator(string name, string typeOfActuator): base(name)
        {
            TypeOfActuator = typeOfActuator;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfActuator); 
        }
    }

    // Панель оператора
    class OperatorPanel: Component
    {
        public static List<string> TypesOfOperatorPanes = new List<string>() { "Пульт", "Панель управления", "Мобильные устройства" };
        public string TypeOfOperatorPanel { get; set; }
        public OperatorPanel(string name, string typeOfOperatorPanel):base(name)
        {
            TypeOfOperatorPanel = typeOfOperatorPanel;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfOperatorPanel);
        }
    }

    // Мультимедиа системы
    class MultimediaSystem: Component
    {
        public static List<string> TypesOfMultimediaSystems = new List<string>() { "Домашний кинотеатр", "Аудио-оборудование", "Видео-оборудование" };
        public string TypeOfMS { get; set; }
        public MultimediaSystem(string name, string typeOfMS): base(name)
        {
            TypeOfMS = typeOfMS;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfMS);
        }
    }

    // Контроллеры управления 
    class ManagmentController: Component
    {
        public static List<string> TypesOfControllers = new List<string>() { "Центральный", "Региональный" };
        public string TypeOfController { get; set; }
        public ManagmentController(string name, string typeOfController): base(name)
        {
            TypeOfController = typeOfController;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfController);
        }
    }

    // Сетевые устройства
    class NetworkDevice: Component
    {
        public static List<string> TypesOfNetDevices = new List<string>() { "ПК", "Планшет", "Смартфон" };
        public string TypeOfNetDevice { get; set; }
        public NetworkDevice(string name, string typeOfNetDevice): base(name)
        {
            TypeOfNetDevice = typeOfNetDevice;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " Функция: " + TypeOfNetDevice);
        }
    }

}
