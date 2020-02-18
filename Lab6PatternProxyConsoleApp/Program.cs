using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6PatternProxyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent component = new ComponentStoreProxy();
            // информация о датчике id=1 извлекается из "БД"
            Component component1 = component.GetComponent(1);
            component1.GetFunction();
            Component component2 = component.GetComponent(2);
            component2.GetFunction();   
            // информация о датчике id=1 извлекается из Proxy
            component1 = component.GetComponent(1);
            component1.GetFunction();


            Console.Read();
        }
    }

    public abstract class Component
    {
        public int id;
        protected string name;
        protected DateTime date;

        public Component(int id, string name, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.date = date;
        }

        public virtual void GetFunction()
        {
            Console.WriteLine(id + ' ' + name + ' ' + date);
        }
    }

    // Датчик
    public class Sensor: Component
    {
        public static List<string> TypesOfSensors = new List<string>() { "Влажность", "Температура", "Освещенность" };
        public static List<string> TypesOfSignals = new List<string>() { "Ниже нормы", "Норма", "Выше нормы" };

        public string TypeOfSensor { get; set; }
        public string TypeOfSignal { get; set; }

        public Sensor(int id, string name, DateTime date, string typeOfSensor, string typeOfSignal):base(id, name, date)
        {
            TypeOfSensor = typeOfSensor;
            TypeOfSignal = typeOfSignal;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " ID: " + id + " Функция: " + TypeOfSensor + " Сигнал:" + TypeOfSignal + " " + date);
        }
    }

    // Исполнительный механизм
    class Actuator: Component
    {
        public static List<string> TypesOfActuators = new List<string>() { "Электромеханические приводы открытия/закрытия ворот", "Электромеханические приводы открытия/закрытия калиток",
    "Электромеханические приводы открытия/закрытия дверей", "Электромеханические приводы открытия/закрытия окон", "Электромеханические приводы открытия/закрытия жалюзей и штор"};
        public static List<string> StatusesOfActuators = new List<string>() { "Открыто", "Закрыто" };

        public string TypeOfActuator { get; set; }
        public string StatusOfActuator { get; set; }
        //public string Name = "Исполнительный механизм";

        public Actuator(int id, string name, DateTime date, string typeOfActuator, string statusOfActuator):base(id, name, date)
        {
            TypeOfActuator = typeOfActuator;
            StatusOfActuator = statusOfActuator;
        }
        public override void GetFunction()
        {
            Console.WriteLine("Тип устройства: " + name + " ID: " + id + " Функция: " + TypeOfActuator + " Статус: " + StatusOfActuator + " " + date);
        }
    }

    interface IComponent
    {
        Component GetComponent(int id);
    }

    /// <summary>
    /// Реализация "БД" с информацией о показателях датчиков.
    /// </summary>
    class ComponentContext
    {
        public List<Component> Components { get; set; }
        public ComponentContext()
        {
            Components = new List<Component>();
            int id = 1;
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[0], Sensor.TypesOfSignals[0]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[0], Sensor.TypesOfSignals[1]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[0], Sensor.TypesOfSignals[2]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[1], Sensor.TypesOfSignals[0]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[1], Sensor.TypesOfSignals[1]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[1], Sensor.TypesOfSignals[2]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[2], Sensor.TypesOfSignals[0]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[2], Sensor.TypesOfSignals[1]));
            Components.Add(new Sensor(id++, "Сенсор", DateTime.Now, Sensor.TypesOfSensors[2], Sensor.TypesOfSignals[2]));
            Components.Add(new Actuator(id++, "Исполнительный механизм", DateTime.Now, Actuator.TypesOfActuators[0], Actuator.StatusesOfActuators[0]));
            Components.Add(new Actuator(id++, "Исполнительный механизм", DateTime.Now, Actuator.TypesOfActuators[1], Actuator.StatusesOfActuators[0]));
            Components.Add(new Actuator(id++, "Исполнительный механизм", DateTime.Now, Actuator.TypesOfActuators[2], Actuator.StatusesOfActuators[1]));
        }
    }

    class ComponentStore : IComponent
    {
        ComponentContext db;
        public ComponentStore()
        {
            db = new ComponentContext();
        }
        public Component GetComponent(int id)
        {
            return db.Components.FirstOrDefault(c => c.id == id);
        }
    }

    /// <summary>
    /// В Proxy реализовано считываение данных из "БД" и организация доступа к ним.
    /// </summary>
    class ComponentStoreProxy: IComponent
    {
        List<Component> components;
        ComponentStore componentStore;
        public ComponentStoreProxy()
        {
            components = new List<Component>();
        }
        public Component GetComponent(int id)
        {
            Component component = components.FirstOrDefault(c => c.id == id);
            if(component == null)
            {
                if (componentStore == null)
                    componentStore = new ComponentStore();
                component = componentStore.GetComponent(id);
                components.Add(component);
            }
            return component;
        }
    }
}