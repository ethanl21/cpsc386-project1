using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Target object will be followed by the ghost
    public GameObject targetObject;

    // Used to move the ghost
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (targetObject)
        {
            // Calculate direction towards the target object
            var direction = (targetObject.transform.position - transform.position).normalized;
            
            // Move towards the target object
            _rb.MovePosition(transform.position + direction * Time.deltaTime);
        }
    }
    
}