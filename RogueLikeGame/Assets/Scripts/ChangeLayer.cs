using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{

    /// <summary>
    /// Cambia todos los Objetos dentro de Rom a la Hierarchi seleccionada 0 = Default   6 = Invisible
    /// </summary>
    /// <param name="gameObject"></param> 
    /// <param name="layer"></param> 0 = Default   6 = Invisible
    public static void SetGameLayerRecursive(GameObject gameObject, int layer)
    {
        gameObject.layer = layer;
        foreach (Transform child in gameObject.transform)
        {
            SetGameLayerRecursive(child.gameObject, layer);
        }
    }

}
