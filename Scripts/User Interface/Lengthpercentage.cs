﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lengthpercentage : MonoBehaviour
{

    Text percentageText;


    // Use this for initialization
    void Start()
    {
        percentageText = GetComponent<Text>();

    }

    public void textUpdate(float value)
    {
        percentageText.text = Mathf.RoundToInt(value) + "%";

    }
}

	
