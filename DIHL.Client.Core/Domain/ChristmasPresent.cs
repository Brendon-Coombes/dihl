namespace DIHL.Client.Core.Domain
{
    public class ChristmasPresent
    {
	    public string Name { get; }
	    public string From { get; }
	    public string To { get; }
	    public string Image { get; }

		public ChristmasPresent(string name, string from, string to)
        {
            Name = name;
            From = from;
            To = to;
            Image = $"../Assets/{name}.jpg";
        }
    }
}
