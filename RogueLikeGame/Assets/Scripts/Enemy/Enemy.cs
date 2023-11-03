using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private Transform playerPosition;

    [SerializeField]
    private bool figthEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (figthEvent)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerPosition.transform.position;
            //Mueve al personaje a este punto con calmita :D
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (!figthEvent && other.CompareTag("Player"))
        {
            figthEvent = true;
        }

    }

}
