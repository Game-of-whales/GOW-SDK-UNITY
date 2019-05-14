using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ads : MonoBehaviour {

    public Text adstate;
#if GAME_OF_WHALES
	// Use this for initialization
	void Start () {
        GameOfWhales.OnAdClosed += OnAdClosed;
        GameOfWhales.OnAdLoadFailed += OnAdLoadFailed;
        GameOfWhales.OnAdLoaded += OnAdLoaded;

        adstate.text = "hello";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadAd()
    {
        adstate.text = "ad loading";
        GameOfWhales.LoadAd();
    }


    public void ShowAd()
    {
		adstate.text = "ad showing";
		if (GameOfWhales.IsAdLoaded())
		{
			GameOfWhales.ShowAd();
		}
		else
		{
			adstate.text = "nothing to show, loading";
			GameOfWhales.LoadAd();
		}
    }

    private void OnAdLoadFailed()
    {
        adstate.text = "ad load failed";
    }

    private void OnAdClosed()
    {
        adstate.text = "ad closed";
    }

    private void OnAdLoaded()
    {
        adstate.text = "ad loaded";
    }
#endif
}
