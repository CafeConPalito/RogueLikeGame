using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterCollition : MonoBehaviour
{

    [SerializeField]
    private float aceleration = 1f;

    //Evento de la habitacion resuelto
    private bool roomEvent = false;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnterRoom"))
        {
            print("entré, picha");
            print(other.name);
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");

            Transform spawnPoint = other.transform.Find("spawnCamara");
            print(cam.name);
            print(spawnPoint.name);
            //cam.transform.position = Vector3.MoveTowards(cam.transform.position, spawnPoint.position,Time.deltaTime*3);
            
            //enterRoom(other.transform.Find("StartPosChar"));
            //SmoothTranlation(other.transform.Find("StartPosChar"));
        }
    }
    

    /*
    //Funciona como un update de Triger
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("EnterRoom"))
        {
            Transform StartPosChar = other.transform.Find("StartPosChar");
            if (!roomEvent && this.transform.position != StartPosChar.position)
            {

                this.transform.position = Vector3.MoveTowards(this.transform.position, StartPosChar.position, Time.deltaTime * aceleration);

                //this.transform.position = Vector3.Lerp(this.transform.position, StartPosChar.position, Time.deltaTime * aceleration);

            } else if (!roomEvent && this.transform.position == StartPosChar.position)
            {
                //Resuelto el evento!
                roomEvent = true;
            }

        }

    }*/


}
