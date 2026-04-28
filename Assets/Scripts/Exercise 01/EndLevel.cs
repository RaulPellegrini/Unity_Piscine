using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;
    [SerializeField] private string nextScene;

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
            SceneManager.LoadScene(nextScene);
        }
    }


}
