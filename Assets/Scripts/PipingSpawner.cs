using System.Collections;
using UnityEngine;

public class PipingSpawner : MonoBehaviour

{ 
    public GameObject PipingPrefab;
    public float PipinLength;
    public float time;
    public float SpawnerStartTime;
    private bool _PlayerLive =true;
   
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
        if (newState is PlayerStateDead )
        {
            _PlayerLive = false;
        }
    }
    private void Start()
    {
        if (_PlayerLive == true)
        {
            Invoke("StartSpawning", SpawnerStartTime);
        }
    }
    private void StartSpawning()
    {
        StartCoroutine(SpawnObject(time));
    }

    private IEnumerator SpawnObject(float time)
    {
        while (_PlayerLive == true) 
        {
            Instantiate(PipingPrefab, new Vector3(3, Random.Range(-PipinLength, PipinLength), 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }


    }
}
