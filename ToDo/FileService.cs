using System.Collections.Generic;
using System.IO;

namespace ToDo
{
	public static class FileService
	{
		static string _fileName = "ToDo.txt";

		internal static List<Task> CrateOrRead()
		{
			if (File.Exists(_fileName))
			{
				var stringTasks = File.ReadAllLines(_fileName);
				var tasks = new List<Task>();
				foreach (var task in stringTasks)
				{
					var parts = task.Split(new char[] { ',' });
					var newTask = new Task
					{
						Id = tasks.Count,
						Name = parts[0],
						Done = bool.Parse(parts[1])
					};
					tasks.Add(newTask);
				}
				return tasks;
			}
			else
			{
				File.Create(_fileName);
				return new List<Task>();
			}
		}

		internal static void Save(List<Task> tasks)
		{
			var stringTasks = new List<string>();
			foreach (var task in tasks)
			{
				stringTasks.Add($"{task.Name},{task.Done}");
			}
			var stringArray = stringTasks.ToArray();
			File.WriteAllLines(_fileName, stringArray);
		}
	}
}
