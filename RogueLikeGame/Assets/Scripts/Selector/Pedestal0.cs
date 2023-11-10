using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal0 : MonoBehaviour
{
    [SerializeField]
    private GameObject dice;
    [SerializeField] 
    private GameObject door;
 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal0") && !GameManager.instance.Sala0){
                //print("Pedestal0");

                selectWeapon(0);

            }else if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal1") && !GameManager.instance.Sala0)
            {
                //print("Pedestal1");
                selectWeapon(1);

            }
            else if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal2") && !GameManager.instance.Sala0)
            {
                //print("Pedestal2");
                selectWeapon(2);
            }

        }
    }

    private void selectWeapon(int Weapon)
    {
        GameManager.instance.Sala0 = true;
        dice.GetComponent<Dice>().Weapon = Weapon;
        dice.GetComponent<Dice>().diceValuesUpdate();
        ChangeLayer.SetGameLayerRecursive(dice, 0);
        door.SetActive(false);
    }

}
