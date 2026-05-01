using UnityEngine;

public class ColoredPlatform : MonoBehaviour
{
    [SerializeField] string playerTag;

    private Collider platformCollider;



    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerController01>())
            if(!collision.gameObject.CompareTag(playerTag))
                Physics.IgnoreCollision(collision.collider, platformCollider, true);
    }

}
