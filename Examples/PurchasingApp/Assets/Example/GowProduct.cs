using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GowProduct : MonoBehaviour {

    public Text text;
    public Text coinsText;
    public int coins;
    public string id;

    public void Start()
    {
        GameOfWhales.Instance.OnSpecialOfferAppeared += OnOfferAppeared;
        GameOfWhales.Instance.OnSpecialOfferedDisappeared += OnOfferDisappeared;
    }

    public void update(string priceStr, string title)
    {
        text.text = title + "\n" + priceStr;
    }

    void Update () {
        SpecialOffer offer = GameOfWhales.Instance.GetSpecialOffer(id);

        if (offer != null && offer.HasCountFactor())
        {
            int add = (int)((float)(coins) * offer.countFactor) - coins;
            int percent = (int)((offer.countFactor - 1.0) * 100.0);


            DateTime now = DateTime.UtcNow;
            TimeSpan left = offer.finishedAt.Subtract(now);
            string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", left.Hours, left.Minutes, left.Seconds);
            coinsText.text = coins + " + " + add + " ( " + percent + "% Bonus! ) \nTime Left: " + timeText;
        }
        else
        {
            coinsText.text = "" +  coins;
        }

    }

    public void OnOfferDisappeared(SpecialOffer offer)
    {
        Debug.Log("GowProduct[" + id +"]: Special offer disapperared: " + offer.id);
    }

    public void OnOfferAppeared(SpecialOffer offer)
    {
        Debug.Log("GowProduct[" + id +"]: Special offer apperared: " + offer.id);
    }
}
