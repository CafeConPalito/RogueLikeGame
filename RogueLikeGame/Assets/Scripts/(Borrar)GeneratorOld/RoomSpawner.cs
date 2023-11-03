using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    //1 Necesita una sala con una entrada hacia Abajo - Down (SpawnPointTop)
    //2 Necesita una sala con una entrada hacia Arriba - Up  (SpawnPointDown)
    //3 Necesita una sala con una entrada hacia Izquierda - Left (SpawnPointRight)
    //4 Necesita una sala con una entrada hacia Derecha - Right (SpawnPointLeft)


    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    
    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
        //Spawn();
    
    }


    //
    // Resumen:
    //     Metodo que spawnea salas. si hay un objeto en el juego con un SpawnPoint Activo (opening direction) le coloca una sala.
    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                // Need to spawn a room with a BOTTOM door.
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                
            }
            else if (openingDirection == 2)
            {
                // Need to spawn a room with a TOP door.
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // Need to spawn a room with a LEFT door.
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // Need to spawn a room with a RIGHT door.
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Component c = gameObject.GetComponentInParent<RoomSpawner>();
                Debug.Log("Componente: " + c.name);
                print("Componente: " + c.name);
                Destroy(gameObject);

                
            }
            spawned = true;
        }
    }
    
    

}
