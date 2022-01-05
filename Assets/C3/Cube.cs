using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private int random;
    
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.5f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        InvokeRepeating("Repeat", 3.0f, 5.0f);
    }
    
    void Update()
    {
        transform.Rotate(0, 20.0f*Time.deltaTime, 0.0f);



        if (Input.GetKeyDown(KeyCode.C))
        {
            Material material = Renderer.material;
            random = Random.Range(0, 3);


            if (random == 0)
            {
                material.color = new Color(1.5f, 1.0f, 0.3f, 0.4f); //orange
            }
            else if (random == 1)
            {
                material.color = new Color(0.5f, 3.0f, 0.3f, 0.4f); //green light
            }
            else if(random==2)
            {
                material.color = new Color(0.5f, 1.0f, 0.9f, 0.4f); //blue
            }


        }
    }

    void Repeat()
    {
        int randomTwo = Random.Range(-10, 10);
        cube.transform.position = new Vector3(randomTwo, 0, 0);
    }
}
