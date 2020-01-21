using System.Collections;
using System.Collections.Generic;

#if GAME_OF_WHALES
using System.Threading;
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
	public Text appearedOffersList;
	public Text disappearedOffersList;
	public Text _initializedLabel;

	private bool isExperimentStarted = false;
	[SerializeField] private Text _experimentText;
	
#if GAME_OF_WHALES
	void Awake () {
		
		GameOfWhales.OnSpecialOfferAppeared += OnSpecialOfferAppeared;
		GameOfWhales.OnSpecialOfferedDisappeared += OnSpecialOfferDisappeared;
		GameOfWhales.OnPushDelivered += OnPushDelivired;
		GameOfWhales.OnFutureSpecialOfferAppeared += OnFutureSpecialOfferAppeared;
		GameOfWhales.OnInitialized += OnGameOfWhalesInitialized;
		GameOfWhales.SetStartExperimentDelegate(CanStartExperiment);
		GameOfWhales.OnExperimentEnded += OnExperimentEnded;
        //GameOfWhales Initialization, must be called before any call of sdk
#if UNITY_ANDROID
		GameOfWhales.Init(GameOfWhales.STORE_GOOGLEPLAY);
#elif UNITY_IOS
		GameOfWhales.Init(GameOfWhales.STORE_APPLEAPPSTORE);
#else
		UNKNOWN
#endif

		GameOfWhales.RegisterForNotifications();

		
        ///Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
	}

	private void OnExperimentEnded(Experiment experiment)
	{
		_experimentText.text = "ENDED: \n\n" + experiment.id;
	}

	public bool CanStartExperiment(Experiment experiment)
	{
		if (experiment.payload != null && experiment.payload.Length > 2)
		{
			var payload = GameOfWhalesJson.MiniJSON.Deserialize(experiment.payload)  as Dictionary<string, object>;

			if (payload != null && payload.ContainsKey("ignore"))
			{
				bool ignore = (bool)payload["ignore"];
				if (ignore)
				{
					_experimentText.text = "IGNORED: \n\n" + experiment.id;
					return false;
				}
			}
		}

		_experimentText.text = "STARTED: \n\n" + experiment.id;
		isExperimentStarted = true;
		return true;
	}
	
	
	
	private void OnGameOfWhalesInitialized()
	{
		_initializedLabel.text = "OnInitialized";

		if (!isExperimentStarted)
		{
			var experiment = GameOfWhales.GetCurrentExperiment();

			if (experiment != null)
			{
				_experimentText.text = "ACTIVE: \n\n" + experiment.id;
			}
		}
	}

	private void OnFutureSpecialOfferAppeared(SpecialOffer offer)
	{
		Debug.Log("UNITY: OnFutureSpecialOfferAppeared: " + offer.product);
		string timeText = offer.activatedAt.ToString("yyyy/MM/dd hh:mm:ss"); 
		Errors.foOffersList = Errors.foOffersList +  "\n: " + offer.product + " will activated at : " + timeText;
	}

	void Update () {
		serverTimeText.text = GameOfWhales.GetServerTime().ToString();
	}

    void OnPushDelivired(SpecialOffer offer, string campID, string title, string message)
    {
        dialog.Show(title, message, campID);
    }

	public void OnSpecialOfferAppeared(SpecialOffer offer)
	{
		string addtext = "";
		if (offer == null)
		{
			addtext = "Error: null offer";
		}
		else
		{
			addtext = offer.product + "price: " + offer.priceFactor + "  count: " + offer.countFactor;
		}
		

		appearedOffersList.text += "\n" + addtext;
	}
	
	public void OnSpecialOfferDisappeared(SpecialOffer offer)
	{
		string addtext = "";
		if (offer == null)
		{
			addtext = "Error: null offer";
		}
		else
		{
			addtext = offer.product + "  price: " + offer.priceFactor + "  count: " + offer.countFactor;
		}
		

		disappearedOffersList.text += "\n" + addtext;
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
