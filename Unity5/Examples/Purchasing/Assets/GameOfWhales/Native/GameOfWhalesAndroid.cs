﻿/*
 * Game Of Whales SDK
 *
 * https://www.gameofwhales.com/
 * 
 * Copyright © 2018 GameOfWhales. All rights reserved.
 *
 * Licence: https://github.com/Game-of-whales/GOW-SDK-UNITY/blob/master/LICENSE
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonUtils = GameOfWhalesJson.MiniJSON;

public class GameOfWhalesAndroid : GameOfWhales{
#if UNITY_ANDROID && !UNITY_EDITOR
	private static AndroidJavaObject gameofwhales = null;

	protected override void Initialize()
	{
        try
        {
            if (gameofwhales != null)
                return;
            
            Debug.Log("GameOfWhalesAndroid: Initialize");
    		Debug.Log("GameOfWhalesAndroid: Store: " + GameOfWhales.store);

            
            GameOfWhalesSettings settings = GameOfWhalesSettings.instance;
            

            using(var pluginClass = new AndroidJavaClass("com.gameofwhales.unityplugin.GameOfWhalesProxy"))
    			{
    				gameofwhales = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    pluginClass.CallStatic("initialize", settings.gameID, GameOfWhales.store, settings.androidProjectID, this.gameObject.name, VERSION, settings.debugLogging);
    			}
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
	}

    bool checkInstance(string from)
    {
        try
        {
            if (gameofwhales == null)
            {
                Debug.LogError("GameOfWhalesAndroid instance is null ( " + from + ")");
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
        return false;
    }

    public override void PushReacted(string camp)
    {   
        try
        {
            if (checkInstance("PushReacted"))
            {
                gameofwhales.Call("pushReacted", camp);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }



    public override void InAppPurchased(string sku, double price, string currency, string transactionID, string receipt) 
    {
        try
        {
            if (checkInstance("InAppPurchased"))
            {
                gameofwhales.Call("inAppPurchased", sku, price.ToString("#.00"), currency, transactionID, receipt);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void UpdateToken(string token, string provider)
    {
        try
        {
            if (checkInstance("UpdateToken"))
            {
                gameofwhales.Call("updateToken", token, provider);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void Converting(IDictionary<string, long> resources, string place)
    {
        try
        {
            if (checkInstance("Converting"))
            {
                gameofwhales.Call("converting", JsonUtils.Serialize(resources), place);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void Profile(IDictionary<string, object> parameters)
    {
        try
        {
            if (checkInstance("Profile"))
            {
                gameofwhales.Call("profile", JsonUtils.Serialize(parameters));
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void Consume(string currency, long number, string sink, long amount, string place)
    {
        try
        {
            Debug.Log("Consume");
            if (checkInstance("Consume"))
            {
                gameofwhales.Call("consume", currency, number, sink, amount, place);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void Acquire(string currency, long amount, string source, long number, string place)
    {
        try
        {
            if (checkInstance("Acquire"))
            {
                gameofwhales.Call("acquire", currency, amount, source, number, place);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void ReportError(string message, string stacktrace)
    {
        try
        {
            if (checkInstance("ReportError"))
            {
                gameofwhales.Call("reportError", message, stacktrace);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void SetPushNotificationsEnable(bool value)
    {
        try
        {
            if (checkInstance("SetPushNotificationsEnable"))
            {
                gameofwhales.Call("setPushNotificationsEnable", value ? "true" : "false");
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void RegisterForNotifications()
    {

    }

    public override void ShowAd()
    {
        try
        {
            if (checkInstance("ShowAd"))
            {
                gameofwhales.Call("showAd");
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override bool IsAdLoaded()
    {
        try
        {
            if (checkInstance("IsAdLoaded"))
            {
                return gameofwhales.Call<Boolean>("isAdLoaded");
            }

            return false;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public override void LoadAd()
    {
        try
        {
            if (checkInstance("LoadAd"))
                {
                    gameofwhales.Call("loadAd");
                }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

	public override System.DateTime GetServerTime()
	{
        try
        {
    		if (checkInstance("GetServerTime"))
    		{
    			string st_str = gameofwhales.Call<string>("getServerTime");
    			System.DateTime dt = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
    			long tt = Convert.ToInt64(st_str);
    			return dt.AddMilliseconds( tt);
    		}

    		return System.DateTime.UtcNow;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }

        return System.DateTime.UtcNow;
	}

    public override Dictionary<string, object> GetProperties()
    {
        try
        {
            if (checkInstance("GetProperties"))
            {
                string json_string_properties = gameofwhales.Call<string>("getProperties");
                var data = JsonUtils.Deserialize(json_string_properties) as Dictionary<string, object>;
                return data;
            }

            return _emptyProperties;
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }

        return _emptyProperties;
    }
    //
#endif
}