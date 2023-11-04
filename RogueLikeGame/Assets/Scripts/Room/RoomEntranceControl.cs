using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private Transform charSpawnPoint;
    [SerializeField]
    private GameObject room;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            StartCoroutine(GoTo(other.gameObject));

        }
    }

    private float arrivalDistance;
    private IEnumerator GoTo(GameObject Player)
    {
        CharacterMovement.PlayerAnimationStart();
        while ((charSpawnPoint.position - transform.position).sqrMagnitude > arrivalDistance)
        {
            Player.transform.position = UnityEngine.Vector3.MoveTowards(Player.transform.position, charSpawnPoint.position, Time.deltaTime * 2);
            yield return null;
        }

        print("termine");
        CharacterMovement.PlayerAnimationStop();

    }



}
