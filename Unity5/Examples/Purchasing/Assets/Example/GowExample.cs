using System.Collections;
using System.Collections.Generic;

#if GAME_OF_WHALES
using JsonUtils = GameOfWhalesJson.MiniJSON;
#endif
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GowExample : MonoBehaviour {

    public Dialog dialog;
    bool notifications = true;
    public Text notificationsButtonText;
	public Text serverTimeText;

#if GAME_OF_WHALES
	void Awake () {

        //GameOfWhales Initialization, must be called before any call of sdk

		GameOfWhales.Init(GameOfWhales.GetCurrentStore());
        GameOfWhales.RegisterForNotifications();
        GameOfWhales.OnPushDelivered += OnPushDelivired;

        ///Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
	}

	void Update () {
		serverTimeText.text = GameOfWhales.GetServerTime().ToString();
	}

    void OnPushDelivired(SpecialOffer offer, string campID, string title, string message)
    {
        dialog.Show(title, message, campID);
    }

    public void NotificationsEnableClicked()
    {
        notifications = !notifications;
        GameOfWhales.SetPushNotificationsEnable(notifications);

        if (notifications)
        {
            notificationsButtonText.text = "Notifications [ON]";
        }
        else
        {
            notificationsButtonText.text = "Notifications [OFF]";
        }
    }

	private static System.Random random = new System.Random();
	public static string RandomString(int length)
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
	}

	public void Test()
	{
	  {
			string currency = RandomString (10);
			string place = RandomString (10);
			string product = RandomString (10);
			GameOfWhales.Consume (currency, (long)(1), product, 1, place);
			GameOfWhales.Acquire (currency, (long)(1), product, 1, place);
		}
	}
#endif
}
