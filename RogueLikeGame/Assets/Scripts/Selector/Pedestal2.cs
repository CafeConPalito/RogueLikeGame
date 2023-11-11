using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal2 : MonoBehaviour
{
    [SerializeField]
    private GameObject dice;
    [SerializeField] 
    private GameObject door;
    [SerializeField]
    private GameObject[] panels;

    private GameObject[] luces;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal0") && !GameManager.instance.Sala2){
                //print("Pedestal0");
                
                selectWeapon(3);
                foreach (GameObject go in panels)
                {
                    go.SetActive(false);
                }


            }else if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal1") && !GameManager.instance.Sala2)
            {
                //print("Pedestal1");
                selectWeapon(1);
                foreach (GameObject go in panels)
                {
                    go.SetActive(false);
                }


            }
            else if (Input.GetKey(KeyCode.T) && this.CompareTag("Pedestal2") && !GameManager.instance.Sala2)
            {
                //print("Pedestal2");
                selectWeapon(2);
                foreach (GameObject go in panels)
                {
                    go.SetActive(false);
                }

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.CompareTag("Pedestal0") && !GameManager.instance.Sala2)
            {
                panels[0].gameObject.SetActive(true);

            }
            else if (this.CompareTag("Pedestal1") && !GameManager.instance.Sala2)
            {

                panels[1].gameObject.SetActive(true);

            }
            else if (this.CompareTag("Pedestal2") && !GameManager.instance.Sala2)
            {
                panels[2].gameObject.SetActive(true);

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.CompareTag("Pedestal0") && !GameManager.instance.Sala2)
            {
                panels[0].gameObject.SetActive(false);

            }
            else if (this.CompareTag("Pedestal1") && !GameManager.instance.Sala2)
            {

                panels[1].gameObject.SetActive(false);

            }
            else if (this.CompareTag("Pedestal2") && !GameManager.instance.Sala2)
            {
                panels[2].gameObject.SetActive(false);

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
