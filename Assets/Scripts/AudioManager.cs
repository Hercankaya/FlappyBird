using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] AudioClip DamageSound;
    [SerializeField] AudioClip DeadSound;
    [SerializeField] AudioClip FlySound;
    [SerializeField] AudioClip CoinSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void Fly()
    {
        _audioSource.PlayOneShot(FlySound);
    }
    public void Damage()
    {
        _audioSource.PlayOneShot(DamageSound);
    }
    public void Dead()
    {
        _audioSource.PlayOneShot(DeadSound);
    }
    public void Coin()
    {
        _audioSource.PlayOneShot(CoinSound);
    }
    private void OnEnable()
    {
        GameEvents.OnPlayerStateChanged += HandlePlayerStateChanged;
        GameEvents.OnScoreIncreased += Coin;
        GameEvents.OnGround += Dead;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerStateChanged -= HandlePlayerStateChanged;
        GameEvents.OnScoreIncreased -= Coin;
        GameEvents.OnGround -= Dead;
    } 
    private void HandlePlayerStateChanged(PlayerStateBase newState)
    {
        if (newState is PlayerStateDead)
        {
            Damage();
        }
        if (newState is PlayerStateFlying)
        {
            Fly();
        }
    }
}
