using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeElements : MonoBehaviour
{

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
 
    public GameObject myHero;
    public GameObject bigBoss;
    //public GameObject parentRoom;
    private bool elementsOnDungeon;// controla la colocacion de los personajes y elementos dentro del programa.

    public void setElements()
    {

        Vector3 spawnPoint = transform.TransformPoint(DungeonGenerator.roomsListToOperate[0].transform.position);

        Instantiate(myHero,spawnPoint, Quaternion.identity);

        /*
        for (int i=0; i<DungeonGenerator.roomsListToOperate.Length; i++)
        {
            print(DungeonGenerator.roomsListToOperate[i].name);
            print(i);
            print(DungeonGenerator.roomsListToOperate[i].transform.position);
        }
        */

        spawnPoint = transform.TransformPoint(DungeonGenerator.roomsListToOperate[DungeonGenerator.roomsListToOperate.Length - 1].transform.position);
        Instantiate(bigBoss, spawnPoint, Quaternion.identity);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}