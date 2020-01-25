using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2PatternBuilderConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new SHwithOperatorPanel_RC();
            Director director = new Director(builder);
            director.Construct();
            SmartHouse SH = builder.GetSmartHouse();
            Console.WriteLine(SH.ToString());

            builder = new SHwithOperatorPanel_CP();
            director = new Director(builder);
            director.Construct();
            SH = builder.GetSmartHouse();
            Console.WriteLine(SH.ToString());

            Console.ReadLine();

        }
    }

    // Датчик
    class Sensor
    {
        public static List<string> TypesOfSensors = new List<string>() { "Влажность", "Температура", "Освещенность" };
        public static List<string> TypesOfSignals = new List<string>() { "Ниже нормы", "Норма", "Выше нормы" };

        public string TypeOfSensor { get; set; }
        public string TypeOfSignal { get; set; }
        public int Count { get; set; }
    }

    // Исполнительный механизм
    class Actuator
    {
        public static List<string> TypesOfActuators = new List<string>() { "Электромеханические приводы открытия/закрытия ворот", "Электромеханические приводы открытия/закрытия калиток",
    "Электромеханические приводы открытия/закрытия дверей", "Электромеханические приводы открытия/закрытия окон", "Электромеханические приводы открытия/закрытия жалюзей и штор",
    "Встроенные в мебель электромеханические детали", "Клапаны низкого, среднего и высокого давления"};
        public string TypeOfActuator { get; set; }
    }

    // Панель оператора
    class OperatorPanel
    {
        public static List<string> TypesOfOperatorPanes = new List<string>() { "Пульт", "Панель управления", "Мобильные устройства" };
        public string TypeOfOperatorPanel { get; set; }
    }

    // Мультимедиа системы
    class MultimediaSystem
    {
        public static List<string> TypesOfMultimediaSystems = new List<string>() { "Домашний кинотеатр", "Аудио-оборудование", "Видео-оборудование" };
        public string TypeOfMS { get; set; }
    }

    // Контроллеры управления 
    class ManagmentController
    {
        public static List<string> TypesOfControllers = new List<string>() { "Центральный", "Региональный" };
        public string TypeOfController { get; set; }
    }

    // Сетевые устройства
    class NetworkDevice
    {
        public static List<string> TypesOfNetDevices = new List<string>() { "ПК", "Планшет", "Смартфон" };
        public string TypeOfNetDevice { get; set; }
    }

    class SmartHouse
    {
        public List<Sensor> Sensors { get; set; }
        public List<Actuator> Actuators { get; set; }
        public List<OperatorPanel> OperatorPanels { get; set; }
        public List<MultimediaSystem> MultimediaSystems { get; set; }
        public List<ManagmentController> ManagmentControllers { get; set; }
        public List<NetworkDevice> NetworkDevices { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Sensors != null)
                sb.Append("Сенсоры: \n");
            for (int i = 0; i < Sensors.Count(); i++)
                if(Sensors[i].Count > 0)
                    sb.Append(Sensors[i].TypeOfSensor + " " + Sensors[i].TypeOfSignal + " кол-во:" + Sensors[i].Count + "\n");

            if (OperatorPanels != null)
                sb.Append("Панели оператора: \n");
            for (int i = 0; i < OperatorPanels.Count(); i++)
                sb.Append(OperatorPanels[i].TypeOfOperatorPanel + "\n");

            if (Actuators != null)
                sb.Append("Исполнительные механизмы: \n");
            for (int i = 0; i < Actuators.Count(); i++)
                sb.Append(Actuators[i].TypeOfActuator + "\n");

            if (MultimediaSystems != null)
                sb.Append("Мультимедиа системы: \n");
            for (int i = 0; i < MultimediaSystems.Count(); i++)
                sb.Append(MultimediaSystems[i].TypeOfMS + "\n");

            if (ManagmentControllers != null)
                sb.Append("Контроллеры управления: \n");
            for (int i = 0; i < ManagmentControllers.Count(); i++)
                sb.Append(ManagmentControllers[i].TypeOfController + "\n");

            if (NetworkDevices != null)
                sb.Append("Сетевые устройства: \n");
            for (int i = 0; i < NetworkDevices.Count(); i++)
                sb.Append(NetworkDevices[i].TypeOfNetDevice + "\n");

            return sb.ToString();
        }
    }

    abstract class Builder
    {
        public SmartHouse SmartHouse { get; private set; }
        public void CreateSmartHouse()
        {
            SmartHouse = new SmartHouse();
        }
        public abstract void SetSensors();
        public abstract void SetOperatorPanels();
        public abstract void SetActuators();
        public abstract void SetMultimediaSystems();
        public abstract void SetManagmentControllers();
        public abstract void SetNetworkDevices();
        public abstract SmartHouse GetSmartHouse();
    }

    class Director
    {
        Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.CreateSmartHouse();
            builder.SetSensors();
            builder.SetOperatorPanels();
            builder.SetActuators();
            builder.SetMultimediaSystems();
            builder.SetManagmentControllers();
            builder.SetNetworkDevices();
        }
    }

    // SH с панель оператора - пульт
    class SHwithOperatorPanel_RC : Builder
    {
        SmartHouse SmartHouse = new SmartHouse();
        static Random rnd = new Random();

        // Различные механизмы
        public override void SetActuators()
        {
            SmartHouse.Actuators = new List<Actuator>();
            for(int i = 0; i < Actuator.TypesOfActuators.Count(); i++)
            {
                if(rnd.Next(0, 2) == 1)
                {
                    Actuator a = new Actuator();
                    a.TypeOfActuator = Actuator.TypesOfActuators[i];
                    SmartHouse.Actuators.Add(a);
                }
            }
        }

        // Различные контроллеры управления
        public override void SetManagmentControllers()
        {
            SmartHouse.ManagmentControllers = new List<ManagmentController>();
            int count = rnd.Next(1, ManagmentController.TypesOfControllers.Count() + 1);
            if(count == 1)
            {
                ManagmentController mc = new ManagmentController();
                mc.TypeOfController = ManagmentController.TypesOfControllers[rnd.Next(0, ManagmentController.TypesOfControllers.Count())];
                SmartHouse.ManagmentControllers.Add(mc);
            }
            else
                for(int i = 0; i < count; i++)
                {
                    ManagmentController mc = new ManagmentController();
                    mc.TypeOfController = ManagmentController.TypesOfControllers[i];
                    SmartHouse.ManagmentControllers.Add(mc);
                }
        }

        // Система мультимедиа
        public override void SetMultimediaSystems()
        {
            SmartHouse.MultimediaSystems = new List<MultimediaSystem>();
            MultimediaSystem ms = new MultimediaSystem();
            ms.TypeOfMS = MultimediaSystem.TypesOfMultimediaSystems[rnd.Next(0, MultimediaSystem.TypesOfMultimediaSystems.Count())];
            SmartHouse.MultimediaSystems.Add(ms);
        }

        // Различные сетевые устройства
        public override void SetNetworkDevices()
        {
            SmartHouse.NetworkDevices = new List<NetworkDevice>();
            for(int i = 0; i < NetworkDevice.TypesOfNetDevices.Count; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    NetworkDevice nd = new NetworkDevice();
                    nd.TypeOfNetDevice = NetworkDevice.TypesOfNetDevices[i];
                    SmartHouse.NetworkDevices.Add(nd);
                }
            }
        }

        // Панель оператора - Пульт
        public override void SetOperatorPanels()
        {
            SmartHouse.OperatorPanels = new List<OperatorPanel>();
            // Пульт
            OperatorPanel op = new OperatorPanel();
            op.TypeOfOperatorPanel = OperatorPanel.TypesOfOperatorPanes[0];
            SmartHouse.OperatorPanels.Add(op);
        }

        // Различные сенсоры
        public override void SetSensors()
        {
            SmartHouse.Sensors = new List<Sensor>();
            // Используются различные типы датчиков
            for (int i = 0; i < Sensor.TypesOfSensors.Count(); i++)
            {
                Sensor s = new Sensor();
                s.Count = rnd.Next(0, 5);
                s.TypeOfSensor = Sensor.TypesOfSensors[i];
                s.TypeOfSignal = Sensor.TypesOfSignals[rnd.Next(0, Sensor.TypesOfSignals.Count)];
                SmartHouse.Sensors.Add(s);
            }
        }

        public override SmartHouse GetSmartHouse()
        {
            return SmartHouse;
        }
    }

    // Панель оператора - Панель управления
    class SHwithOperatorPanel_CP : Builder
    {
        static Random rnd = new Random();
        SmartHouse SmartHouse = new SmartHouse();

        // Различные механизмы
        public override void SetActuators()
        {
            SmartHouse.Actuators = new List<Actuator>();
            for (int i = 0; i < Actuator.TypesOfActuators.Count(); i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    Actuator a = new Actuator();
                    a.TypeOfActuator = Actuator.TypesOfActuators[i];
                    SmartHouse.Actuators.Add(a);
                }
            }
        }

        // Различные контроллеры управления
        public override void SetManagmentControllers()
        {
            SmartHouse.ManagmentControllers = new List<ManagmentController>();
            int count = rnd.Next(1, ManagmentController.TypesOfControllers.Count() + 1);
            if (count == 1)
            {
                ManagmentController mc = new ManagmentController();
                mc.TypeOfController = ManagmentController.TypesOfControllers[rnd.Next(0, ManagmentController.TypesOfControllers.Count())];
                SmartHouse.ManagmentControllers.Add(mc);
            }
            else
                for (int i = 0; i < count; i++)
                {
                    ManagmentController mc = new ManagmentController();
                    mc.TypeOfController = ManagmentController.TypesOfControllers[i];
                    SmartHouse.ManagmentControllers.Add(mc);
                }
        }

        // Система мультимедиа
        public override void SetMultimediaSystems()
        {
            SmartHouse.MultimediaSystems = new List<MultimediaSystem>();
            MultimediaSystem ms = new MultimediaSystem();
            ms.TypeOfMS = MultimediaSystem.TypesOfMultimediaSystems[rnd.Next(0, MultimediaSystem.TypesOfMultimediaSystems.Count())];
            SmartHouse.MultimediaSystems.Add(ms);
        }

        // Различные сетевые устройства
        public override void SetNetworkDevices()
        {
            SmartHouse.NetworkDevices = new List<NetworkDevice>();
            for (int i = 0; i < NetworkDevice.TypesOfNetDevices.Count; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    NetworkDevice nd = new NetworkDevice();
                    nd.TypeOfNetDevice = NetworkDevice.TypesOfNetDevices[i];
                    SmartHouse.NetworkDevices.Add(nd);
                }
            }
        }

        // Панель оператора - Панель управления
        public override void SetOperatorPanels()
        {
            SmartHouse.OperatorPanels = new List<OperatorPanel>();
            // Панель управления
            OperatorPanel op = new OperatorPanel();
            op.TypeOfOperatorPanel = OperatorPanel.TypesOfOperatorPanes[1];
            SmartHouse.OperatorPanels.Add(op);
        }

        // Различные сенсоры
        public override void SetSensors()
        {
            SmartHouse.Sensors = new List<Sensor>();
            // Используются различные типы датчиков
            for (int i = 0; i < Sensor.TypesOfSensors.Count(); i++)
            {
                Sensor s = new Sensor();
                s.Count = rnd.Next(0, 5);
                s.TypeOfSensor = Sensor.TypesOfSensors[i];
                s.TypeOfSignal = Sensor.TypesOfSignals[rnd.Next(0, Sensor.TypesOfSignals.Count)];
                SmartHouse.Sensors.Add(s);
            }
        }

        public override SmartHouse GetSmartHouse()
        {
            return SmartHouse;
        }
    }

    // Панель оператора - мобильные устройства
    class SHwithOperatorPanel_MD : Builder
    {
        static Random rnd = new Random();
        SmartHouse SmartHouse = new SmartHouse();

        // Различные механизмы
        public override void SetActuators()
        {
            SmartHouse.Actuators = new List<Actuator>();
            for (int i = 0; i < Actuator.TypesOfActuators.Count(); i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    Actuator a = new Actuator();
                    a.TypeOfActuator = Actuator.TypesOfActuators[i];
                    SmartHouse.Actuators.Add(a);
                }
            }
        }

        // Различные контроллеры управления
        public override void SetManagmentControllers()
        {
            SmartHouse.ManagmentControllers = new List<ManagmentController>();
            int count = rnd.Next(1, ManagmentController.TypesOfControllers.Count() + 1);
            if (count == 1)
            {
                ManagmentController mc = new ManagmentController();
                mc.TypeOfController = ManagmentController.TypesOfControllers[rnd.Next(0, ManagmentController.TypesOfControllers.Count())];
                SmartHouse.ManagmentControllers.Add(mc);
            }
            else
                for (int i = 0; i < count; i++)
                {
                    ManagmentController mc = new ManagmentController();
                    mc.TypeOfController = ManagmentController.TypesOfControllers[i];
                    SmartHouse.ManagmentControllers.Add(mc);
                }
        }

        // Система мультимедиа
        public override void SetMultimediaSystems()
        {
            SmartHouse.MultimediaSystems = new List<MultimediaSystem>();
            MultimediaSystem ms = new MultimediaSystem();
            ms.TypeOfMS = MultimediaSystem.TypesOfMultimediaSystems[rnd.Next(0, MultimediaSystem.TypesOfMultimediaSystems.Count())];
            SmartHouse.MultimediaSystems.Add(ms);
        }

        // Различные сетевые устройства
        public override void SetNetworkDevices()
        {
            SmartHouse.NetworkDevices = new List<NetworkDevice>();
            for (int i = 0; i < NetworkDevice.TypesOfNetDevices.Count; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    NetworkDevice nd = new NetworkDevice();
                    nd.TypeOfNetDevice = NetworkDevice.TypesOfNetDevices[i];
                    SmartHouse.NetworkDevices.Add(nd);
                }
            }
        }

        // Панель оператора - Мобильные устройства
        public override void SetOperatorPanels()
        {
            SmartHouse.OperatorPanels = new List<OperatorPanel>();
            // Мобильные устройства
            OperatorPanel op = new OperatorPanel();
            op.TypeOfOperatorPanel = OperatorPanel.TypesOfOperatorPanes[2];
            SmartHouse.OperatorPanels.Add(op);
        }

        // Различные сенсоры
        public override void SetSensors()
        {
            SmartHouse.Sensors = new List<Sensor>();
            // Используются различные типы датчиков
            for (int i = 0; i < Sensor.TypesOfSensors.Count(); i++)
            {
                Sensor s = new Sensor();
                s.Count = rnd.Next(0, 5);
                s.TypeOfSensor = Sensor.TypesOfSensors[i];
                s.TypeOfSignal = Sensor.TypesOfSignals[rnd.Next(0, Sensor.TypesOfSignals.Count)];
                SmartHouse.Sensors.Add(s);
            }
        }

        public override SmartHouse GetSmartHouse()
        {
            return SmartHouse;
        }
    }

    // SH без исполнительных механизмов
    class SHwithoutActuators: Builder
    {
        static Random rnd = new Random();
        SmartHouse SmartHouse = new SmartHouse();

        // Различные механизмы
        public override void SetActuators() { }

        // Различные контроллеры управления
        public override void SetManagmentControllers()
        {
            SmartHouse.MultimediaSystems = new List<MultimediaSystem>();
            int count = rnd.Next(1, ManagmentController.TypesOfControllers.Count() + 1);
            if (count == 1)
            {
                ManagmentController mc = new ManagmentController();
                mc.TypeOfController = ManagmentController.TypesOfControllers[rnd.Next(0, ManagmentController.TypesOfControllers.Count())];
                SmartHouse.ManagmentControllers.Add(mc);
            }
            else
                for (int i = 0; i < count; i++)
                {
                    ManagmentController mc = new ManagmentController();
                    mc.TypeOfController = ManagmentController.TypesOfControllers[i];
                    SmartHouse.ManagmentControllers.Add(mc);
                }
        }

        // Система мультимедиа
        public override void SetMultimediaSystems()
        {
            SmartHouse.MultimediaSystems = new List<MultimediaSystem>();
            MultimediaSystem ms = new MultimediaSystem();
            ms.TypeOfMS = MultimediaSystem.TypesOfMultimediaSystems[rnd.Next(0, MultimediaSystem.TypesOfMultimediaSystems.Count())];
            SmartHouse.MultimediaSystems.Add(ms);
        }

        // Различные сетевые устройства
        public override void SetNetworkDevices()
        {
            SmartHouse.NetworkDevices = new List<NetworkDevice>();
            for (int i = 0; i < NetworkDevice.TypesOfNetDevices.Count; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    NetworkDevice nd = new NetworkDevice();
                    nd.TypeOfNetDevice = NetworkDevice.TypesOfNetDevices[i];
                    SmartHouse.NetworkDevices.Add(nd);
                }
            }
        }

        // Различные панели управления
        public override void SetOperatorPanels()
        {
            SmartHouse.OperatorPanels = new List<OperatorPanel>();
            for (int i = 0; i < OperatorPanel.TypesOfOperatorPanes.Count(); i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    OperatorPanel op = new OperatorPanel();
                    op.TypeOfOperatorPanel = OperatorPanel.TypesOfOperatorPanes[i];
                    SmartHouse.OperatorPanels.Add(op);
                }
            }
        }

        // Различные сенсоры
        public override void SetSensors()
        {
            SmartHouse.Sensors = new List<Sensor>();
            // Используются различные типы датчиков
            for (int i = 0; i < Sensor.TypesOfSensors.Count(); i++)
            {
                Sensor s = new Sensor();
                s.Count = rnd.Next(0, 5);
                s.TypeOfSensor = Sensor.TypesOfSensors[i];
                s.TypeOfSignal = Sensor.TypesOfSignals[rnd.Next(0, Sensor.TypesOfSignals.Count)];
                SmartHouse.Sensors.Add(s);
            }
        }

        public override SmartHouse GetSmartHouse()
        {
            return SmartHouse;
        }
    }

    // SH без мультимедиа системы
    class SHwithoutMultimediaSystems: Builder
    {
        static Random rnd = new Random();
        SmartHouse SmartHouse = new SmartHouse();

        // Различные механизмы
        public override void SetActuators()
        {
            SmartHouse.Actuators = new List<Actuator>();
            for (int i = 0; i < Actuator.TypesOfActuators.Count(); i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    Actuator a = new Actuator();
                    a.TypeOfActuator = Actuator.TypesOfActuators[i];
                    SmartHouse.Actuators.Add(a);
                }
            }
        }

        // Различные контроллеры управления
        public override void SetManagmentControllers()
        {
            SmartHouse.ManagmentControllers = new List<ManagmentController>();
            int count = rnd.Next(1, ManagmentController.TypesOfControllers.Count() + 1);
            if (count == 1)
            {
                ManagmentController mc = new ManagmentController();
                mc.TypeOfController = ManagmentController.TypesOfControllers[rnd.Next(0, ManagmentController.TypesOfControllers.Count())];
                SmartHouse.ManagmentControllers.Add(mc);
            }
            else
                for (int i = 0; i < count; i++)
                {
                    ManagmentController mc = new ManagmentController();
                    mc.TypeOfController = ManagmentController.TypesOfControllers[i];
                    SmartHouse.ManagmentControllers.Add(mc);
                }
        }

        // Система мультимедиа
        public override void SetMultimediaSystems() { }

        // Различные сетевые устройства
        public override void SetNetworkDevices()
        {
            SmartHouse.NetworkDevices = new List<NetworkDevice>();
            for (int i = 0; i < NetworkDevice.TypesOfNetDevices.Count; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    NetworkDevice nd = new NetworkDevice();
                    nd.TypeOfNetDevice = NetworkDevice.TypesOfNetDevices[i];
                    SmartHouse.NetworkDevices.Add(nd);
                }
            }
        }

        // Различные панели управления
        public override void SetOperatorPanels()
        {
            SmartHouse.OperatorPanels = new List<OperatorPanel>();
            for (int i = 0; i < OperatorPanel.TypesOfOperatorPanes.Count(); i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    OperatorPanel op = new OperatorPanel();
                    op.TypeOfOperatorPanel = OperatorPanel.TypesOfOperatorPanes[i];
                    SmartHouse.OperatorPanels.Add(op);
                }
            }
        }

        // Различные сенсоры
        public override void SetSensors()
        {
            SmartHouse.Sensors = new List<Sensor>();
            // Используются различные типы датчиков
            for (int i = 0; i < Sensor.TypesOfSensors.Count(); i++)
            {
                Sensor s = new Sensor();
                s.Count = rnd.Next(0, 5);
                s.TypeOfSensor = Sensor.TypesOfSensors[i];
                s.TypeOfSignal = Sensor.TypesOfSignals[rnd.Next(0, Sensor.TypesOfSignals.Count)];
                SmartHouse.Sensors.Add(s);
            }
        }

        public override SmartHouse GetSmartHouse()
        {
            return SmartHouse;
        }
    }
}