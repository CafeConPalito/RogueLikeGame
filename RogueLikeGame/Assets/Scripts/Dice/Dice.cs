using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Dice : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] diceFacesValues;
    [SerializeField]
    private Transform[] diceFaces;
    [SerializeField]
    private Rigidbody rb;

    //Para Borrar
    private int _diceIndex = -1;


    private bool _hasStoppedRoll;
    private bool _delayFinished;
    
    [SerializeField]
    private bool terminoLaJugada;

    //Para Borrar
    public static UnityAction<int, int> OnDiceResult;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody>();

        DicePrefabValues.Espada();
        diceValuesUpdate();

    }

    //https://www.youtube.com/watch?v=cd66wLNvVh8
    private void Update()
    {
        //Precionando la tecla espacio lanza el dado
        if (!terminoLaJugada && Input.GetKeyDown(KeyCode.Space))
        {
            terminoLaJugada = true;
            RollDice();
        }

        if (!_delayFinished) return;

        //Comprueba que el dado termino de girar comprobando la velocidad y pasa el Boleano a true para saber que paro
        if (!_hasStoppedRoll && rb.velocity.sqrMagnitude == 0f)
        {
            _hasStoppedRoll = true;
            
        }
        
        //utilizando el Boleano de que ya paro el dado,
        //si la jugada termino Obtenemos el resultado
        //se ponen todos los Boleanos a false para poder volver a lanzar
        if (_hasStoppedRoll && terminoLaJugada)
        {
            //Debug.Log($"Dado en el Suelo = Eje X: {rb.transform.rotation.x} Eje Y: {rb.transform.rotation.y} Eje Z: {rb.transform.rotation.z} ");
            
            Transform DiceSpawnPoint = GameObject.FindGameObjectWithTag("DiceSpawnPoint").transform;
            //lleva el dado al SpawnPoint
            rb.transform.position = DiceSpawnPoint.position;
            
            //Girar el dado para que quede con el texto bien!
            rb.transform.eulerAngles = new Vector3 (rb.transform.eulerAngles.x, 0f, rb.transform.eulerAngles.z);
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
    
    

    /// <summary>
    /// Indica que cara esta hacia arriba
    /// </summary>
    /// <returns></returns>
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

        Debug.Log( $"Cara del dado Array {topFace}");
                
        OnDiceResult?.Invoke(_diceIndex, topFace);

        return topFace;

    }
    
    /// <summary>
    /// Lanzar el dado
    /// </summary>
    private void RollDice()
    {

        //Toma los valores actuales del Quaternion para identificar correctamente la direccion de lanzamiento del dado
        //Debug.Log($"Dado en la Plataforma = Eje X: {rb.transform.rotation.x} Eje Y: {rb.transform.rotation.y} Eje Z: {rb.transform.rotation.z} ");
        rb.transform.rotation = Quaternion.identity;
        //Debug.Log($"Lanzando Dado = Eje X: {rb.transform.rotation.x} Eje Y: {rb.transform.rotation.y} Eje Z: {rb.transform.rotation.z} ");

        float throwForce = UnityEngine.Random.Range(5f, 8f);
        float rollForce = UnityEngine.Random.Range(3f, 5f);
        float verticalForece = 7f;
        

        rb.AddForce(transform.InverseTransformVector(0,verticalForece,throwForce),ForceMode.Impulse);

        var randX = UnityEngine.Random.Range(1f, 2f);
        var randY = UnityEngine.Random.Range(1f, 2f);
        var randZ = UnityEngine.Random.Range(1f, 2f);

        rb.AddTorque(new Vector3(randX,randY,randZ)* rollForce, ForceMode.Impulse);

        DelayResult();
        

    }

    private async void DelayResult()
    {
        await Task.Delay(1000);
        _delayFinished = true;
    }

    private void diceValuesUpdate()
    {
        /*
        for (int i = 0; i < diceFacesValues.Length; i++) {

            diceFacesValues[i].SetText(DiceCreator.);
            

            
            // Segun el tipo de dado un color u otros
            /*
            if () //Ataque
            {
                diceFacesValues[i].color = Color.red;
            } else if () //Defensa
            {
                diceFacesValues[i].color = Color.gray;
            } else if () //Habilidad
            {
                diceFacesValues[i].color = Color.yellow;
            }
            
            
        }
        */

    }
}
