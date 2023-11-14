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
    
    /// <summary>
    /// Triger de las salas que controlan si el player entra dentro de ellas y la camara no se esta moviendo.
    /// Si es asi:
    /// Modifica el Layer de los elementos del room
    /// Modifica el Bool que permite mover la camara
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !moveCamera)
        {
            ChangeLayer.SetGameLayerRecursive(room, 0); // Metodo que cambia el Layer de todos los Objetos de la habitacion
            cam = GameObject.FindGameObjectWithTag("MainCamera"); // Captura el Objeto MainCamera
            moveCamera = true;   
        }
    }

    /// <summary>
    /// Si el player Sale de la habitacion cambia el Layer de esta al 6 "Invisible"
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeLayer.SetGameLayerRecursive(room, 6); // Metodo que cambia el Layer de todos los Objetos de la habitacion
        }
    }

    private void LateUpdate()
    {
        if (moveCamera && cam.transform.position == spawnPointCamera.position) // Bloquea el movimiento de la camara si esta en el sitio correcto
        {
            //print("MoveCamera False");
            moveCamera = false;
        }
        if (moveCamera && cam.transform.position != spawnPointCamera.position) { // si la camara se puede mover y no esta donde tiene que estar la mueve
            cam.transform.position= spawnPointCamera.position;
            //SIN IMPLEMENTAR ES PARA REALIZAR UNA TRANSICION SUAVE DE LA CAMARA
            //cam.transform.position = Vector3.Lerp(cam.transform.position, spawnPointCamera.position, Time.deltaTime*15);
            //print("MoveCamera True");
        }
    }
}
