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
    public int JumpPower = 3;

    private void Start()
    {
        _idleState = new PlayerStateIdle(this);
        _fallingState = new PlayerStateFalling(this);
        _flyingState = new PlayerStateFlying(this);
        _deadState = new PlayerStateDead(this);

        _rigidbody = GetComponent<Rigidbody2D>();
        

        // Ba�lang��ta Idle durumunda olal�m
        ChangeState(_idleState);
    }

    private void Update()
    {
        // Mevcut durumu g�ncelleyelim
        _currentState.UpdateState(this);

        if(_rigidbody != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
            {
                // Idle durumundayken Escape tu�una veya sol fare t�klamas�na bas�ld���nda Flying durumuna ge�elim
                ChangeState(_flyingState);
                
            }
            else if (_currentState == _flyingState)
            {
                // Flying durumundayken Escape tu�una veya sol fare t�klamas�na bas�ld���nda Falling durumuna ge�elim
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
        if (other.CompareTag("DeathArea"))
        {
            ChangeState(_deadState);
        }
        if(other.CompareTag("ScoreArea"))
        {
            
            GameEvents.TriggerScoreIncreased();

        }
    }

    private void ChangeState(PlayerStateBase newState)
    {
        // Mevcut durumu ��kart�p, yeni duruma ge�iyoruz
        _currentState?.ExitState(this); 
        _currentState = newState;
        _currentState.EnterState(this);
        GameEvents.TriggerPlayerStateChanged(newState);
    }
}
