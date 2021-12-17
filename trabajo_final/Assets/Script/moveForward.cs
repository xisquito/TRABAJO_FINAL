using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    //Mencionamos que damos un valor a la funcion "speed"
    public float speed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Le damos la accion de que se mueva constantemente el objeto, en este caso el player y el misil
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
