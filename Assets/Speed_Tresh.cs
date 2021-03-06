using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Tresh : MonoBehaviour
{
    public float threshold;
    public float timer;
    private SpeedTracker speedtracker;

    //To detect change of rig
    private GameObject Transition_Handler;
    private Rig_Handler Rig_Handler;
    private GameObject rig;


    // Start is called before the first frame update
    void Start()
    {
        speedtracker = GetComponentInParent<SpeedTracker>();
        timer = 0.0f;

        Transition_Handler = GameObject.Find("Transition_Handler");
        Rig_Handler = Transition_Handler.GetComponent<Rig_Handler>();
        rig = Transition_Handler.GetComponent<Rig_Handler>().currentRig;
    }

    // Update is called once per frame
    void Update()
    {
        if (rig != Rig_Handler.currentRig)
        {
            rig = Rig_Handler.currentRig;
            timer = 0.0f;
        }

        float ang_speed = speedtracker.headAngSpeed.magnitude;
        if (ang_speed < threshold)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
        }
    }
}
