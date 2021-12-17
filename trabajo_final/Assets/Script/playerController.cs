using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Mencionamos que la posicion inicial es de 0, 100, 0
    private Vector3 startPos = new Vector3(0, 100, 0);

    //Creamos funciones que nos permitan decidir la velocidad, la velocidad de voltear y el movimiento horizontal y vertical
    private float turnSpeed = 20f;
    private float speed = 20f;
    private float horizontalInput;
    private float verticalInput;

    //Damos un valor a los límites del mapa
    private float limX = 200f;
    private float limY = 200f;
    private float limZ = 200f;
    private float limLowY = 0f;


    public GameObject projectilePrefab;



    //Damos un valor a los audios y la música de fondo
    public AudioClip shootClip;
    private AudioSource cameraAudioSource;
    private AudioSource playerAudioSource;

    //Creamos la funcion "score" y el "gameOver"
    public int score;
    public bool gameOver = false;

    //Creamos las 2 funciones de los objetos del mapa
    public GameObject recoletable;
    public GameObject obstacle;

    //Creamos 2 funciones que nos permiten configurar el spawneo de los objetos en la escena
    private float spawnRate = 5f;
    private float spawnMargin = 5f;

    private Vector3 randomPos;



    // Start is called before the first frame update
    void Start()
    {
        //Mencionamos que la posicion inicial sea el valor del "startPos"
        transform.position = startPos;
        //Mencionamos que en el start, el socre es igual a 0
        score = 0;

        //Empezamos la "Coroutine"
        StartCoroutine("SpawnObstacle");

        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        playerAudioSource = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        //Decimos que el player se mueva horizontalmente y verticalmente con los controles de las flechas
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



        //Decimos que si pretamos la tecla "Space", se dispara el misil
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //dispara el misil con la tecla "Space"
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation = transform.rotation);
            //Suena un clip de audio cada vez que se dispara
            playerAudioSource.PlayOneShot(shootClip, 1);
        }
        //Si el "score" es igual a 10, termina el juego y sale en pantalla "Has Ganado"
        if (score == 10)
        {
            gameOver = true;
            Debug.Log("Has Ganado");
        }

    }
    //Posicion "random" dentro de la escena
    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-limX + spawnMargin, limX - spawnMargin), Random.Range(limLowY + spawnMargin, limY - spawnMargin), Random.Range(-limZ + spawnMargin, limZ - spawnMargin));
    }
    //Spawn del objeto aleatorio
    private IEnumerator SpawnObstacle()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            randomPos = RandomPosition();
            Instantiate(obstacle, randomPos, recoletable.transform.rotation);

        }

    }
    //Decimos que si pegamos el player contra el obstaculo, se acaba la partida
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
                Debug.Log("Has perdido");
            }
        }

    }
    //Si el player choca contra la moneda, esta se destruye y el score aumenta a 1, y si choca contra el objeto, se acaba la partida
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
