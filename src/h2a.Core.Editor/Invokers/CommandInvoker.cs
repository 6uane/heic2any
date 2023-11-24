using h2a.Core.Editor.Interfaces;

namespace h2a.Core.Editor.Invokers;

public class CommandInvoker : ICommandInvoker
{
    // private readonly Stack<IUndoCommand> _undoStack = new Stack<IUndoCommand>();
    // private readonly Stack<IUndoCommand> _redoStack = new Stack<IUndoCommand>();

    public void Invoke(ICommand command)
    {
        command.Execute();
        // if (command is IUndoCommand undoCommand)
        //     _undoStack.Push(undoCommand);
    }

    // public void Undo()
    // {
    //     if (_undoStack.Any())
    //         return;
    //
    //     var command = _undoStack.Pop();
    //     command.Undo();
    //     _redoStack.Push(command);
    // }
    //
    // public void Redo()
    // {
    //     if (_redoStack.Any())
    //         return;
    //
    //     var command = _redoStack.Pop();
    //     command.Redo();
    //     _undoStack.Push(command);
    // }
}