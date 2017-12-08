using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Example : MonoBehaviour {

    public Text title;
    public Text messsage;
    public Text campaignID;

    void Awake()
    {
#if UNITY_IOS
        string store = GameOfWhales.STORE_APPLEAPPSTORE;
#else
        string store = GameOfWhales.STORE_GOOGLEPLAY;
#endif

        GameOfWhales.Init(store);
    }

	// Use this for initialization
	void Start () {
        Debug.Log("FirebaseExample: Firebase Messaging Initializing");
        Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
        GameOfWhales.Instance.OnPushDelivered += OnMessageReceived;
        Firebase.Messaging.FirebaseMessaging.Subscribe("all");
	}
	
    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) {
        Debug.Log("FirebaseExample: Received Registration Token: " + token.Token);
        GameOfWhales.Instance.UpdateToken(token.Token, GameOfWhales.PROVIDER_FCM);
    }

    public void Clear()
    {
        this.title.text = "Title: ";
        this.messsage.text = "Message: ";
        this.campaignID.text = "Campaign: ";
    }

    public void OnMessageReceived(SpecialOffer offer, string campID, string title, string message)
    {
        Clear();
        this.title.text = this.title.text + title;
        this.messsage.text = this.messsage.text + message;
        this.campaignID.text = this.campaignID.text + campID;

        GameOfWhales.Instance.PushReacted(campID);
    }
}
