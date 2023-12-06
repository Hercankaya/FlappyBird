using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private Rigidbody2D _rB;
    public float JumpPower;
    public bool IsDead => _isDead;
    private bool _isDead;

    public GameManager GameManager;
    private void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rB != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rB.velocity = new Vector2(_rB.velocity.x, JumpPower);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScorArea")
        {
          GameManager.ScoreUpdate();
        }
    }
}
