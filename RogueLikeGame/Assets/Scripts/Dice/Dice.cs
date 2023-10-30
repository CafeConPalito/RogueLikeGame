using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Dice : MonoBehaviour
{
    
    public Transform[] diceFaces;
    public Rigidbody rb;

    
    private int _diceIndex = -1;

    [SerializeField]
    private bool _StartRotate;
    private bool _hasStoppedRoll;
    private bool _delayFinished;
    [SerializeField]
    private bool terminoLaJugada;

    public static UnityAction<int, int> OnDiceResult;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    //https://www.youtube.com/watch?v=cd66wLNvVh8
    private void Update()
    {
        if (!terminoLaJugada && Input.GetKeyDown(KeyCode.Space))
        {
            terminoLaJugada = true;
            RollDice();
        }

        if (!_delayFinished) return;

        if (!_hasStoppedRoll && rb.velocity.sqrMagnitude == 0f)
        {
            _hasStoppedRoll = true;
            //volver el dado a la poss incial y resetear los booleanos
        }
        
        if (_hasStoppedRoll && terminoLaJugada)
        {
            
            Transform DiceSpawnPoint = GameObject.FindGameObjectWithTag("DiceSpawnPoint").transform;
            rb.transform.position = DiceSpawnPoint.position;
            GetFaceSideUp();

            //con Movimiento
            //float aceleration = 9f;
            //rb.transform.position = Vector3.MoveTowards(rb.transform.position, DiceSpawnPoint.position, Time.deltaTime * aceleration);
            //GetFaceSideUp();
            _hasStoppedRoll = false;
            terminoLaJugada = false;
            _delayFinished = false;
        }
        

    }
    
    

    
    [ContextMenu("Que cara esta arriba")]
    private int GetFaceSideUp()
    {
        if (diceFaces == null) return -1;

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
    
    private void RollDice()
    {
        
        float throwForce = UnityEngine.Random.Range(8f, 11f);
        float rollForce = UnityEngine.Random.Range(3f, 5f);

        rb.AddForce(transform.InverseTransformVector(0,0,1*(throwForce)),ForceMode.Impulse);

        var randX = UnityEngine.Random.Range(0f, 1f);
        var randY = UnityEngine.Random.Range(0f, 1f);
        var randZ = UnityEngine.Random.Range(0f, 1f);

        rb.AddTorque(new Vector3(randX,randY,randZ)* rollForce, ForceMode.Impulse);

        DelayResult();


    }

    private async void DelayResult()
    {
        await Task.Delay(1000);
        _delayFinished = true;
    }
}
