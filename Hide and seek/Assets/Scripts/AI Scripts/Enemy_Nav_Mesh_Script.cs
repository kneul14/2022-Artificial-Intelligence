using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_Nav_Mesh_Script : MonoBehaviour
{
    NavMeshAgent navMesh; //reference to the Nav Mesh
    [SerializeField] Transform playerPos;
    [SerializeField] Transform currentPos;
    public Animator anim;
    float s = 2.0f;


    public Chase chase;
    public Wander wander;
    private Enemy_Script enemyScript;
    public Count_Down_Timer c_D_T;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("Speed", s);
    }

    // Update is called once per frame
    void Update()
    {
        SetToChaseState();
        SetToWanderState();
        if(c_D_T.GetComponent<Count_Down_Timer>().time == 0f)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void SetToChaseState()
    {
       if(chase.GetComponent<Chase>().isChasing == true)
        {
            transform.LookAt(currentPos);
            Debug.Log("chase script");
            anim.Play("Walk_N");
            navMesh.destination = playerPos.position;
        }
        else
        {
            s = 0.0f;
            navMesh.destination = currentPos.position;
        }
    }

    public void SetToWanderState()
    {
        if (wander.GetComponent<Wander>().isWandering == true)
        {
            transform.LookAt(currentPos);
            Debug.Log("wander script");
            anim.Play("Walk_N");
            navMesh.destination = playerPos.position;
        }
        else
        {
            s = 0.0f;
            navMesh.destination = currentPos.position;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.tag != null)
        {
            enemyScript.GetComponent<Enemy_Script>().isPlayerSeen = false;
            chase.GetComponent<Chase>().isChasing = false;
        }

    }
}
