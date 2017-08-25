using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Errors : MonoBehaviour {

    Text sometext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ErrorMessage()
    {
        Debug.LogError("This is test error message");
    }

    public void NullPointerError()
    {
        sometext.text = "Error";
    }

    public void ZeroDevide()
    {
        int x = 0;
        int y = 5;
        x = y / x;
    }
}
