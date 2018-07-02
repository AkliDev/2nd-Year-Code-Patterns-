using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameleon : MonoBehaviour
{
    
    CommandList _CommandList;
    
    public SpriteRenderer _Render;

    void Start()
    {
        _CommandList = new CommandList();
        _Render = GetComponent<SpriteRenderer>();
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _CommandList.Execute(new MoveCommand(this, Vector3.up));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _CommandList.Execute(new MoveCommand(this, Vector3.left));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _CommandList.Execute(new MoveCommand(this, Vector3.down));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _CommandList.Execute(new MoveCommand(this, Vector3.right));
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            _CommandList.Execute(new ColorCommand(this, Color.white));
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            _CommandList.Execute(new ColorCommand(this, Color.green));
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            _CommandList.Execute(new ColorCommand(this, Color.red));
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            _CommandList.Execute(new ColorCommand(this, Color.blue));
        }



        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            _CommandList.Undo();
        }

        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            _CommandList.Redo();
        }
    }
}

public class MoveCommand : ICommand
{
    private Cameleon _Player;
    private Vector3 _Delta;


    public MoveCommand(Cameleon player, Vector3 direction)
    {
        _Player = player;
        _Delta = direction;
    }

    public void Do()
    {
        _Player.transform.position += _Delta;
    }
    public void Undo()
    {
        _Player.transform.position -= _Delta;
    }
}

public class ColorCommand : ICommand
{
    private Cameleon _Player;
    private Color _NewColor;
    private Color _OldColor;


    public ColorCommand(Cameleon player, Color newColor)
    {
        _Player = player;
        _OldColor = _Player._Render.color;
        _NewColor = newColor;
    }

    public void Do()
    {
        _Player._Render.color = _NewColor;
    }
    public void Undo()
    {
        _Player._Render.color = _OldColor;
    }
}


