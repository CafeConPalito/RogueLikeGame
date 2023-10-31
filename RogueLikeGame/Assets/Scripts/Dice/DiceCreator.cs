using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCreator : MonoBehaviour 
{

    private static DiceFace[] faces = new DiceFace[6];
    //private readonly DiceFace valor;

    public static void createDice(DiceFace[] caras)
    //public static void createDice(int[] tipe, int[] fValue)
    {
        for (int i = 0; i < faces.Length; i++)
        {
            //valor.Tipe = 2;
            //sout(valor.Tipe)

            //valor.Tipe = tipe[i];
            //valor.FValue = fValue[i];

            faces[i] = caras[i];

            //NO LE GUSTA EL NEW
            //faces[0] = new DiceFace(tipe[i],fValue[i]);

        }
    }

    public static int getValueOfFace (int index)
    {
        return faces[index].FValue;
    }

    public static int getTipeOfFace (int index)
    {
        return faces[index].Tipe;
    }

    public static void modifiValueOfFace(int index, int fValue)
    {
        faces[index].FValue = fValue;
    }

    public static void modifiFaceOfDice(int index, int tipe, int fValue)
    {
        faces[index].Tipe = tipe;
        faces[index].FValue = fValue;
    }

}
