using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : State
{
    /// WANDER STATE IS THE DEFAULT STATE WHEN NOTHING IS HAPPENING IS THE GAME ///
    /// bunch of way points will be define and when in this state the enemy will rotated between them ///

    public GameObject enemy;
    public GameObject stateName;
    public Chase chase;
    public Search search;

    private Enemy_Nav_Mesh_Script navMeshScript;
    private Enemy_Script enemyScript;

    public bool isWandering;

    void Start()
    {
        navMeshScript = enemy.GetComponent<Enemy_Nav_Mesh_Script>();
        enemyScript = enemy.GetComponent<Enemy_Script>();
    }

    void Update()
    {
        navMeshScript.GetComponent<Animator>().enabled = true;
    }

    public override State RunCurrentState() //This function will be used instead of the original.
    {
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == true)
        {
            stateName.name = "Chase State";
            return chase;
        }
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == true && enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == true)
        {
            stateName.name = "Chase State";
            return chase;
        }
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == true)
        {
            stateName.name = "Search State";
            return search;
        }
        else
        {
            isWandering = true;
            enemyScript.GetComponent<Enemy_Script>().EnemyWanderMovement();
            stateName.name = "Wander State";
            return this;
        }
    }
}