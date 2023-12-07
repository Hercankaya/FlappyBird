using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public int JumpPower;
    public bool IsDead => _isDead;
    private bool _isDead;
   



    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        if (_rigidbody != null) 
        {   
            if(Input.GetMouseButtonDown(0))
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpPower);

            }

        }

    }
    /*
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScorArea")
        {
            
        }
    }
    */    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            _isDead = true;
            Time.timeScale = 0f;
        }
    }

}
