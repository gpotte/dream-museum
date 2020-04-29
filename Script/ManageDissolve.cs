using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class ManageDissolve : MonoBehaviour
{
    float goal;
    float laps;
    bool ISTreshHold;
    Material material;
    float duration;
    float startTime;
    float startValue;

    // Start is called before the first frame update
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        laps = -1;

        if (Random.value >= 0.5)
            ISTreshHold = true;
        else
            ISTreshHold = false;

        if (ISTreshHold) {
            float TreshholdValue = Random.Range(0.01f, 0.8f);
            material.SetFloat("Vector1_D29E8A07", TreshholdValue);
        } else
        {
            float ScaleValue = Random.Range(-50f, 50f);
            material.SetFloat("Vector1_A5AAA8A3", ScaleValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ISTreshHold)
        {
            if (laps < 0) {
                goal = Random.Range(0.01f, 0.8f);
                laps = Random.Range(5f, 15f);
                duration = laps;
                startTime = Time.time;
                startValue = material.GetFloat("Vector1_D29E8A07");
            }
            float t = (Time.time - startTime) / duration;
            float currentMove = Mathf.SmoothStep(startValue, goal, t);
            material.SetFloat("Vector1_D29E8A07", currentMove);
        }
        else
        {
            if (laps < 0)
            {
                goal = Random.Range(1, 50);
                laps = Random.Range(3f, 10f);
                duration = laps;
                startTime = Time.time;
                startValue = material.GetFloat("Vector1_A5AAA8A3");
            }
            float t = (Time.time - startTime) / duration;
            float currentMove = Mathf.SmoothStep(startValue, goal, t);
            material.SetFloat("Vector1_A5AAA8A3", currentMove);
            
        }
        laps -= Time.deltaTime;
    }
}
/*
SCALE Vector1_A5AAA8A3
TRESHHOLD Vector1_d29e8a07*/