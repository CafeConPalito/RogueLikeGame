using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia estática para ser accedida desde cualquier lugar
    public static GameManager instance;

    void Awake()
    {
        // Comprueba si la instancia ya existe
        if (instance == null)
        {
            // Si no, establece la instancia a esta
            instance = this;
        }
        // Si la instancia ya existe y no es esta:
        else if (instance != this)
        {
            // Entonces destruye este objeto. Esto refuerza nuestro patrón Singleton, lo que significa que solo puede haber una instancia de un GameManager.
            Destroy(gameObject);
        }

    }

    private bool sala0=false;
    private bool sala1=false;
    private bool sala2=false;

    public bool Sala0 { get => sala0; set => sala0 = value; }
    public bool Sala1 { get => sala1; set => sala1 = value; }
    public bool Sala2 { get => sala2; set => sala2 = value; }

}
