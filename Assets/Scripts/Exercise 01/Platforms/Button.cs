using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] float slideDistance = 5;  
    [SerializeField] float slideSpeed = 1;  


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController01>())
        {
            //wall.SetActive(false);
            //Debug.Log("Player on the button");

            StartCoroutine(SlideDown());
        }

    }


    void OnTriggerExit(Collider other)
    {
        //wall.SetActive(true);
        StartCoroutine(SlideUp());
    }


    IEnumerator SlideDown()
    {
        float t = 0;
        Vector3 startPosition = wall.transform.position;
        Vector3 endPosition = startPosition + Vector3.down * slideDistance;

        while(t < 1f )
        {
            t += Time.deltaTime * slideSpeed;
            wall.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

    }

        IEnumerator SlideUp()
    {
        float t = 0;
        Vector3 startPosition = wall.transform.position;
        Vector3 endPosition = startPosition - Vector3.down * slideDistance;

        while(t < 1f )
        {
            
            t += Time.deltaTime * slideSpeed;
            wall.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

    }


}
