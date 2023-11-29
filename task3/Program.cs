using System;

interface IScreen { void Display(); }
interface IProcessor { void Process(); }
interface ICamera { void Capture(); }

class OLEDScreen : IScreen { public void Display() => Console.WriteLine("OLED Screen"); }
class SnapdragonProcessor : IProcessor { public void Process() => Console.WriteLine("Snapdragon Processor"); }
class DualCamera : ICamera { public void Capture() => Console.WriteLine("Dual Camera"); }

interface IProductFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
    ICamera CreateCamera();
}

class SmartphoneFactory : IProductFactory
{
    public IScreen CreateScreen() => new OLEDScreen();
    public IProcessor CreateProcessor() => new SnapdragonProcessor();
    public ICamera CreateCamera() => new DualCamera();
}

class TabletFactory : IProductFactory
{
    public IScreen CreateScreen() => new OLEDScreen();
    public IProcessor CreateProcessor() => new SnapdragonProcessor();
    public ICamera CreateCamera() => new DualCamera();
}

class Program
{
    static void Main()
    {
        Console.Write("Enter product type (smartphone/tablet): ");
        string productType = Console.ReadLine();

        IProductFactory productFactory = productType.ToLower() == "smartphone" ? new SmartphoneFactory() : new TabletFactory();

        IScreen screen = productFactory.CreateScreen();
        IProcessor processor = productFactory.CreateProcessor();
        ICamera camera = productFactory.CreateCamera();

        Console.WriteLine("Product Details:");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}
