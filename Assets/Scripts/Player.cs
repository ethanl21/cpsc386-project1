using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int keyCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        // If the player collides with a key
        if (collider.gameObject.tag == "Key")
        {
            // Increment keyCount
            keyCount += 1;
            
            // Destroy the key
            Destroy(collider.gameObject);
        }
    }
}
