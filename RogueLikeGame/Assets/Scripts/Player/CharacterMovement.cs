using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody characterRB;
    [SerializeField]
    private Collider characterCol;
    private static Rigidbody PlayerStaticRB;
    private static Collider  PlayerStaticCollider;

    private static bool canMove = true;

    [SerializeField]
    private float aceleration = 100.0f;

    private float angulo;
    private Vector2 movimiento;

    public static bool CanMove { get => canMove; set => canMove = value; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerStaticRB = characterRB;
        PlayerStaticCollider = characterCol;
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
        if(canMove && movimiento!= Vector2.zero){

            angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, angulo, 0), aceleration * Time.fixedDeltaTime);
        }


    }

    public static void PlayerAnimationStart()
    {
        canMove = false;
        PlayerStaticRB.useGravity = false;
        PlayerStaticRB.detectCollisions = false;
    }

    public static void PlayerAnimationStop()
    {
        canMove = true;
        PlayerStaticRB.useGravity = true;
        PlayerStaticRB.detectCollisions = true;

    }

   
    public static void PlayerEndFihth()
    {
        canMove = true;
    }

    public static IEnumerator CorutinePlayerStratFigth(Transform charFigthPoint)
    {
        
        canMove= false;
        while (PlayerStaticRB.transform.position != charFigthPoint.position)
        {
            PlayerStaticRB.transform.position = UnityEngine.Vector3.MoveTowards(PlayerStaticRB.transform.position, charFigthPoint.position, Time.deltaTime * 5);
            yield return null;
        }

    }

}

