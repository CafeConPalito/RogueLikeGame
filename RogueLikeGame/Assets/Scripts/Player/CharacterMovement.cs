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

    private float angulo;
    private Vector2 movimiento;

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
        characterRB.velocity = new Vector3(horizontal * aceleration * Time.fixedDeltaTime,0, vertical * aceleration * Time.fixedDeltaTime);

       movimiento= new Vector2(horizontal*-1,vertical);
        if(movimiento!= Vector2.zero){

            angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, angulo, 0), aceleration * Time.fixedDeltaTime);
        }


    }

    }

