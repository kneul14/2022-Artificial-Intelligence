using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_Down_Timer : MonoBehaviour
{
    public float time;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }

        Timer(time);

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
}
