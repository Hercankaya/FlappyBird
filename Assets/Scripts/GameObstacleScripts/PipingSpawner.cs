using System.Collections;
using UnityEngine;

public class PipingSpawner : MonoBehaviour

{ // Bu klas  düzenlenecek !!
    
    public GameObject PipingPrefab;
    public float PipinLength;
    public float time;
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
        if (newState is PlayerStateFlying || newState is PlayerStateFalling)
        {
            _PlayerLive = true;
            //StartCoroutine(SpawnObject(time));
        }
        //if(newState is PlayerStateDead && newState is PlayerStateIdle)
        //{
        //    _PlayerLive = false;
        //}
    }
    private void Start()
    {
        if (_PlayerLive == true)
        {
            StartCoroutine(SpawnObject(time));
        }
       
    }

    private IEnumerator SpawnObject(float time)
    {
        while (_PlayerLive == true) // _PlayerLive true olduðu sürece çalýþ
        {
            Instantiate(PipingPrefab, new Vector3(3, Random.Range(-PipinLength, PipinLength), 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }


    }
}
