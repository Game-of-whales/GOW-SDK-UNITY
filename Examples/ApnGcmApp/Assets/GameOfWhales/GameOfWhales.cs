﻿using System.Collections.Generic;
using UnityEngine;
using JsonUtils = GameOfWhalesJson.MiniJSON;

#if UNITY_EDITOR
using GameOfWhalesType = GameOfWhalesEditor;
#elif UNITY_ANDROID
using GameOfWhalesType = GameOfWhalesAndroid;
#elif UNITY_IOS
using GameOfWhalesType = GameOfWhalesIOS;
#else 
using GameOfWhalesType = GameOfWhales;
#endif


public class GameOfWhales : MonoBehaviour {

    public const string VERSION = "2.0.6";

    private int maxErrorCount = 10;
    private int errorCount = 0;

    public const string PROVIDER_FCM = "fcm";
    public const string PROVIDER_GCM = "gcm";
    public const string PROVIDER_APN = "apn";

    public const string VERIFY_STATE_LEGAL = "legal";
    public const string VERIFY_STATE_ILLEGAL = "illegal";
    public const string VERIFY_STATE_UNDEFINED = "undefined";

    public delegate void OnSpecialOfferAppearedHandler(SpecialOffer offer);
    public delegate void OnSpecialOfferDisappearedHandler(SpecialOffer offer);

    public delegate void OnPurchaseVerifiedHandler(string transactionID, string state);
    public delegate void OnPushDeliveredHandler(string camp, string title, string message);

    public event OnPurchaseVerifiedHandler          OnPurchaseVerified = delegate{};
    public event OnPushDeliveredHandler             OnPushDelivered = delegate{};

    public event OnSpecialOfferAppearedHandler      OnSpecialOfferAppeared = delegate{};
    public event OnSpecialOfferDisappearedHandler   OnSpecialOfferedDisappeared = delegate{};

    private readonly Dictionary<string, SpecialOffer> activeOffers = new Dictionary<string, SpecialOffer>();

	protected GameOfWhales() {}

	protected virtual void Initialize() {}

    private void ErrMessage(string funcName)
    {
        Debug.Log ("[GameOfWhales] " + funcName + " is not supported on this platform");
    }
        
    public virtual void InAppPurchased(string sku, float price, string currency, string transactionID, string receipt) {
        ErrMessage("InAppPurchased");
	}

    public virtual void UpdateToken(string token, string provider)
    {
        ErrMessage("UpdateToken");
    }

    public virtual void PushReacted(string camp)
    {
        ErrMessage("PushReacted");
    }

    public virtual void Converting(IDictionary<string, int> resources, string place)
    {
        ErrMessage("Converting");
    }

    public virtual void Profile(IDictionary<string, object> parameters)
    {
        ErrMessage("Profile");
    }

    public virtual void Consume(string currency, int number, string sink, int amount, string place)
    {
        ErrMessage("Consume");
    }

    public virtual void Acquire(string currency, int amount, string source, int number, string place)
    {
        ErrMessage("Acquire");
    }

    public virtual void RegisterForNotifications()
    {
        ErrMessage("RegisterForNotifications");
    }

    public virtual void ReportError(string message, string stacktrace)
    {
        ErrMessage("ReportError");
    }

    public SpecialOffer GetSpecialOffer(string productID)
    {
        SpecialOffer offer;
        activeOffers.TryGetValue(productID, out offer);
        return offer;
    }

    //Private methods * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

    private void Internal_OnSpecialOfferAppeared(string json)
    {
        
        var data = JsonUtils.Deserialize(json) as Dictionary<string,object>;
        var offer = new SpecialOffer();
        offer.id = data["camp"] as string;
        offer.product = data["product"] as string;
        offer.countFactor = float.Parse(data["countFactor"].ToString());
        offer.priceFactor = float.Parse(data["priceFactor"].ToString());
        offer.finishedAt = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        offer.finishedAt =  offer.finishedAt.AddMilliseconds((long)data["finishedAt"]);
        offer.payload = data["payload"] as string;
        activeOffers.Add(offer.product, offer);
        OnSpecialOfferAppeared.Invoke(offer);
    }


    private void Internal_OnSpecialOfferDisappeared(string productID)
    {
        var offer = GetSpecialOffer(productID);
        if (offer == null)
        {
            Debug.LogError("GameOfWhales: Internal_OnSpecialOfferDisappeared: active offer not found");
            return;
        }
        activeOffers.Remove(productID);
        OnSpecialOfferedDisappeared(offer);
    }

    private void Internal_OnPushDelivered(string json)
    {
        var data = JsonUtils.Deserialize(json) as Dictionary<string,object>;
        var camp = ""; 
        if (data.ContainsKey("camp"))
        {
            camp = data["camp"] as string;
        }

        var title = data["title"] as string;
        var message = data["message"] as string;
        OnPushDelivered.Invoke(camp, title, message);
    }

    
    private void Internal_OnPurchaseVerified(string json)
    {
        var data = JsonUtils.Deserialize(json) as Dictionary<string,object>;
        var transactionID = data["transactionID"] as string;
        var verifyState = data["verifyState"] as string;
        OnPurchaseVerified.Invoke(transactionID, verifyState);
    }


    public static void Init()
    {
        GameOfWhales instance = GameOfWhales.Instance;
    }

    // Singleton
    private static GameOfWhalesType _instance;

    private static object _lock = new object();

    public static GameOfWhalesType Instance
    {
        get
        {
            if (applicationIsQuitting) {
                Debug.LogWarning("[Singleton] Instance '"+ typeof(GameOfWhalesType) +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }

            lock(_lock)
            {
                if (_instance == null)
                {
                    _instance = (GameOfWhalesType) FindObjectOfType(typeof(GameOfWhalesType));

                    if ( FindObjectsOfType(typeof(GameOfWhalesType)).Length > 1 )
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        singleton.name = "(singleton) "+ typeof(GameOfWhalesType).ToString();
                        _instance = singleton.AddComponent<GameOfWhalesType>();
                        _instance.Initialize ();

                        DontDestroyOnLoad(singleton);

                        Debug.Log("[Singleton] An instance of " + typeof(GameOfWhalesType) + 
                            " has been created with DontDestroyOnLoad.");
                    } else {
                        Debug.Log("[Singleton] Using instance already created: " +
                            _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }


    private static bool applicationIsQuitting = false;
    /// <summary>
    /// When Unity quits, it destroys objects in a random order.
    /// In principle, a Singleton is only destroyed when application quits.
    /// If any script calls Instance after it have been destroyed, 
    ///   it will create a buggy ghost object that will stay on the Editor scene
    ///   even after stopping playing the Application. Really bad!
    /// So, this was made to be sure we're not creating that buggy ghost object.
    /// </summary>
    public void OnDestroy () {
        applicationIsQuitting = true;
    }

    protected void ErrorsSubscribe()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void HandleLog(string message, string stacktrace, LogType type)
    {
        if (errorCount < maxErrorCount && type != LogType.Log)
        {
            errorCount++;
            ReportError(message, stacktrace);
        }
    }
}
