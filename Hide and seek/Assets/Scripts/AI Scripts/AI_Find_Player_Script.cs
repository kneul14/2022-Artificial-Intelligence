using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AI_Find_Player_Script : MonoBehaviour
{
    public float time;
    public float timerReset = 25.0f; //25
    public float boolReset = 10.0f;
    public Text timerText;
    public bool isTimeUp;
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeUp == true)
        {
            enemy.GetComponent<Enemy_Script>().isPlayerLocationKnown = true;
        }
        else
        {
            enemy.GetComponent<Enemy_Script>().isPlayerLocationKnown = false;
        }

        Timer(time);

        TimerLogic();

    }

    void Timer(float timerDisplay)
    {
        if (timerDisplay < 0)
        {
            timerDisplay = 0;
        }

        float timeInMins = Mathf.FloorToInt(timerDisplay / 60);
        float timeInSecs = Mathf.FloorToInt(timerDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", timeInMins, timeInSecs);
    }

    void TimerLogic()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time < 1)
        {
            time -= Time.deltaTime;
            Debug.Log("Enemy find Player");
        }
        else
        {
            time = 0;
        }

        if (time < 0)
        {
            isTimeUp = true;
            time = timerReset;
            StartCoroutine("SetBoolFalse");
        }
        else
        {
            //isTimeUp = false;
        }
    }

    private IEnumerator SetBoolFalse()
    {
        yield return new WaitForSeconds(10f); // 10 seconds to find the player
        if (isTimeUp == true)
        {
            isTimeUp = false;
        }
        yield return null;
    }
}
