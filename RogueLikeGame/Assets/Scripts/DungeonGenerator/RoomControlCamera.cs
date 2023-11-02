using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControlCamera : MonoBehaviour
{

    [SerializeField]
    private Transform spawnPointCamera;

    private GameObject cam;

    private bool moveCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !moveCamera)
        {
            print("entré, picha");
            //print(other.name);
            //Transform spawnPoint = other.transform.Find("spawnCamara");
            //print(cam.name);
            //print(spawnPoint.name);
            
            cam = GameObject.FindGameObjectWithTag("MainCamera");
            //cam.transform.position = spawnPointCamera.transform.position;
            
            //cam.transform.position = Vector3.MoveTowards(cam.transform.position, spawnPointCamera.position,Time.deltaTime*3);
            
            moveCamera = true;
            
            //enterRoom(other.transform.Find("StartPosChar"));
            //SmoothTranlation(other.transform.Find("StartPosChar"));

        }
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
