using System.Collections;
using UnityEngine;

public class PlayerController01 : MonoBehaviour
{
    
    private Rigidbody rb;
    private Collider passingthrow;
    
    [Header("Debug")]
    [SerializeField] private bool grounded = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.08f;
    [SerializeField] private bool wallJumping = false;
    [SerializeField] private float checkWallDistance = 0.6f;

    [Header("Movement Settings")]
    [SerializeField] private int speed = 5;
    [SerializeField] private int jumpForce = 5;

    [SerializeField] private int wallJumpForce = 5;
    [Header("Passing Through Settings")]
    [SerializeField] private float transparencyTime = 1f;

    private Vector3 direction = Vector3.zero;
    private bool jump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        passingthrow = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        if(Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if(Input.GetKey(KeyCode.D)) direction += Vector3.right;

        grounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        

        if(grounded)
        {
            if(Input.GetKeyDown(KeyCode.Space)) jump = true;
            if(Input.GetKeyDown(KeyCode.S)) StartCoroutine(PassingThrough());

        }

        if(!grounded)
        {
            wallJumping = Physics.Raycast(transform.position,Vector3.left, checkWallDistance, groundLayer) || 
                Physics.Raycast(transform.position,Vector3.right, checkWallDistance, groundLayer);


            if(wallJumping)
            {
                
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                if(Input.GetKeyDown(KeyCode.Space)) jump = true;
            }
        }

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

    // private void OnCollisionExit(Collision other)
    // {
    //     //if(other.gameObject.CompareTag("Floor") && grounded)
    //     if(other.gameObject.CompareTag("Floor") ||other.gameObject.CompareTag("Player"))
    //         grounded = false;

    // }

    // private void OnCollisionEnter(Collision other)
    // {        
    //     //if(other.gameObject.CompareTag("Floor") && !grounded)
    //     if(other.gameObject.CompareTag("Floor") ||other.gameObject.CompareTag("Player"))
    //         grounded = true;

    // }

    IEnumerator PassingThrough() //this is a courotine
    {
        if(passingthrow.enabled)
        {
            grounded = false;
            passingthrow.enabled = false;
            yield return new WaitForSeconds(transparencyTime);
            passingthrow.enabled = true;
            
        }

    }

}
