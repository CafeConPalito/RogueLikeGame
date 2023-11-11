using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFace : MonoBehaviour
{
    /// <summary>
    /// 0 Vacio, Color Gris
    /// 1 Ataque, Color Rojo 
    /// 2 Defensa, Color Azul
    /// 3 Habilidad, Color Amarillo
    /// </summary>
    private int tipe;

    /// <summary>
    /// Valor del 0 al 6 para dar valor inicial a las caras de los dados.
    /// </summary>
    private int fValue; 

    public DiceFace(int tipe, int fValue)
    {
        this.tipe = tipe;
        this.fValue = fValue;
    }

    public int FValue { get => fValue; set => fValue = value; }
    public int Tipe { get => tipe; set => tipe = value; }


}
