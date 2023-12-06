using Unity.VisualScripting;
using UnityEngine;

public class PipingMove : MonoBehaviour
{
    public float MoveSpeed;

    private void Start()
    {
        Destroy(gameObject,7f);
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
    }
    private void onCollisionEnter2d(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("PLayer"))
        {
            Debug.Log("Skor ekle");
        }
    }
}
