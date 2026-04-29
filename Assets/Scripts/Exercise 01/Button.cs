using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject wall;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            wall.SetActive(false);
            //Debug.Log("Player on the button");
        }

    }


    void OnTriggerExit(Collider other)
    {
        wall.SetActive(true);
    }


}
