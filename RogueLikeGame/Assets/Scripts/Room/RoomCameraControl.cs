using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCameraControl : MonoBehaviour
{

    [SerializeField]
    private Transform spawnPointCamera;
    [SerializeField]
    private GameObject room;

    private GameObject cam;

    private bool moveCamera;

    private void OnTriggerEnter(Collider other)
    {
        ChangeLayer.SetGameLayerRecursive(room, 0);

        if (other.CompareTag("Player") && !moveCamera)
        {
            cam = GameObject.FindGameObjectWithTag("MainCamera");
            moveCamera = true;   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeLayer.SetGameLayerRecursive(room, 6);
    }

    private void LateUpdate()
    {
        if (moveCamera && cam.transform.position == spawnPointCamera.position)
        {
            print("MoveCamera False");
            moveCamera = false;
        }
        if (moveCamera && cam.transform.position != spawnPointCamera.position) { 
            cam.transform.position = Vector3.Lerp(cam.transform.position, spawnPointCamera.position, Time.deltaTime*15);
            print("MoveCamera True");
        }
    }

}
