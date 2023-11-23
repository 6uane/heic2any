namespace h2a.Core.LivePreview.Interfaces;

public interface IUndoCommand
{
    void Undo();
    void Redo();
}
