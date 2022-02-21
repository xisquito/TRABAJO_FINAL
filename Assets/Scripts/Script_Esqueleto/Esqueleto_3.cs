using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto_3 : MonoBehaviour
{
    private float speed = 3f;
    private float verticalInput;
    private float LimY = 2f;
    private float PosY = 0f;
    private float randomY;
    private float waiter;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiter());

        verticalInput = Input.GetAxis("Vertical");
        


        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);


        if (transform.position.y > 1.3f)
        {
            transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);
        }

        if (transform.position.y < 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        }

        if (transform.position.y == 1.3f)
        {
            transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //transform.Translate(new Vector3(transform.position.x, -3.5f, transform.position.z) * Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        }

        IEnumerator waiter()
        {
            
            int wait_time = Random.Range(0, 5);
            yield return new WaitForSeconds(wait_time);
            
        }


    }

}

