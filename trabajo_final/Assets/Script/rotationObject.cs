using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationObject : MonoBehaviour
{
    //Le damos un valor a la funcion "rotationSpeed" de 200
    public float rotationSpeed = 200f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Le damos la accion de dar vueltas sobre su mismo eje a la velocidad de 200 constantemente
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
