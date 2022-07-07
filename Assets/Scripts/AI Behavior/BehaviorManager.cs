using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    private string behavior;
    private int agroDist;
    private int idleTime;
    private int patrollTime;
    private float time;
    // states could be idle , patroll , or agro
    // Start is called before the first frame update
    void Start()
    {
        behavior = "idle";
        agroDist = 10;
        idleTime = 10;
        patrollTime = 20;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(((player.transform.position.x - transform.position.x) < agroDist) || ((player.transform.position.y - transform.position.y) < agroDist))
        {
            behavior = "agro";
            time = 0;
        }
        else
        {
            //handle changing state based on time and distance conditions
            if(behavior == "agro")
            {
                behavior = "patroll";
                time = 0;
            }
            else if((behavior == "idle") && (time > idleTime))
            {
                behavior = "patroll";
                time = 0;
            }
            else if((behavior == "patroll") && (time > patrollTime))
            {
                behavior = "idle";
                time = 0;
            }
            time += Time.deltaTime;
        }


    }
    public string getBehavior()
    {
        return behavior;
    }
}
