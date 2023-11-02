using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeElements : MonoBehaviour
{

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
 
    public GameObject myHero;
    //public GameObject parentRoom;
    private bool elementsOnDungeon;// controla la colocacion de los personajes y elementos dentro del programa.

    public void setElements()
    {



        // Instantiate at position (0, 0, 0) and zero rotation.
        Vector3 spawnPoint = transform.TransformPoint(DungeonGenerator.roomsListToOperate[0].transform.position);

        Instantiate(myHero,spawnPoint, Quaternion.identity);

        //parentRoom = DungeonGenerator.roomsListToOperate[0].transform.parent.gameObject;
        //var newMyHero = Instantiate(myHero, parentRoom.transform);
        //print(parentRoom.name);

        //GameObject newObjet = Instantiate(myHero);
        //newObjet.transform.parent = DungeonGenerator.roomsListToOperate[0].gameObject.transform;
        //newObjet.transform.position = Vector3.zero;



        for (int i=0; i<DungeonGenerator.roomsListToOperate.Length; i++)
        {
            print(DungeonGenerator.roomsListToOperate[i].name);
            print(i);
            print(DungeonGenerator.roomsListToOperate[i].transform.position);
        }
        
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