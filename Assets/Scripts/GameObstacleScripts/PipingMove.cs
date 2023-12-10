using UnityEngine;

public class PipingMove : MonoBehaviour
{
    public float MoveSpeed;

    private void Start()
    {
       // Destroy(gameObject, 7f);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
    }

}
