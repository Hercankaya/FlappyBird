using System.Collections;
using UnityEngine;

public class PipingSpawner : MonoBehaviour
{
    public PlayerMoveScript Player;
    public GameObject PipingPrefab;
    public float PipinLength;
    public float CreationTime;
    private void Start()
    {
        StartCoroutine(SpawnObject(CreationTime));
    }
    public IEnumerator SpawnObject( float CreationTime)
    {
        while(!Player.IsDead)
        {
            Instantiate(PipingPrefab, new Vector3(3,Random.Range(-PipinLength, PipinLength),0),Quaternion.identity);
            yield return new WaitForSeconds(CreationTime);
        }
       
    }
}
