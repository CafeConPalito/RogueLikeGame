using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColition : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnterRoom"))
        {
            enterRoom(other.transform.Find("StartPosChar"));
        }



    }


    private void enterRoom(Transform StartPosChar)
    {
        
        this.transform.position = StartPosChar.position;

    }



}
