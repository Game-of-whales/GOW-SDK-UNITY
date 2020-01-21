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

#if GAME_OF_WHALES
    public void Start()
    {

        GameOfWhales.OnSpecialOfferAppeared += OnOfferAppeared;
        GameOfWhales.OnSpecialOfferedDisappeared += OnOfferDisappeared;
    }

    public void update(string priceStr, string title)
    {

        text.text = title + "\n" + priceStr;
    }

    void Update () {
        SpecialOffer offer = GameOfWhales.GetSpecialOffer(id);

        if (offer != null && offer.HasCountFactor())
        {
            int add = (int)((float)(coins) * offer.countFactor) - coins;
            int percent = (int)((offer.countFactor - 1.0) * 100.0);

			Debug.Log ("Offer: " + offer.id);
			Debug.Log ("Offer finished at: " + offer.finishedAt);
            DateTime now = DateTime.UtcNow;
			Debug.Log ("Now: " + now);
            TimeSpan left = offer.finishedAt.Subtract(now);
			Debug.Log ("Left: " + left);
            string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", left.Hours, left.Minutes, left.Seconds);
			Debug.Log ("TimeText: " + timeText);
			string custom = "";

			foreach(KeyValuePair<string, object> entry in offer.customValues)
			{
				custom += "\n(" + entry.Key + ":" + entry.Value + ")";
			}

			custom += "Redeemable: " + offer.redeemable;

			coinsText.text = coins + " + " + add + " ( " + percent + "% Bonus! ) \nTime Left: " + timeText + "\n" + custom;
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
#endif
}
