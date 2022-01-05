using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    private Vector3 offset=new Vector3(50,0,0);

    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
