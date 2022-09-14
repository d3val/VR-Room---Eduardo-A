using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject analogHour;
    [SerializeField] GameObject analogMinute;
    [SerializeField] GameObject analogSecond;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateClockTime();
    }

    // Set the clock hands' rotation depending on the system time.
    private void UpdateClockTime()
    {
        float HourAngle = DateTime.Now.Hour * 30;
        Vector3 angle = new Vector3(HourAngle, 0, 0);
        analogHour.transform.localEulerAngles = angle;

        float MinuteAngle = DateTime.Now.Minute * 30 / 5;
        angle = new Vector3(MinuteAngle, 0, 0);
        analogMinute.transform.localEulerAngles = angle;

        float SecondAngle = DateTime.Now.Second * 30 / 5;
        angle = new Vector3(SecondAngle, 0, 0);
        analogSecond.transform.localEulerAngles = angle;
    }
}
