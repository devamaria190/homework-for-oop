using System;
using System.Collections.Generic;
using System.Xml;
using System.Text.Json;

interface IDataPrototype
{
    IDataPrototype Clone();
    void Display();
}

class CSVData : IDataPrototype
{
    public string CSVContent { get; set; }

    public IDataPrototype Clone()
    {
        return new CSVData { CSVContent = this.CSVContent };
    }

    public void Display()
    {
        Console.WriteLine($"CSV Data: {CSVContent}");
    }
}

class XMLData : IDataPrototype
{
    public XmlDocument XMLContent { get; set; }

    public IDataPrototype Clone()
    {
        return new XMLData { XMLContent = (XmlDocument)XMLContent.Clone() };
    }

    public void Display()
    {
        Console.WriteLine($"XML Data: {XMLContent.InnerXml}");
    }
}
class DataAdapter
{
    public IDataPrototype ConvertToPrototype(JsonDocument jsonData)
    {

        return new CSVData { CSVContent = "Converted CSV Content" }; 
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter source data format (json): ");
        string sourceFormat = Console.ReadLine();

        Console.Write("Enter target data format (csv/xml): ");
        string targetFormat = Console.ReadLine();

        JsonDocument jsonDocument = JsonDocument.Parse("{\"key\":\"value\"}");

        DataAdapter dataAdapter = new DataAdapter();
        IDataPrototype targetData = dataAdapter.ConvertToPrototype(jsonDocument);

        Console.WriteLine("Target Data:");
        targetData.Display();
    }
}
