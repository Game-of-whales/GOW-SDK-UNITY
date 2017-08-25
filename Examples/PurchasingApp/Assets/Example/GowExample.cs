using System.Collections;
using System.Collections.Generic;

using JsonUtils = GameOfWhalesJson.MiniJSON;
using UnityEngine;


public class GowExample : MonoBehaviour {

    public Dialog dialog;


	void Start () {

        //GameOfWhales Initialization, must be called before any call of sdk
        GameOfWhales.Init();
        GameOfWhales.Instance.RegisterForNotifications();
        GameOfWhales.Instance.OnPushDelivered += OnPushDelivired;
	}



	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPushDelivired(string campID, string title, string message)
    {
        dialog.Show(title, message, campID);
    }
}
