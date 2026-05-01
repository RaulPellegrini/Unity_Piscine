using System.Collections;
using UnityEngine;

public class PlayerController01 : MonoBehaviour
{
    
    private Rigidbody rb;
    
    [Header("Debug")]
    [SerializeField] private bool grounded = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.08f;

    [Header("Movement Settings")]
    [SerializeField] private int speed = 5;
    [SerializeField] private int jumpForce = 5;


    private Vector3 direction = Vector3.zero;
    private bool jump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        if(Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if(Input.GetKey(KeyCode.D)) direction += Vector3.right;

        grounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        

        if(grounded)
            if(Input.GetKeyDown(KeyCode.Space)) jump = true;


    }

    void FixedUpdate()
    {
            direction = direction.normalized;
            //rb.transform.position = rb.transform.position + direction * speed * Time.deltaTime;    
            rb.MovePosition(rb.transform.position + direction * speed * Time.deltaTime);


            if(jump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jump = false;
            }



    }

    // IEnumerator PassingThrough() //this is a courotine
    // {
    //     if(passingthrow.enabled)
    //     {
    //         grounded = false;
    //         passingthrow.enabled = false;
    //         yield return new WaitForSeconds(transparencyTime);
    //         passingthrow.enabled = true;
            
    //     }

    // }

}
