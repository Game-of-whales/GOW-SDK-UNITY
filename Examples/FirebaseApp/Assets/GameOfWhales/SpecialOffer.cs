using System;


public class SpecialOffer {
    public string id;
    public string product;
    public float countFactor;
    public float priceFactor;
    public DateTime finishedAt;
    public string payload;
	
    public bool IsExpired()
    {
        return finishedAt.Ticks < System.DateTime.Now.Ticks;
    }

    public bool HasCountFactor()
    {
        return countFactor > 1.0;
    }

    public bool HasPriceFactor()
    {
        return priceFactor < 1.0;
    }

}
