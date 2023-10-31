using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePrefabValues : MonoBehaviour
{
    private void Awake()
    {
        //Espada();
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
        DiceFace[] faces = new DiceFace[6];
        faces[0] = new DiceFace(1, 1);
        faces[1] = new DiceFace(1, 1);
        faces[2] = new DiceFace(1, 1);
        faces[3] = new DiceFace(1, 1);
        faces[4] = new DiceFace(1, 1);
        faces[5] = new DiceFace(1, 1);
        DiceCreator.createDice(faces);

    }


    public static void Escudo()
    {
        DiceFace[] faces = new DiceFace[6];
        faces[0] = new DiceFace(2, 1);
        faces[1] = new DiceFace(2, 1);
        faces[2] = new DiceFace(2, 1);
        faces[3] = new DiceFace(2, 1);
        faces[4] = new DiceFace(2, 1);
        faces[5] = new DiceFace(2, 1);
        DiceCreator.createDice(faces);
    }

    public static void Habilidad()
    {
        DiceFace[] faces = new DiceFace[6];
        faces[0] = new DiceFace(3, 3);
        faces[1] = new DiceFace(3, 4);
        faces[2] = new DiceFace(3, 5);
        faces[3] = new DiceFace(3, 6);
        faces[4] = new DiceFace(3, 7);
        faces[5] = new DiceFace(3, 8);
        DiceCreator.createDice(faces);
    }

}
