using UnityEngine;

public class SafeNet : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject[] spawnPos;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject == players[0])
                players[0].transform.position = spawnPos[0].transform.position;
            if(other.gameObject == players[1])
                players[1].transform.position = spawnPos[1].transform.position;
            if(other.gameObject == players[2])
                players[2].transform.position = spawnPos[2].transform.position;
        }
        else
            Destroy(other.gameObject);
    }
}
