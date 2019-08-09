using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net.Mime;

public class TextText : MonoBehaviour
{
	public Text text;
	private DateTime finishedAt;
	// Use this for initialization
	void Start () {
		finishedAt = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		long tt = Convert.ToInt64("1544778606647");
		finishedAt = finishedAt.AddMilliseconds(tt);
		//finishedAt = finishedAt.AddMilliseconds((long) 1544778606647);

	}
	
	// Update is called once per frame
	void Update () {
		DateTime endTime = finishedAt;
		DateTime StartTime = GameOfWhales.GetServerTime();
		TimeSpan t = endTime - StartTime;
		
		string tt = t.TotalSeconds.ToString();

		tt += "\n ticks: " + (endTime.Ticks - StartTime.Ticks).ToString();
		text.text = tt;
	}
}
