using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Dice : MonoBehaviour
{
    
    public Transform[] diceFaces;
    public Rigidbody rb;

    private int _diceIndex = -1;

    private bool _hasStoppedRoll;
    private bool _delayFinished;

    public static UnityAction<int, int> OnDiceResult;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    //https://www.youtube.com/watch?v=cd66wLNvVh8
    private void Update()
    {
        if (!_delayFinished) return;

        if (!_hasStoppedRoll && rb.velocity.sqrMagnitude == 0f)
        {
            _hasStoppedRoll = true;
            GetFaceSideUp();
        }
    }
    

    
    [ContextMenu("Que cara esta arriba")]
    private int GetFaceSideUp()
    {
        if (diceFaces != null) return -1;

        var topFace = 0;
        var lastYPosition = diceFaces[0].position.y;

        // por cada cara del dado comprobamos cual esta mas arriba
        for (int i = 0; i < diceFaces.Length; i++)
        {
            if (diceFaces[i].position.y > lastYPosition) {

                lastYPosition = diceFaces[i].position.y;
                topFace = i;

            }
        }

        Debug.Log( $"Dice result {topFace}");

        OnDiceResult?.Invoke(_diceIndex, topFace);

        return topFace;

    }
    
}
