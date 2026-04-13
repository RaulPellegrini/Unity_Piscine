using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;


    private PlayerController01 active_controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        active_controller = players[0].GetComponent<PlayerController01>();
        active_controller.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.Alpha1) && players[0])
        {
            Debug.Log("switching player to 1");
            if(SwitchPlayers(players[0]) != 1)
                Debug.Log("Unable to change player1");     
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && players[1])
        {
            Debug.Log("switching player to 1");
            if(SwitchPlayers(players[1]) != 1)
                Debug.Log("Unable to change player1");     
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && players[2])
        {
            Debug.Log("switching player to 1");
            if(SwitchPlayers(players[2]) != 1)
                Debug.Log("Unable to change player1");     
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && players[3])
        {
            Debug.Log("switching player to 1");
            if(SwitchPlayers(players[3]) != 1)
                Debug.Log("Unable to change player1");     
        }



    }


    int SwitchPlayers(GameObject player_to_activate)
    {   
        this.active_controller.enabled  = false;
        //active_controller.enabled = false;
        this.active_controller = player_to_activate.GetComponent<PlayerController01>();
        if(!this.active_controller)
            return(0);

        this.active_controller.enabled = true;

        return(1);
    }


}
