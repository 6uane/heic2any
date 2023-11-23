namespace h2a.Core.LivePreview.Interfaces;

public interface IUndoCommand : ICommand
{
    void Undo();
    void Redo();
}
