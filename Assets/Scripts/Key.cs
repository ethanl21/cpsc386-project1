using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static int keyCount =0;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void OnCollisionEnter2D(Collision2D other)
    {keyCount+=1;
    Debug.Log("Have "+keyCount);
     Destroy(gameObject);
    }

    void OnDestroy()
    {
        Debug.Log("Key received");
    }
    // Update is called once per frame
    void Update()
    {
    if (keyCount>=1)
        Destroy(gameObject);
    }
}
