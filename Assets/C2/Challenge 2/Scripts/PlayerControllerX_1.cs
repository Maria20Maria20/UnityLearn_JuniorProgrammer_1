using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX_1 : MonoBehaviour
{
    [SerializeField] private GameObject dogPrefab;
    [SerializeField] private float maxTime = 3;
    [SerializeField] private float timer = 3.0f;
    [SerializeField] private bool dogSpawn = true; //нужно для проверки, можно ли в определённый момент спаунить собаку или нет


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dogSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation); 
            dogSpawn = false; //ставим dogSpawn на false, чтобы в момент создания собаки нельзя было сразу выпустить новый объект
        }

        if (timer > 0) 
        { 
            timer -= Time.deltaTime; 
        }
        else 
        {
            dogSpawn = true; //возобновляем спаун собак
            timer = maxTime; //и возобновляем таймер
        }
    }
}
