namespace CommandPattern.Commands

{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
