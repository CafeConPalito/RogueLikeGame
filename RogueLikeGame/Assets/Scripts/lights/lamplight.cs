using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamplight : MonoBehaviour
{
    private Light lt;
    private float minRange=0.5f;
    private float maxRange=1.5f;
    private float flickerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        lt.intensity = minRange;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (minRange==lt.intensity)
        {

            flickerSpeed = UnityEngine.Random.Range(1f, 5f);
            
        }
        
        lt.intensity = Mathf.Lerp(minRange, maxRange, Mathf.PingPong(Time.time, flickerSpeed));

        //lt.intensity = Mathf.Lerp(minRange, maxRange, Mathf.PingPong(Time.time, flickerSpeed));

        //lt.intensity = Mathf.Lerp(1f, 3f, Time.time / 5);
        //lt.intensity = UnityEngine.Random.Range(1f, 3f);
        //lt.range = UnityEngine.Random.Range(5f, 7f);
        //lt.intensity = Mathf.Lerp(minRange, maxRange, Mathf.PingPong(Time.time, flickerSpeed));
    }
}
