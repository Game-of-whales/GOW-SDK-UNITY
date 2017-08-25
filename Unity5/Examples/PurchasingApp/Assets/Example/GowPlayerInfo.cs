using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;



public class GowPlayerInfo : MonoBehaviour {

    public Text coinsText;
    public Text classText;
    public Text genderText;

    public Text levelupText;
    public Text nextlocationText;

    public Text buyItem1Text;
    public Text buyItem2Text;

    int coins = 1000;
    string userClass = "";
    bool gender = false;
    int level = 1;
    int locationCode = 0;
    char location = 'A';

    void Awake()
    {
        string[] classes = {"Warrior", "Wizard", "Rogue"};

        userClass = classes[UnityEngine.Random.Range(0, 2)];
        gender = UnityEngine.Random.Range(0, 1) == 1;

        load();
        save();
        updateViews();

        GameOfWhales.Instance.Converting(new Dictionary<string, int> {
            {"coins", -1000},
            {"gas", -50},
            {"bike_1", 1}
        }, "level_1");
    }

    public void load()
    {
        coins = PlayerPrefs.GetInt("gow_coins", coins);
        gender = PlayerPrefs.GetInt("gow_gender", (gender ? 1 : 0)) == 1 ? true : false;
        userClass = PlayerPrefs.GetString("gow_class", userClass);
        locationCode = PlayerPrefs.GetInt("gow_location", locationCode);
        level = PlayerPrefs.GetInt("gow_level", level);

        updateLocation();
    }

    public void save()
    {
        PlayerPrefs.SetInt("gow_coins", coins);
        PlayerPrefs.SetString("gow_class", userClass);
        PlayerPrefs.SetInt("gow_location", locationCode);
        PlayerPrefs.SetInt("gow_gender", gender ? 1 : 0);
        PlayerPrefs.SetInt("gow_level", level);
    }

    void updateLocation()
    {
        location = (char)((int)('A') + locationCode);
    }

    public static int GetItemCost(string itemID)
    {
        if (itemID == "item1")
        {
            return 1000;
        }

        if (itemID == "item2")
        {
            return 2000;
        }


        return 1;
    }

    public void nextLocation()
    {
        locationCode++;
        if (locationCode == 32)
            locationCode = 0;
        save();
        updateLocation();
        updateViews();
    }

    public void levelUp()
    {
        level ++;
        save();
        updateViews();
    }

    public bool canBuy(int cost)
    {
        return cost <= coins;
    }

    public void decMoney(int value)
    {
        coins -= value;
        save();
        updateViews();
    }

    void buy(string id)
    {
        int cost = GetItemCost(id);

        SpecialOffer offer = GameOfWhales.Instance.GetSpecialOffer(id);
        if (offer != null)
            cost = (int)(cost * offer.priceFactor);

        if (canBuy(cost))
        {
            decMoney(cost);
            GameOfWhales.Instance.Consume("coins", cost, id, 1, "shop");
        }
    }

    public void buyItem1()
    {
        buy("item1");
    }

    public void buyItem2()
    {
        buy("item2");
    }

    public void incMoney(int value)
    {
        coins += value;
        save();
        updateViews();
    }

    void updateViews()
    {
        GameOfWhales.Instance.Profile(new Dictionary<string, object> {
            {"coins", coins},
            {"class", userClass},
            {"gender", gender},
            {"location", location},
            {"level", level}
        });


        coinsText.text = "Coins: " + coins;
        classText.text = "Class: " + userClass;
        genderText.text = "Gender: " + (gender ? "Man" : "Woman");

        levelupText.text = "LEVEL UP ( " + level + " )";
        nextlocationText.text = "NEXT LOCATION ( " + location + " )";
    }

	// Use this for initialization
	void Start () {
        updateViews();
	}
	
    public void OnCrashButton()
    {
        int x = 0;
        int y = 10;
        x = y / x;
    }
	
    void updateBuyButtonText(Text textObject, string itemID)
    {
        int cost = GetItemCost(itemID);
        string text = itemID;
        SpecialOffer offer = GameOfWhales.Instance.GetSpecialOffer(itemID);
        bool userOffer = offer != null && offer.HasPriceFactor();
        if (userOffer)
        {
            cost = (int)(cost * offer.priceFactor);
        }
        text = text + " Cost: " + cost;

        if (userOffer)
        {
            text = text + " ( " + (int)(offer.priceFactor * 100.0) + "% Discount )";
        }

        if (userOffer)
        {
            DateTime now = DateTime.UtcNow;
            TimeSpan left = offer.finishedAt.Subtract(now);
            string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", left.Hours, left.Minutes, left.Seconds);
            text = text + "\nTime Left: " + timeText;
        }
        textObject.text = text;
    }

	void Update () {
        updateBuyButtonText(buyItem1Text, "item1");
        updateBuyButtonText(buyItem2Text, "item2");
	}
}
