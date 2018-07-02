using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Do();
    void Undo();
}

public class CommandList
{
    private List<ICommand> _Commands;
    private int _Index;

    // Use this for initialization
    public CommandList()
    {
        _Commands = new List<ICommand>();
        _Index = -1;
        //Debug.Log("List: " + (_Commands.Count - 1) + " Index:" + _Index);
    }

    // Update is called once per frame
    public void Execute(ICommand command)
    {
        command.Do();

        if (_Index != _Commands.Count - 1)
        {
            for (int i = _Commands.Count - 1; i > _Index; i--)
            {
                _Commands.RemoveAt(i);
            }
            _Index = _Commands.Count - 1;
        }
        _Commands.Add(command);
        _Index++;
        Debug.Log("List: " + (_Commands.Count - 1) + " Index:" + _Index);
    }

    public void Undo()
    {
        if (_Index > -1)
        {
            _Commands[_Index].Undo();
            _Index--;
            Debug.Log("List: " + (_Commands.Count - 1) + " Index:" + _Index);
        }
    }

    public void Redo()
    {
        if (_Index != _Commands.Count - 1)
        {
            _Index++;
            _Commands[_Index].Do();
            Debug.Log("List: " + (_Commands.Count - 1) + " Index:" + _Index);
        }
    }
}

