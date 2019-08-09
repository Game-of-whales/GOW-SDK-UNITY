using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastView : MonoBehaviour
{
    
    
    private static AndroidJavaObject gameofwhales = null;
    
    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    using(var pluginClass = new AndroidJavaClass("com.gameofwhales.unityplugin.GameOfWhalesProxy"))
    {
        gameofwhales = pluginClass.CallStatic<AndroidJavaObject>("instance");
    }
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInitRequestClicked()
    {
        gameofwhales.Call("test_BroadcastInitRequest");
    }

    public void OnUserRequestClicked()
    {
        gameofwhales.Call("test_BroadcastUserStatusRequest");
    }


    public void OnAdShowRequestClicked()
    {
        gameofwhales.Call("test_BroadcastShowAdRequest");
    }
}
