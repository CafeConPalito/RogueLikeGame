using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCreator : MonoBehaviour
{

    DiceFace[] faces = new DiceFace[6];

    public DiceCreator()
    {
        faces[0] = new DiceFace(1, 1);
        faces[1] = new DiceFace(1, 1);
        faces[2] = new DiceFace(1, 1);
        faces[3] = new DiceFace(1, 1);
        faces[4] = new DiceFace(1, 1);
        faces[5] = new DiceFace(1, 1);
    }

    public int getValueOfFace (int index)
    {
        return faces[index].FValue;
    }

    public int getTipeOfFace (int index)
    {
        return faces[index].Tipe;
    }

    public void modifiValueOfFace(int index, int fValue)
    {
        faces[index].FValue = fValue;
    }

    public void modifiFaceOfDice(int index, int tipe, int fValue)
    {
        faces[index].Tipe = tipe;
        faces[index].FValue = fValue;
    }

}
