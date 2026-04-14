using System.Collections;
using UnityEngine;

public class PlayerController01 : MonoBehaviour
{
    
    private Rigidbody rb;
    private Collider passingthrow;
    
    [Header("Debug")]
    [SerializeField] private bool grounded = false;
    [Header("Movement Settings")]
    [SerializeField] private int speed = 5;
    [SerializeField] private int jumpForce = 5;
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
        if(grounded)
        {
            direction = Vector3.zero;
            if(Input.GetKey(KeyCode.A)) direction += Vector3.left;
            if(Input.GetKey(KeyCode.D)) direction += Vector3.right;
            if(Input.GetKeyDown(KeyCode.Space)) jump = true;
            if(Input.GetKeyDown(KeyCode.S)) StartCoroutine(PassingThrough());

        }

    }

    void FixedUpdate()
    {
            direction = direction.normalized;
            rb.transform.position = rb.transform.position + direction * speed * Time.deltaTime;    
            
            if(jump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jump = false;
            }

    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Floor") && grounded)
            grounded = false;

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Floor") && !grounded)
            grounded = true;

    }

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
