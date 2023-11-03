using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializaDecoration : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.

    [SerializeField]
    private GameObject[] decorations;

    [SerializeField]

    private GameObject[] spawnpoint;

    public void setElements()
    {
    
        foreach (GameObject element in spawnpoint)
        {
            int r= Random.Range(0,decorations.Length+1);
            if (r!= decorations.Length + 1)
            {
                GameObject x =Instantiate(decorations[r], element.transform);
            }
        }

        //Vector3 spawnPoint = transform.TransformPoint(DungeonGenerator.roomsListToOperate[0].transform.position);

        //Instantiate(myHero, spawnPoint, Quaternion.identity);

        /*
        for (int i=0; i<DungeonGenerator.roomsListToOperate.Length; i++)
        {
            print(DungeonGenerator.roomsListToOperate[i].name);
            print(i);
            print(DungeonGenerator.roomsListToOperate[i].transform.position);
        }
        */

    }

    private void Start()
    {
        setElements();
    }
}
