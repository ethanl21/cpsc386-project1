using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void OnCollisionEnter2D(Collision2D other)
    {Key.keyCount+=1;
    Debug.Log("Have "+Key.keyCount);
     Destroy(gameObject);
    }

    void OnDestroy()
    {
        Debug.Log("Key received");
    }
    // Update is called once per frame
    void Update()
    {
    if (Key.keyCount>=2)
        Destroy(gameObject);
    }
}
