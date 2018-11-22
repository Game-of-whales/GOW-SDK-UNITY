using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Errors : MonoBehaviour {

    Text sometext;
    public Text futureOffers;
    public Text properties;

	// Use this for initialization
	void Awake () {
        GowPageView.OnPageChangedEvent += OnPageChanged;
        GameOfWhales.Instance.OnFutureSpecialOfferAppeared += OnFutureSpecialOfferAppeared;


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

    void OnPageChanged()
    {
        var props = GameOfWhales.Instance.GetProperties();
        properties.text = GameOfWhalesJson.MiniJSON.Serialize(props);
    }

    void OnFutureSpecialOfferAppeared(SpecialOffer offer)
    {
        Debug.Log("UNITY: OnFutureSpecialOfferAppeared: " + offer.product);
        string timeText = offer.activatedAt.ToString("yyyy/MM/dd hh:mm:ss"); 
        futureOffers.text = futureOffers.text +  "\n: " + offer.product + " will activated at : " + timeText;
    }
}
