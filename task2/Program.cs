using System;

interface IGraph
{
    void Draw();
}

class LineGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Line Graph");
    }
}

class BarGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Bar Graph");
    }
}

class GraphFactory
{
    public IGraph CreateGraph(string graphType)
    {
        switch (graphType.ToLower())
        {
            case "line":
                return new LineGraph();
            case "bar":
                return new BarGraph();
            default:
                throw new ArgumentException("Invalid graph type");
        }
    }
}

class Program
{
    static void Main()
    {
        GraphFactory graphFactory = new GraphFactory();

        Console.Write("Enter graph type (line/bar): ");
        string graphType = Console.ReadLine();

        IGraph graph = graphFactory.CreateGraph(graphType);
        graph.Draw();
    }
}
