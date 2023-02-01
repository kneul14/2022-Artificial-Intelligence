using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : State
{
    /// SEARCH STATE ALLOWS THE ENEMY TO SEARCH FOR THE PLAYER WHEN THE TIMER HITS ZERO ///

    GameObject enemy;
    public Transform player;
    public GameObject stateName;

    public Wander wander;
    public Chase chase;
    public bool isPlayerInTagRange;
    private Enemy_Script enemyScript;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScript = enemy.GetComponent<Enemy_Script>();
    }

    public override State RunCurrentState() //This function will be used instead of the original.
    {
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == false && enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == true)
        {
            Debug.Log("Searching for Player");
            stateName.name = "Search State";
            return this;
        }
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == true && enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == true)
        {
            stateName.name = "Chase State";
            return chase;
        }
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == false && enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == false)
        {
            stateName.name = "Wander State";
            return wander;
        }
        else
        {
            stateName.name = "Wander State";
            return wander;
            //stateName.name = "Search State";
            //return this;
        }
    }
}