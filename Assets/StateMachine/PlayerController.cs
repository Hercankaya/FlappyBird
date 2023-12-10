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
        

        // Baþlangýçta Idle durumunda olalým
        ChangeState(_idleState);
    }

    private void Update()
    {
        // Mevcut durumu güncelleyelim
        _currentState.UpdateState(this);

        if(_rigidbody != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
            {
                // Idle durumundayken Escape tuþuna veya sol fare týklamasýna basýldýðýnda Flying durumuna geçelim
                ChangeState(_flyingState);
                
            }
            else if (_currentState == _flyingState)
            {
                // Flying durumundayken Escape tuþuna veya sol fare týklamasýna basýldýðýnda Falling durumuna geçelim
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
        // Mevcut durumu çýkartýp, yeni duruma geçiyoruz
        _currentState?.ExitState(this); 
        _currentState = newState;
        _currentState.EnterState(this);
        GameEvents.TriggerPlayerStateChanged(newState);
    }
}
