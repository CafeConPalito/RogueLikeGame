using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControlCamera : MonoBehaviour
{

    [SerializeField]
    private Transform spawnPointCamera;
    [SerializeField]
    private GameObject room;

    private GameObject cam;

    private bool moveCamera;

    private void OnTriggerEnter(Collider other)
    {
        
        SetGameLayerRecursive(room, 0);
        
        if (other.CompareTag("Player") && !moveCamera)
        {
            cam = GameObject.FindGameObjectWithTag("MainCamera");
            moveCamera = true;   
        }
        
        /*
        SetGameLayerRecursive(room, 0);

        if (other.CompareTag("Player")  && cam.transform.position != spawnPointCamera.position)
        {
            
            StartMoving();
        }
        */

    }

    private void OnTriggerExit(Collider other)
    {
        SetGameLayerRecursive(room, 6);
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
    /// <summary>
    /// Cambia todos los Objetos dentro de Rom a la Hierarchi seleccionada 0 = Default   6 = Invisible
    /// </summary>
    /// <param name="gameObject"></param> 
    /// <param name="layer"></param> 0 = Default   6 = Invisible
    private void SetGameLayerRecursive(GameObject gameObject, int layer)
    {
        gameObject.layer = layer;
        foreach (Transform child in gameObject.transform)
        {
            SetGameLayerRecursive(child.gameObject, layer);
        }
    }


    void StartMoving()
    {
        StartCoroutine(DoMoving());
    }

    IEnumerator DoMoving()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, spawnPointCamera.position, Time.deltaTime * 15);
        yield return new WaitForSeconds(2f);

        // ... other sequential actions here?
    }

}
