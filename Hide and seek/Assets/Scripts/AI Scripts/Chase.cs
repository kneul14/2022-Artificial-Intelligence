using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : State
{
    /// CHASE STATE ALLOWS THE ENEMY TO CHASE THE PLAYER WHEN THE PLAYER CAN BE SEEN ///

    public GameObject enemy;
    public GameObject stateName;
    public Wander wander;
    public Search search;

    private Enemy_Script enemyScript;
    private Enemy_Nav_Mesh_Script navMeshScript;

    public bool isChasing;

    void Start()
    {
        enemyScript = enemy.GetComponent<Enemy_Script>();
        navMeshScript = enemy.GetComponent<Enemy_Nav_Mesh_Script>();
    }

    void Update()
    {
        navMeshScript.GetComponent<Animator>().enabled = true;
    }

    public override State RunCurrentState() //This function will be used instead of the original.
    {
        if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == false && enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == false) //If player can't be seen and location isn't known, wander.
        {
            stateName.name = "Wander State";
            return wander;
        }
        else if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == false && enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == true) //If player can't be seen but location is know, head to towards the direction of the player
        {
            stateName.name = "Search State";
            return search;
        }
        else if (enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == true && enemyScript.GetComponent<Enemy_Script>().isPlayerLocationKnown == false) //If player can't be seen but location is known, head to towards the direction of the player
        {
            stateName.name = "Chase State";
            isChasing = true;
            return this;
        }
        else if(enemyScript.GetComponent<Enemy_Script>().isPlayerSeen == true) //If player can be seen, chase.
        {
            stateName.name = "Chase State";
            isChasing = true;
            return this; 
        }
        else    //If player can be seen and location is known, chase.
        {
            stateName.name = "Chase State";
            isChasing = true;
            return this;
        }
    }

    public void ChangeToWander(State state)
    {
        if (!isChasing)
        {
            navMeshScript.GetComponent<Enemy_Nav_Mesh_Script>().SetToWanderState();
            state = wander;
        }
    }

}