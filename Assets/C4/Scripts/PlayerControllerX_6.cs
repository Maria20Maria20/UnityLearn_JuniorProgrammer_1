using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX_6 : MonoBehaviour
{
    public bool gameOver;

    [SerializeField] private float floatForce;
    [SerializeField] private float yMax = 15;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    [SerializeField] private AudioClip moneySound;
    [SerializeField] private AudioClip explodeSound;


    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        if (transform.position.y > yMax) //если положение шарика больше максимально установленного значения по оси Y, то:
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z); //по оси Y останавливаем его в значении этой переменной (yMax)
            playerRb.AddForce(Vector3.down, ForceMode.Impulse); //и ещё шарик должен падать вниз, если упрётся в "потолок"
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb")|| other.gameObject.CompareTag("Ground"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }


    }

}
