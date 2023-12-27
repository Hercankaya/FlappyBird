using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStateBase _currentState;
    private PlayerStateIdle _idleState;
    private PlayerStateFalling _fallingState;
    private PlayerStateFlying _flyingState;
    private PlayerStateDead _deadState;
    private Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody => _rigidbody;
    private float _jumpPower = 1.7f;
    public float JumpPower => _jumpPower;
   
    private void Start()
    {
        PlayerStates();
        _rigidbody = GetComponent<Rigidbody2D>();
        ChangeState(_idleState);
    }
    private void PlayerStates()
    {
        _idleState = new PlayerStateIdle(this);
        _fallingState = new PlayerStateFalling(this);
        _flyingState = new PlayerStateFlying(this);
        _deadState = new PlayerStateDead(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);

        if(_rigidbody != null )
        {
            if (Input.GetMouseButtonDown(0) && !(_currentState ==_deadState))
            {
                ChangeState(_flyingState);
            }
            else if (_currentState == _flyingState)
            {
                ChangeState(_fallingState);
            }
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on playerController !!");
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DamageArea"))
        {
            ChangeState(_deadState);
        }
        if(other.CompareTag("ScoreArea"))
        {
            GameEvents.TriggerScoreIncreased();
        }
        if (other.CompareTag("GroundArea"))
        {
            GameEvents.OnGroundEvents();
        }
    }
    private void ChangeState(PlayerStateBase newState)
    {
        _currentState?.ExitState(this); 
        _currentState = newState;
        _currentState.EnterState(this);
        GameEvents.TriggerPlayerStateChanged(newState);
    }

   
}
