using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Example : MonoBehaviour {

    public Text title_text;
    public Text message_text;
    public Text campID_text;

	void Start () 
    {
#if UNITY_IOS
        string store = GameOfWhales.STORE_APPLEAPPSTORE;
#else
        string store = GameOfWhales.STORE_GOOGLEPLAY;
#endif

        GameOfWhales.Init(store);
        GameOfWhales.Instance.RegisterForNotifications();

        GameOfWhales.Instance.OnPushDelivered += OnPush;
    }

    private void OnPush(SpecialOffer offer, string camp, string title, string message)
    {
        Clear();

        title_text.text  = title_text.text + title;
        message_text.text = message_text.text + message;
        campID_text.text = campID_text.text + camp;

        GameOfWhales.Instance.PushReacted(camp);
    }

    public void Clear()
    {
        title_text.text = "Title:  ";
        message_text.text = "Message:  ";
        campID_text.text = "Camp ID:  ";
    }

}
