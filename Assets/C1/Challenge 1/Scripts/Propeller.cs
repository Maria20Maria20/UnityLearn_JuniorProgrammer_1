using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    float z = 2000.0f; //скорость вращения пропеллера

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, z)*Time.deltaTime); 
    }
}
