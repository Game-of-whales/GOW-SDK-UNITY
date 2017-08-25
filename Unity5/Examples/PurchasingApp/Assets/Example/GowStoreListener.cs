using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Purchasing;

public class ProductData
{
    public GameObject view;
    public string sku;
}

public class GowStoreListener : MonoBehaviour, IStoreListener{

    private ConfigurationBuilder _configurationBuilder;
    private IStoreController _store;
    private IExtensionProvider _storeExt;

    string[] products = {"product_5", "product_10", "product_20"};
    public GowProduct[] productViews;
    public GowPlayerInfo player;

	void Start () {
        var module = StandardPurchasingModule.Instance();
        _configurationBuilder = ConfigurationBuilder.Instance(module);

        foreach(var p in products)
        {
            _configurationBuilder.products.Add(new ProductDefinition(p, ProductType.Consumable));
        }

        var gp = _configurationBuilder.Configure<IGooglePlayConfiguration>();
        UnityPurchasing.Initialize(this, _configurationBuilder);

        GameOfWhales.Instance.OnPurchaseVerified += OnPurchaseVerified;
	}
	
    void OnPurchaseVerified(string transactionID, string state)
    {
        Debug.Log("GowStoreListener: OnPurchaseVerified state: " + state);
    }

    void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _store = controller;
        _storeExt = extensions;

        var appleExt = _storeExt.GetExtension<IAppleExtensions>();
        appleExt.RegisterPurchaseDeferredListener(OnDeferred);

        int i = 0;
        foreach(var p in products)
        {
            GowProduct view = productViews[i];
            var product = _store.products.WithID(p);
            view.update(product.metadata.localizedPriceString, product.metadata.localizedTitle);
            i++;
        }
    }

    private void OnDeferred(Product item) {
        Debug.Log("Purchase deferred: " + item.definition.id);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("OnInitializeFailed:"+error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogError("OnPurchaseFailed:"+product);
    }

    PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs e)
    {
        string sku = e.purchasedProduct.definition.id;
        int index = System.Array.IndexOf(products, sku);
        GowProduct p = productViews[index];
        if (!p)
            return PurchaseProcessingResult.Pending;

        int coins = p.coins;

        SpecialOffer offer = GameOfWhales.Instance.GetSpecialOffer(sku);
        if (offer != null)
            coins = (int)(coins * offer.countFactor);
        
        player.incMoney(coins);

        GameOfWhales.Instance.InAppPurchased(
            e.purchasedProduct.definition.id,
            (float)e.purchasedProduct.metadata.localizedPrice,
            e.purchasedProduct.metadata.isoCurrencyCode,
            e.purchasedProduct.transactionID,
            e.purchasedProduct.receipt);

        GameOfWhales.Instance.Acquire("coins", coins, sku, 1, "bank");


        return PurchaseProcessingResult.Complete;
    }

    public void Buy(string productId) {

        var product = _store.products.WithID(productId);
        _store.InitiatePurchase(product);
    }

	// Update is called once per frame
	void Update () {
		
	}

   
}
