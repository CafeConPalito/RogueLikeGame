using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Dice : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;

    [SerializeField] // Valor de las caras Actual añadiendo Modificadores
    private TMP_Text[] diceFacesActualValues;
    [SerializeField] //Valor de las caras Iniciales, sin mods
    private TMP_Text[] diceFacesInitialValues;
    [SerializeField] //Valor de los modificadores
    private TMP_Text[] diceFacesModValues;
    [SerializeField] //Valor para determinar el Color de las caras
    private GameObject[] diceFacesColor;
    [SerializeField] //Valor para saber que cara quedo arriba.
    private Transform[] diceFaces;

    [SerializeField]
    private int mejoraTemporal = 0;

    //Desde donde se lanza el cubo
    [SerializeField]
    private Transform DiceSpawnPoint;
    
    //Plataforma donde se Coloca el dado
    [SerializeField]
    private BoxCollider platform;

    private bool _hasStoppedRoll;
    private bool _delayFinished;
    private bool _diceTrow;

    private int weapon=2;


    //Para Borrar
    private int _diceIndex = -1;
    //Para Borrar
    public static UnityAction<int, int> OnDiceResult;
    
    /// <summary>
    /// Metodo set y get de HasStoppedRoll del dado
    /// </summary>
    public bool HasStoppedRoll { get => _hasStoppedRoll; set => _hasStoppedRoll = value; }
    public int Weapon { get => weapon; set => weapon = value; }


    //https://www.youtube.com/watch?v=cd66wLNvVh8
    private void Update()
    {
        //Precionando la tecla espacio lanza el dado
        if (DicesControl.TrowDices && !_diceTrow)
        {
            //print($"Al lanzar el eje x es = {rb.transform.rotation.eulerAngles}");
            _diceTrow = true;
            RollDice();
        }

        if (!_delayFinished) return;

        //Comprueba que el dado termino de girar comprobando la velocidad y pasa el Boleano a true para saber que paro
        if (!_hasStoppedRoll && rb.velocity.sqrMagnitude == 0f)
        {
            _hasStoppedRoll = true;
            /*
            print($"Al parar los ejes rot son = {rb.transform.rotation.eulerAngles}");
            print($"Al parar los ejes rot normalizados son = {rb.transform.rotation.eulerAngles.normalized}");
            print($"Al parar los ejes x son = {rb.transform.rotation.eulerAngles.x}");
            print($"Al parar los ejes y son = {rb.transform.rotation.eulerAngles.y}");
            print($"Al parar los ejes z son = {rb.transform.rotation.eulerAngles.z}");
            */
        }

        //utilizando el Boleano de que ya paro el dado,
        //si la jugada termino Obtenemos el resultado
        //se ponen todos los Boleanos a false para poder volver a lanzar

        if (_hasStoppedRoll && !DicesControl.DicesRolling)
        {

            //ARREGLADO PARA MAS DE UN SPAWN POINT
            //con Movimiento
            
            /*
            float aceleration = 0.3f;
            print($" aM RB{rb.transform.position} SP{DiceSpawnPoint.position}");
            while (rb.transform.position!= DiceSpawnPoint.position) {
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, DiceSpawnPoint.position, Time.deltaTime);
                print($" DM RB{rb.transform.position} SP{DiceSpawnPoint.position}");
            }
            platform.enabled = true;
            */



            //ESTO FUNCIONA BIEN

            //lleva el dado al SpawnPoint sin Movimiento
            platform.enabled = true;
            rb.transform.position = DiceSpawnPoint.position;

            //Girar el dado para que quede con el texto bien!
            rb.transform.eulerAngles = new Vector3 (rb.transform.eulerAngles.x, 0f, rb.transform.eulerAngles.z);
            GetFaceSideUp();
            diceValuesUpdate();

            

            _hasStoppedRoll = false;
            _delayFinished = false;
            _diceTrow = false;

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
        //Debug.Log( $"Cara del dado Array {topFace}");   
        //OnDiceResult?.Invoke(_diceIndex, topFace);
        print($"masArryba{lastYPosition}");
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

        float throwForce = UnityEngine.Random.Range(15f, 20f);
        float rollForce = UnityEngine.Random.Range(3f, 5f);
        float verticalForece = 3f;
        
        rb.AddForce(transform.InverseTransformVector(0,verticalForece,throwForce),ForceMode.Impulse);

        var randX = UnityEngine.Random.Range(1f, 2f);
        var randY = UnityEngine.Random.Range(1f, 2f);
        var randZ = UnityEngine.Random.Range(1f, 2f);

        rb.AddTorque(new Vector3(randX,randY,randZ)* rollForce, ForceMode.Impulse);

        platform.enabled = false;

        DelayResult(); 
        
    }

    private async void DelayResult()
    {
        //print("entrando al wait");
        await Task.Delay(3500);
        _delayFinished = true;
        //print("Saliendo del wait");
    }

    public void diceValuesUpdate()
    {
        switch (weapon)
        {
            case 0:
                DicePrefabValues.Espada();
                break;

            case 1:
                DicePrefabValues.Escudo();
                break;
            case 2:
                DicePrefabValues.Habilidad();
                break;
        }
                for (int i = 0; i < diceFacesActualValues.Length; i++) {

            //Cargar el Initial Value 
            diceFacesInitialValues[i].SetText(DiceCreator.getValueOfFace(i)+"");

            //Cargar Modificador
            //Si el modificador es 0 lo deja en vacio
            if(mejoraTemporal == 0)
            {
                diceFacesModValues[i].SetText("");
                diceFacesActualValues[i].SetText(DiceCreator.getValueOfFace(i)+"");
            } else
            {
                //pone el valor del modificador
                diceFacesModValues[i].SetText("+ " + mejoraTemporal);
                //pone el Valor actual del dado con la suma del modificador.
                diceFacesActualValues[i].SetText((DiceCreator.getValueOfFace(i) + mejoraTemporal) + "");
            }
            
            //Segun el tipo de dado un color u otros
            int tipe = DiceCreator.getTipeOfFace(i);

            if (tipe == 1) //Ataque
            {
                diceFacesColor[i].GetComponent<Renderer>().material.color = Color.red;
                //diceFacesActualValues[i].color = Color.red;
            } else if (tipe == 2) //Defensa
            {
                diceFacesColor[i].GetComponent<Renderer>().material.color = Color.gray;
                
                //diceFacesActualValues[i].color = Color.gray;
            } else if (tipe == 3) //Habilidad
            {
                diceFacesColor[i].GetComponent<Renderer>().material.color = Color.yellow;
                //diceFacesActualValues[i].color = Color.yellow;
            }

            
        }

    }

}
