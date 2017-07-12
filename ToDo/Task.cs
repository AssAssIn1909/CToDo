namespace ToDo
{
	public class Task
	{
		public int Id { get; set; }
		public string Name{ get; set; }
		public bool Done { get; set; }

		public Task(string taskName)
		{
			Name = taskName;
			Done = false;
		}

		public Task()
		{

		}
	}
}
