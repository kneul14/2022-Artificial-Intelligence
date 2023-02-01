using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    /// IDLE STATE ALLOWS THE PLAYER TO HIDE AT THE BEGINNING OF THE GAME ///

    public GameObject enemy;
    public GameObject stateName;
    public Chase chase;
    public Wander wander;
    public Count_Down_Timer c_D_T;

    private Enemy_Script enemyScript;

    void Start()
    {
        enemyScript = enemy.GetComponent<Enemy_Script>();
    }

    private void Update()
    {
        RunCurrentState();
    }

    public override State RunCurrentState() //This function will be used instead of the original.
    {
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == true && c_D_T.GetComponent<Count_Down_Timer>().time == 0f)
        {
            stateName.name = "Chase State";
            return chase;
        }
        else if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == false && c_D_T.GetComponent<Count_Down_Timer>().time == 0f)
        {
            stateName.name = "Wander State";
            return wander;
        }
        else if (c_D_T.GetComponent<Count_Down_Timer>().time != 0f)
        {
            stateName.name = "Idle State";
            return this;
        }
        else
        {
            stateName.name = "Idle State";
            return this;
        }
    }
}