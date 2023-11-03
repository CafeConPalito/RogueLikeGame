using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicesControl : MonoBehaviour
{
    [SerializeField]
    private static bool _dicesRolling;
    private static bool _trowDices;
    
    [SerializeField]
    private GameObject[] dices;


    public static bool DicesRolling { get => _dicesRolling; set => _dicesRolling = value; }
    public static bool TrowDices { get => _trowDices; set => _trowDices = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Precionando la tecla espacio lanza el dado
        //if (Input.GetKeyDown(KeyCode.Space))
        if (!DicesControl.DicesRolling && Input.GetKeyDown(KeyCode.Space))
        {
            _trowDices = true;
            _dicesRolling = true;
            
        }

        if (dices[0].GetComponentInChildren<Dice>().HasStoppedRoll && dices[1].GetComponentInChildren<Dice>().HasStoppedRoll && dices[2].GetComponentInChildren<Dice>().HasStoppedRoll)
        {
            _trowDices = false;
            _dicesRolling = false;
        }

    }

}
