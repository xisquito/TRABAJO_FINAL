using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutOfBonds : MonoBehaviour
{

    private float Lim = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > Lim)
        {
            Destroy(gameObject);
        }
    }
}
