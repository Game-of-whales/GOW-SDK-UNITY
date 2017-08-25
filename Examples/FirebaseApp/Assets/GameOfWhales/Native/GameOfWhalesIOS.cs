using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonUtils = GameOfWhalesJson.MiniJSON;


#if UNITY_IOS
    using NotificationServices = UnityEngine.iOS.NotificationServices;
    using NotificationType = UnityEngine.iOS.NotificationType;
#endif

public class GameOfWhalesIOS : GameOfWhales {
#if UNITY_IOS && !UNITY_EDITOR

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_initialize(string gameKey, string listener, string version, bool debug);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_pushReacted(string camp);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_inAppPurchased(string sku, float price, string currency, string transactionID, string receipt);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_updateToken(string token, string provider);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_profile(string changes);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_converting(string resources, string place);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_consume(string currency, int number, string sink, int amount, string place);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    extern static private void gw_acquire(string currency, int amount, string source, int number, string place);


    protected override void Initialize()
    {
        Debug.Log("GameOfWhalesIOS: Initialize");

        GameOfWhalesSettings settings = GameOfWhalesSettings.instance;

        gw_initialize(settings.gameID, this.gameObject.name, VERSION, settings.debugLogging);
    }

    public override void PushReacted(string camp)
    { 
        Debug.Log("GameOfWhalesIOS: PushReacted " + camp);
        gw_pushReacted(camp);
    }

    public override void InAppPurchased(string sku, float price, string currency, string transactionID, string receipt) 
    {
        Debug.Log("GameOfWhalesIOS: InAppPurchased ");
        gw_inAppPurchased(sku, price, currency, transactionID, receipt);
    }

    public override void UpdateToken(string token, string provider)
    {
        Debug.Log("GameOfWhalesIOS: UpdateToken " + token + "  " + provider);
        gw_updateToken(token, provider);
    }

    public override void Converting(IDictionary<string, int> resources, string place)
    {
        string paramsStr = JsonUtils.Serialize(resources);
        Debug.Log("GameOfWhalesIOS: Converting " + paramsStr);
        gw_converting(paramsStr, place);
    }

    public override void Profile(IDictionary<string, object> parameters)
    {
        string paramsStr = JsonUtils.Serialize(parameters);
        Debug.Log("GameOfWhalesIOS: Profile " + paramsStr);
        gw_profile(paramsStr);
    }

    public override void Consume(string currency, int number, string sink, int amount, string place)
    {
        Debug.Log("GameOfWhalesIOS: Consume ");
        gw_consume(currency, number, sink, amount, place);
    }

    public override void Acquire(string currency, int amount, string source, int number, string place)
    {
        Debug.Log("GameOfWhalesIOS: Acquire ");
        gw_acquire(currency, amount, source, number, place);
    }


    public override void RegisterForNotifications()
    {
        Debug.Log("GameOfWhalesIOS RegisterForNotifications");
        NotificationServices.RegisterForNotifications(
            NotificationType.Alert |
            NotificationType.Badge |
            NotificationType.Sound);
    }
#endif
}
