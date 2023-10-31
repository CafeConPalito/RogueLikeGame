using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePrefabValues : MonoBehaviour
{
    private void Awake()
    {
        Espada();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Espada()
    {
        int[] tipe = { 1, 1, 1, 1, 1, 1 };
        int[] fValue = { 1, 1, 1, 1, 1, 1 };
        DiceCreator.createDice(tipe, fValue);
    }

    public void Escudo()
    {
        int[] tipe = { 2, 2, 2, 2, 2, 2 };
        int[] fValue = { 1, 1, 1, 1, 1, 1 };
        DiceCreator.createDice(tipe, fValue);
    }

    public void Habilidad()
    {
        int[] tipe = { 3, 3, 3, 3, 3, 3 };
        int[] fValue = { 1, 1, 1, 1, 1, 1 };
        DiceCreator.createDice(tipe, fValue);
    }

}
