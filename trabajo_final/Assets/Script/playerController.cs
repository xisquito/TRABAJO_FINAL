using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0, 100, 0);

    private float turnSpeed = 20f;
    private float speed = 20f;
    private float horizontalInput;
    private float verticalInput;


    private float limX = 200f;
    private float limY = 200f;
    private float limZ = 200f;
    private float limLowY = 0f;


    public GameObject projectilePrefab;




    public AudioClip shootClip;
    private AudioSource cameraAudioSource;
    private AudioSource playerAudioSource;

    public int score;
    public bool gameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;


        

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime * -verticalInput);

        if (transform.position.x <= -limX)
        {
            transform.position = new Vector3(-limX, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= limX)
        {
            transform.position = new Vector3(limX, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= limLowY)
        {
            transform.position = new Vector3(transform.position.x, limLowY, transform.position.z);
        }
        if (transform.position.y >= limY)
        {
            transform.position = new Vector3(transform.position.x, limY, transform.position.z);
        }
        if (transform.position.z <= -limZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limZ);
        }
        if (transform.position.z >= limZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limZ);
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            //dispara el misil con la tecla "Space"
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation = transform.rotation);
            //Suena un clip de audio cada vez que se dispara
            playerAudioSource.PlayOneShot(shootClip, 1);
        }

    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Moneda"))
            {

            }
            else if (otherCollider.gameObject.CompareTag("Obstacle"))
            {

                gameOver = true;
            }
        }

    }

    private void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Moneda"))
        {
            Destroy(otherTrigger.gameObject);
            score = score + 1;
        }
        if (otherTrigger.gameObject.CompareTag("Obstacle"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);
            Debug.Log($"Puntuacion final:{score}");
        }

    }
}
