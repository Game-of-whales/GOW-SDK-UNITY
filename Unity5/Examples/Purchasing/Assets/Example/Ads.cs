using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ads : MonoBehaviour {

    public Text adstate;
#if GAME_OF_WHALES
	// Use this for initialization
	void Start () {
        GameOfWhales.Instance.OnAdClosed += OnAdClosed;
        GameOfWhales.Instance.OnAdLoadFailed += OnAdLoadFailed;
        GameOfWhales.Instance.OnAdLoaded += OnAdLoaded;

        adstate.text = "hello";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadAd()
    {
        adstate.text = "ad loading";
        GameOfWhales.Instance.LoadAd();
    }


    public void ShowAd()
    {
		adstate.text = "ad showing";
		if (GameOfWhales.Instance.IsAdLoaded())
		{
			GameOfWhales.Instance.ShowAd();
		}
		else
		{
			adstate.text = "nothing to show, loading";
			GameOfWhales.Instance.LoadAd();
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
