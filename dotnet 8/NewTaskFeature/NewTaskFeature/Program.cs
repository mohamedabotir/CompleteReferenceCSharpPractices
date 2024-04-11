List<Task<int>> tasks = Enumerable.Range(1, 6).Select(RunProcess).ToList();


#region when all

//var operatedTasks =await Task.WhenAll(tasks);// when all tasks complete if we need execution be in sequential manner
//foreach (var t in operatedTasks)
//{
//    Console.WriteLine(t);
//}

#endregion

#region when any


while (tasks.Any())
{
    var operatedTask = await Task.WhenAny(tasks);// operate as executed taskss
    tasks.Remove(operatedTask);
    Console.WriteLine(operatedTask.Result);
}


 
#endregion
async Task<int> RunProcess(int number)
{
    var latency = Random.Shared.Next(500, 5000);
   await Task.Delay(latency);
    return number;
}