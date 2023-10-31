using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody characterRB;

    [SerializeField]
    private float aceleration = 100.0f;

    private int rotationgrade = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //SI SE TRABAJA CON FISICAS HAY QUE USAR EL FIXEDUPDATE
    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        characterRB.velocity = new Vector3(horizontal * aceleration * Time.fixedDeltaTime, 0, vertical * aceleration * Time.fixedDeltaTime);

        //ROTACION A 8 PUNTOS
        if (((vertical > 0 && vertical <= 1) && horizontal == 0) )
        {
            //Debug.Log("W");
            rotation(90);
            
        }
        else if (((vertical < 0 && vertical >= -1) && horizontal == 0))
        {
            //Debug.Log("S");
            rotation(270);

        }

        if (((horizontal > 0 && horizontal <= 1) && vertical == 0))
        {
            //Debug.Log("D");
            rotation(180);
        }
        else if (((horizontal < 0 && horizontal >= -1) && vertical == 0))
        {
            //Debug.Log("A");
            rotation(0);
        }
        else if (((vertical > 0 && vertical <= 1) && (horizontal < 0 && horizontal >= -1)))
        {
            //Debug.Log("WA");
            rotation(45);
        }
        else if (((vertical > 0 && vertical <= 1) && (horizontal > 0 && horizontal <= 1)))
        {
            //Debug.Log("WD");
            rotation(135);
        }
        else if (((horizontal < 0 && horizontal >= -1) && (vertical < 0 && vertical >= -1)))
        {
            //Debug.Log("AS");
            rotation(315);
        }
        else if (((vertical < 0 && vertical >= -1) && (horizontal > 0 && horizontal <= 1)))
        {
            //Debug.Log("SD");
            rotation(225);
        }

    }

    private void rotation(int grade)
    {
        if (rotationgrade < grade)
        {
            this.transform.Rotate(0, 5, 0, Space.Self);
            rotationgrade += 5;

        }
        else if (rotationgrade > grade )
        {
            this.transform.Rotate(0, -5, 0, Space.Self);
            rotationgrade -= 5;
        }
    }

    }

