namespace h2a.Core.Editor.Interfaces;

public interface ICommandInvoker
{
    public void Invoke(ICommand command);
    // public void Undo();
    // public void Redo();
}