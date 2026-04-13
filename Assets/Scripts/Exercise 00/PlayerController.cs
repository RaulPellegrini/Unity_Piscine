using UnityEngine;


public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero; //new Vector3(0,0,0);

        if(Input.GetKey(KeyCode.W)) direction += Vector3.forward;            
        if(Input.GetKey(KeyCode.S)) direction += Vector3.back;
        if(Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if(Input.GetKey(KeyCode.D)) direction += Vector3.right;
        if(Input.GetKey(KeyCode.Space)) direction += Vector3.up;

        direction = direction.normalized;
        //rb.MovePosition(rb.position + direction *speed * Time.fixedDeltaTime);
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }
}

