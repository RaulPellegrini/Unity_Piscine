using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private Vector3 destination =  new Vector3(5,0,0);
    [SerializeField] private float travelSpeed = 0.125f;

    private Rigidbody rb;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private float t = 0;
    private bool outbound = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPoint = transform.position;
        endPoint = transform.position + destination;
    }

    // Update is called once per frame
    void Update()
    {


        if(outbound)
        {
            t += Time.deltaTime * travelSpeed;
            t = Mathf.Clamp(t, 0f, 1f);
            rb.MovePosition(Vector3.Lerp(startPoint, endPoint, t));
            if(t >= 1)
            {
                t = 0;
                outbound = false;
            }
        }

        else
        {

            t += Time.deltaTime * travelSpeed;         
            t = Mathf.Clamp(t, 0f, 1f);            
            rb.MovePosition(Vector3.Lerp(endPoint, startPoint, t));

            if(t >= 1)
            {
                t = 0;
                outbound = true;            
            }
            
        }

    }
}
