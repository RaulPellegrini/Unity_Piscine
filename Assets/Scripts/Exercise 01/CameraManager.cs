using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineCamera cinemachineCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void FocusChange (GameObject playerInFocus)
    {

        this.cinemachineCamera.Follow = playerInFocus.transform;
        
    }



}


