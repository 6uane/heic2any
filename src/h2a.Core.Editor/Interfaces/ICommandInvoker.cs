namespace h2a.Core.LivePreview.Interfaces;

public interface ICommandInvoker
{
    public void Invoke(ICommand command);
    public void Undo();
    public void Redo();
}
