using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8PatternInterpreterConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // camera wifi command on recording - сигнал
            string signal = "16212";
            Context context = new Context(signal);
            
            //Строим 'parse tree'
            List<Expression> tree = new List<Expression>
            {
                new DeviceTypeExpression(),
                new ProtocolExpression(),
                new MessageTypeExpression(),
                new DeviceStateExpression(), 
                new CommandExpression()
            };

            //Интерпритатор
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }
            Console.WriteLine("{0} = {1}", signal, context.Output);

            Console.ReadLine();

        }
    }

    class Context
    {
        // Constructor
        public Context(string input)
        {
            Input = input;
        }

        public string Input { get; set; }
        public string Output { get; set; }
    }

    /// <summary>
    /// 'AbstractExpression' класс
    /// </summary>
    abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith("0"))
            {
                context.Output += PartOfSignal() + Null() + " ";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith("1"))
            {
                context.Output += PartOfSignal() + One() + " ";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith("2"))
            {
                context.Output += PartOfSignal() + Two() + " ";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith("3"))
            {
                context.Output += PartOfSignal() + Three() + " ";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith("4"))
            {
                context.Output += PartOfSignal() + Four() + " ";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith("5"))
            {
                context.Output += PartOfSignal() + Five() + " ";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith("6"))
            {
                context.Output += PartOfSignal() + Six() + " ";
                context.Input = context.Input.Substring(1);
            }
            else if (context.Input.StartsWith("7"))
            {
                context.Output += PartOfSignal() + Seven() + " ";
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string Null();
        public abstract string One();
        public abstract string Two();
        public abstract string Three();
        public abstract string Four();
        public abstract string Five();
        public abstract string Six();
        public abstract string Seven();
        public abstract string PartOfSignal();
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Проверка на тип устройства.
    /// </remarks>
    /// </summary>
    class DeviceTypeExpression : Expression
    {
        public override string Null() { return "No"; }
        public override string One() { return "camera"; }
        public override string Two() { return "sensor"; }
        public override string Three() { return "-"; }
        public override string Four() { return "-"; }
        public override string Five() { return "-"; }
        public override string Six() { return "-"; }
        public override string Seven() { return "-"; }
        public override string PartOfSignal() { return "DeviceType: "; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Проверка на используемый протокол.
    /// </remarks>
    /// </summary>
    class ProtocolExpression : Expression
    {
        public override string Null() { return "No"; }
        public override string One() { return "onvif"; }
        public override string Two() { return "zwave"; }
        public override string Three() { return "mqtt"; }
        public override string Four() { return "businessLogic"; }
        public override string Five() { return "bluetooth"; }
        public override string Six() { return "wifi"; }
        public override string Seven() { return "rf"; }
        public override string PartOfSignal() { return "Protocol: "; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Проверка типа сообщения.
    /// </remarks>
    /// </summary>
    class MessageTypeExpression : Expression
    {
        public override string Null() { return "No"; }
        public override string One() { return "sensorData"; }
        public override string Two() { return "command"; }
        public override string Three() { return "businessLogicRule"; }
        public override string Four() { return "configurationData"; }
        public override string Five() { return "deviceState"; }
        public override string Six() { return "-"; }
        public override string Seven() { return "-"; }
        public override string PartOfSignal() { return "MessageType: "; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Проверка состояния устройства.
    /// </remarks>
    /// </summary>
    class DeviceStateExpression : Expression
    {
        public override string Null() { return "No"; }
        public override string One() { return "on"; }
        public override string Two() { return "off"; }
        public override string Three() { return "error"; }
        public override string Four() { return "-"; }
        public override string Five() { return "-"; }
        public override string Six() { return "-"; }
        public override string Seven() { return "-"; }
        public override string PartOfSignal() { return "DeviceState: "; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Проверка состояния устройства.
    /// </remarks>
    /// </summary>
    class CommandExpression : Expression
    {
        public override string Null() { return "No"; }
        public override string One() { return "streaming"; }
        public override string Two() { return "recording"; }
        public override string Three() { return "open"; }
        public override string Four() { return "close"; }
        public override string Five() { return "-"; }
        public override string Six() { return "-"; }
        public override string Seven() { return "-"; }
        public override string PartOfSignal() { return "Command: "; }
    }
}
