using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private GameObject[] spawnPosition;
    [SerializeField] private CameraManager cameraManager;


    private PlayerController01 active_controller;
    private KeyCode[] keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        active_controller = players[0].GetComponent<PlayerController01>();
        active_controller.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0 ; i < keys.Length ; i++ )
        {
            if(Input.GetKeyDown(keys[i]))
                SwitchPlayers(players[i]);
        }

        if(Input.GetKeyDown(KeyCode.R)) ResetPlayers();

    }

    int ResetPlayers()
    {
        if(players.Length != spawnPosition.Length)
        {
            Debug.Log("unmacthing players and spawn positions");
            return(0);
        }

        for (int i = 0; i < spawnPosition.Length ; i++)
            players[i].transform.position = spawnPosition[i].transform.position;
    
        return(1);
    }


    int SwitchPlayers(GameObject player_to_activate)
    {   
        if(player_to_activate == null) return 0;

        this.active_controller.enabled  = false;
        //active_controller.enabled = false;
        this.active_controller = player_to_activate.GetComponent<PlayerController01>();
        
        if(active_controller == null) return(0);

        active_controller.enabled = true;
        
        cameraManager.FocusChange(player_to_activate);

        return(1);
    }


}
