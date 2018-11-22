using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialog : MonoBehaviour {


    public Text title;
    public Text message;
    public Text camp;

    string campID = "";
	// Use this for initialization
	void Start () {
		    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show(string title, string message, string camp)
    {
        gameObject.SetActive(true);
        this.title.text = "Title: " + title;
        this.message.text = "Message: " + message;
        this.camp.text = "Campaign ID: " + camp;
        campID = camp;
    }

    public void Hide()
    {
        gameObject.SetActive(false); 
    }

#if GAME_OF_WHALES
    public void OnClickOK()
    {
        GameOfWhales.Instance.PushReacted(campID);
        campID = "";
        Hide();
    }
#endif
}
