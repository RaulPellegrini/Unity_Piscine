using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;

    public void Update()
    {
        LevelComplete();
    }

    private void LevelComplete()
    {
        int playersToArrive = 0;


        for(int i = 0; i < endPoints.Length; i++ )
        {
            if(endPoints[i].activeSelf)
            {
                playersToArrive++;            
            }
        }

        if(playersToArrive == endPoints.Length)
        {
            Debug.Log("LevelCompleted");
        }
    }


}
