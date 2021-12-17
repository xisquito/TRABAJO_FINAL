using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutOfBonds : MonoBehaviour
{
    //Creamos una función que nos permita dar un valor al "Lim"
    private float Lim = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si la posicion en "z" supera el valor del "lim", se destruye el objeto. Nos permite que el misil explote en superar ese valor
        if (transform.position.z > Lim)
        {
            Destroy(gameObject);
        }
    }
}
