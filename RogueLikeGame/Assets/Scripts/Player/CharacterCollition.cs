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
