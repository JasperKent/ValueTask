using Awaiting;
using System.Reflection;

var serviceAccess = new MockServiceAccess();

for (int i = 0; i < 2; ++i)
{
    Console.WriteLine($"ITERATION {i}");
    Console.WriteLine("Before await:");

    var task = serviceAccess.GetDataAsync();

    Console.WriteLine($"Thread: {Environment.CurrentManagedThreadId}");
    Console.WriteLine($"IsCompletedSuccessfully: {task.IsCompletedSuccessfully}");
    ShowPrivates(task);

    var text = await task;

    Console.WriteLine("\nAfter await:");

    Console.WriteLine($"Thread: {Environment.CurrentManagedThreadId}");
    Console.WriteLine($"IsCompletedSuccessfully: {task.IsCompletedSuccessfully}");
    ShowPrivates(task);

    Console.WriteLine(text);

    Console.WriteLine();
}

void ShowPrivates(ValueTask<string> task)
{
    var type = task.GetType();

    var obj = type.GetField("_obj", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(task) == null ? "is null" : "has value";
    var result = type.GetField("_result", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(task) == null ? "is null" : "has value";

    Console.WriteLine($"_obj {obj}. _result {result}.");
}
