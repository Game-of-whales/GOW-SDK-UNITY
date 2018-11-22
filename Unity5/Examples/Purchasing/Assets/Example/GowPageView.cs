using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GowPageView : MonoBehaviour {

    public GameObject[] pages;
    public delegate void OnPageChanged();
    public static OnPageChanged OnPageChangedEvent = delegate {};

    int index = 0;

	// Use this for initialization
	void Start () {
        updateVisibility();
	}
	
    public void nextPage()
    {
        if (index < pages.GetLength(0) - 1)
            index++;
        
        updateVisibility();
        OnPageChangedEvent();
    }

    public void prevPage()
    {
        if (index > 0)
            index--;
        
        updateVisibility();
        OnPageChangedEvent();
    }


    void updateVisibility()
    {
        int current = 0;
        foreach (GameObject o in pages)
        {
            o.SetActive(current == index);
            current++;
        }
    }
}
