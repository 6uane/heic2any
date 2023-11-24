namespace h2a.Core.Editor.Interfaces;

public interface IUndoCommand : ICommand
{
    void Undo();
    void Redo();
}