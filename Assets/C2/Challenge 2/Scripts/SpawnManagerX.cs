using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [SerializeField] private GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private float startDelay = 1.0f;

    void Start()
    {
        Invoke("SpawnRandomBall", startDelay); 
    }

    void SpawnRandomBall ()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        Invoke("SpawnRandomBall", Random.Range(3, 10)); //то есть функция SpawnRandomBall (появление шарика) будет выполняться в рандомное время от 3 до 10 секунд.
    }

}
