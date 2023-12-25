using UnityEngine;

public class PipingController : MonoBehaviour
{
    public float MoveSpeed = 0.5f;

    private void Start()
    {
        Destroy(gameObject, 7f);
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
    }
    private void OnEnable()
    {
        GameEvents.OnPlayerStateChanged += HandlePlayerStateChanged;

    }
    private void OnDisable()
    {
        GameEvents.OnPlayerStateChanged -= HandlePlayerStateChanged;

    }
    private void HandlePlayerStateChanged(PlayerStateBase newState)
    {
        if ((newState is PlayerStateDead))
        {
            DisableCollidersInChildren(gameObject);
        }
    }
    private void DisableCollidersInChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Collider2D childCollider = child.GetComponent<Collider2D>();
            if (childCollider != null)
            {
                childCollider.enabled = false;
            }
        }
    }
}
