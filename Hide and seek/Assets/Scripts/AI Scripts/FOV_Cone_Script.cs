using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Reference to the YT video that helped me create this
//https://youtu.be/rQG9aUWarwE?t=490

public class FOV_Cone_Script : MonoBehaviour
{
    #region Fov Cone math variables
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public float viewHeight = 5f;
    #endregion

    public GameObject enemy;
    public Chase chase;
    public Count_Down_Timer c_D_T;

    public LayerMask playerLayer;
    public LayerMask obstLayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FOVroutine());
    }

    private IEnumerator FOVroutine()
    {
        float d = 0.2f; // delay

        WaitForSeconds wait = new WaitForSeconds(d);

        while (true)
        {
            yield return wait;
            FindPlayer();
        }
    }

    private void FindPlayer()
    {
        Collider[] playerInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerLayer);

        if(playerInViewRadius.Length != 0)
        {
            Transform target = playerInViewRadius[0].transform; //There should only be one player
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2) // allows for a detailed angle check
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstLayer) && c_D_T.GetComponent<Count_Down_Timer>().time == 0f)
                {
                    enemy.GetComponent<Enemy_Script>().isPlayerSeen = true;
                }
                else
                {
                    enemy.GetComponent<Enemy_Script>().isPlayerSeen = false;
                }
            }
            else
            {
                enemy.GetComponent<Enemy_Script>().isPlayerSeen = false;
            }
        }
        else if (enemy.GetComponent<Enemy_Script>().isPlayerSeen)
        {
            enemy.GetComponent<Enemy_Script>().isPlayerSeen = false;
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool isAngleGlobal)
    {
        if (!isAngleGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), viewHeight, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
