using UnityEngine;




public class EndPoint : MonoBehaviour
{


    [SerializeField] private GameObject character;
    [SerializeField] private GameObject completed;

    // private void OnCollisionStay(Collision collision)
    // {
    //     while(collision.gameObject == character)
    //     {

    //     }

    // }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == character)
            completed.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == character)
            completed.SetActive(false);
    }


}


