using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Dice : MonoBehaviour
{
    
    public Transform[] diceFaces;
    public Rigidbody rb;

    private int _diceIndex = -1;

    private bool _hasStoppedRoll;
    private bool _delayFinished;
}
