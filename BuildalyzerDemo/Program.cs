namespace BuildalyzerDemo;
using Buildalyzer;

public static class Program
{
    public static void Main(string[] args)
    {
        var slnFilePath = args[0];
        
        var manager = new AnalyzerManager(slnFilePath);
        
        //With TargetFramework set, the hanging does not occur,
        //when loading https://github.com/HooliCorp/Goatly.NET
        
        //manager.SetGlobalProperty("TargetFramework", "net6");
        
        foreach (var projectAnalyzer in manager.Projects.Values)
        {
            Console.Write($"Loading project {projectAnalyzer.ProjectFile.Path} ...");
            var results = projectAnalyzer.Build();
            Console.WriteLine("Finished");
        }
    }
}
