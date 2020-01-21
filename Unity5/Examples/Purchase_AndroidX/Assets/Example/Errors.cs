using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net.Mime;

public class Errors : MonoBehaviour {

    Text sometext;
    public Text futureOffers;
    public Text properties;

    public static string foOffersList;
	// Use this for initialization
	void Awake () {
        GowPageView.OnPageChangedEvent += OnPageChanged;
       
	}
	
	// Update is called once per frame
	void Update ()
	{
	    futureOffers.text = foOffersList;
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

    void OnPageChanged()
    {
        var props = GameOfWhales.GetProperties();
        properties.text = GameOfWhalesJson.MiniJSON.Serialize(props);
    }

    void OnFutureSpecialOfferAppeared(SpecialOffer offer)
    {
       
    }
}
