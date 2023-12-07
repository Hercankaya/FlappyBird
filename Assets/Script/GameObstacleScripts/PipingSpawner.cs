using System.Collections;
using UnityEngine;

public class PipingSpawner : MonoBehaviour
{
    
    public GameObject PipingPrefab;
    public float PipinLength;
    public float CreationTime;
    public PlayerController Player;
    private void Start()
    {
        InvokeRepeating("SpawnObjectWithDelay", 2f, CreationTime);
    }

    private void SpawnObjectWithDelay()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        if (!Player.IsDead)
        {
            Instantiate(PipingPrefab, new Vector3(3, Random.Range(-PipinLength, PipinLength), 0), Quaternion.identity);
        }
        yield return null; 
    }
}
