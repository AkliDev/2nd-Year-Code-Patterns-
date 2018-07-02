using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter();
    void Update();
    void OnExit();
}

public enum AnimationState
{
    Idle,
    Alt_Idle,
    Crouch,
    F_Walk,
    B_Walk,
    Jump,  
    Falling,
}

public class Sol : MonoBehaviour
{
    IState _State;
    public AnimationState _AnimationState;
    private Animator _Animator;
  

    public float _MoveSpeed, _JumpForce;
    public Vector2 _Velocity;

    public Collision _Collision;
    void Start()
    {
        _Collision = GetComponent<Collision>();
        _Animator = GetComponent<Animator>();
       
        _State = new Idle(this);       
    }

    private void FixedUpdate()
    {
        transform.Translate(_Velocity);
        _Collision.CheckCollision(ref _Velocity);
    }
    void Update()
    {      
        _State.Update();
    }

    public void SetAnimation(AnimationState aninemationstate)
    {
        _AnimationState = aninemationstate;
    }

    public void SwitchState(IState state)
    {
        _State.OnExit();
        _State = state;
        _State.OnEnter();
        _Animator.SetInteger("State", (int)_AnimationState);
    }
    public void AltIdle()
    {
        if (_AnimationState == AnimationState.Idle)
        {
            int random = Random.Range(0, 5);
            if (random == 3)
            {
                SetAnimation(AnimationState.Alt_Idle);
            }
        }
        else
        {
            SetAnimation(AnimationState.Idle);
        }
        

        _Animator.SetInteger("State", (int)_AnimationState);

    }

}

public class Idle : IState
{
    Sol _Player;
    
    public Idle(Sol player)
    {
        _Player = player;
        _Player._Velocity.x = 0;
        
    }
    public void OnEnter()
    {
        _Player.SetAnimation(AnimationState.Idle);
    }

   
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _Player.SwitchState(new Crouch(_Player));
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
        {
            _Player.SwitchState(new FWalk(_Player));
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            _Player.SwitchState(new BWalk(_Player));
        }
     
        if (Input.GetKeyDown(KeyCode.W))
        {
            _Player.SwitchState(new Jump(_Player));
        }
    }
    public void OnExit()
    {

    }
}

public class Crouch : IState
{
    Sol _Player;
    public Crouch(Sol player)
    {
        _Player = player;
    }
    public void OnEnter()
    {
        _Player.SetAnimation(AnimationState.Crouch);
    }
  
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            _Player.SwitchState(new Idle(_Player));
        }
      
    }
    public void OnExit()
    {

    }
}

public class FWalk : IState
{
    Sol _Player;
    public FWalk(Sol player)
    {
        _Player = player;
    }
    public void OnEnter()
    {
        _Player.SetAnimation(AnimationState.F_Walk);
        _Player._Velocity = new Vector2(-_Player._MoveSpeed, _Player._Velocity.y);
    }
  
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            _Player.SwitchState(new Idle(_Player));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _Player.SwitchState(new BWalk(_Player));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _Player.SwitchState(new Jump(_Player));
        }
    }
    public void OnExit()
    {
       
    }
}
public class BWalk : IState
{
    Sol _Player;
    public BWalk(Sol player)
    {
        _Player = player;
        _Player._Velocity = new Vector2(_Player._MoveSpeed, _Player._Velocity.y);
    }
    public void OnEnter()
    {
        _Player.SetAnimation(AnimationState.B_Walk);
    }
 
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            _Player.SwitchState(new Idle(_Player));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _Player.SwitchState(new FWalk(_Player));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _Player.SwitchState(new Jump(_Player));
        }
    }
    public void OnExit()
    {
        
    }
}
    


public class Jump : IState
{
    Sol _Player;
    public Jump(Sol player)
    {
        _Player = player;
        _Player._Velocity.y = _Player._JumpForce;
    }
    public void OnEnter()
    {
        _Player.SetAnimation(AnimationState.Jump);
        
    }
 
    public void Update()
    {
        if (_Player._Collision._Grounded == false && _Player._Velocity.y < 0)
        {
            _Player.SwitchState(new Falling(_Player));
        }
    }
    public void OnExit()
    {

    }
}


public class Falling : IState
{
    Sol _Player;
    public Falling(Sol player)
    {
        _Player = player;
    }
    public void OnEnter()
    {
        _Player.SetAnimation(AnimationState.Falling);
    }
  
    public void Update()
    {
        if (_Player._Collision._Grounded == true)
        {
            _Player.SwitchState(new Idle(_Player));
        }
    }
    public void OnExit()
    {

    }
}


