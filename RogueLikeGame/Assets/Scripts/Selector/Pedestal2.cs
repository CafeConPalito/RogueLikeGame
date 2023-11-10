using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal2 : MonoBehaviour
{
    [SerializeField]
    private GameObject dice;
    [SerializeField] 
    private GameObject door;

    private GameObject[] luces;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal0") && !GameManager.instance.Sala2){
                //print("Pedestal0");

                selectWeapon(0);

            }else if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal1") && !GameManager.instance.Sala2)
            {
                //print("Pedestal1");
                selectWeapon(1);

            }
            else if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal2") && !GameManager.instance.Sala2)
            {
                //print("Pedestal2");
                selectWeapon(2);
            }

        }
    }

    private void selectWeapon(int Weapon)
    {
        GameManager.instance.Sala2 = true;
        dice.GetComponent<Dice>().Weapon = Weapon;
        dice.GetComponent<Dice>().diceValuesUpdate();
        ChangeLayer.SetGameLayerRecursive(dice, 0);
        door.SetActive(false);
        Destroy(this);

        Destroy(this.gameObject);

        luces = GameObject.FindGameObjectsWithTag("SpotLight2");

        foreach (GameObject go in luces)
        {
            Destroy(go);
        }
    }

}
