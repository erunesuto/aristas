﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zdebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        Debug.Log("pulsado");
    }
}
