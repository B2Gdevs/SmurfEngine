namespace SmurfEngine.Utilities.Options
{

    /// <summary>
    /// This is the base class for options.  All options use the Command Design Pattern.
    /// Please read https://refactoring.guru/design-patterns/command for more.
    /// </summary>
    public class Option
    {
        public string Name { get; set; }
    }

}
