using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
	public static class CommandsManager
	{
		public static void Run(string[] args)
		{
			switch (args[0].ToUpper())
			{
				case "SHOW":
					_ShowAllTask();
					break;
				case "ADD":
					_AddTask(args[1]);
					break;
				case "DONE":
					_DoneTask(args[1]);
					break;
				case "REMOVE":
					_RemoveTask(args[1]);
					break;
				default:
					break;
			}
		}

		private static void _RemoveTask(string id)
		{
			if (!int.TryParse(id, out int taskId))
			{
				Console.WriteLine($"{id} is not a number. Please check task position on a list");
				return;
			}

			var tasks = FileService.CrateOrRead();
			tasks.Remove(tasks.First(t => t.Id == taskId));
			FileService.Save(tasks);
		}

		private static void _DoneTask(string id)
		{
			if(!int.TryParse(id, out int taskId))
			{
				Console.WriteLine($"{id} is not a number. Please check task position on a list");
				return;
			}

			var tasks = FileService.CrateOrRead();
			tasks.First(t => t.Id == taskId).Done = !tasks.First(t => t.Id == taskId).Done;
			FileService.Save(tasks);
			if (tasks.First(t=>t.Id==taskId).Done)			
				Console.WriteLine($"You completed task number {id}");
			else
				Console.WriteLine($"You change status in task number {id}");
		}

		private static void _AddTask(string taskName)
		{
			var tasks = FileService.CrateOrRead();
			tasks.Add(new Task(taskName));
			FileService.Save(tasks);
			Console.WriteLine($"You added a new task to the list.");
		}

		private static void _ShowAllTask()
		{
			var tasks = FileService.CrateOrRead();
			_WriteInConsole(tasks);
		}

		private static void _WriteInConsole(List<Task> tasks)
		{
			foreach (var task in tasks)
			{
				var color = Console.ForegroundColor; // Save current console color

				if (task.Done)
					Console.ForegroundColor = ConsoleColor.Green;
				else
					Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"{task.Id}. {task.Name}");

				Console.ForegroundColor = color; // Apply previous color
			}
		}
	}
}
