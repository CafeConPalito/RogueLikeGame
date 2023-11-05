using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private Transform playerFigthPosition;

    [SerializeField]
    private bool figthEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!figthEvent && other.CompareTag("Player"))
        {
            figthEvent = true;
            StartCoroutine(CharacterMovement.CorutinePlayerStratFigth(playerFigthPosition));
        }

    }

}
