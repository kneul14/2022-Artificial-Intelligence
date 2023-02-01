using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander_Points_Script : MonoBehaviour
{
    public static Transform[] wanderPoints;

    void Awake()
    {
        //Counts the children and creates that many children in the array and then loops through them
        wanderPoints = new Transform[transform.childCount];
        for (int i = 0; i < wanderPoints.Length; i++)
        {
            wanderPoints[i] = transform.GetChild(i);
        }
    }
}
