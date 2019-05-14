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
    string [] subscriptions = {"sub_week_grace3_1", "sub_month_graceno_2"};
    public GowProduct[] productViews;
    public GowPlayerInfo player;


	void Start () {
        var module = StandardPurchasingModule.Instance();
        _configurationBuilder = ConfigurationBuilder.Instance(module);

        foreach(var p in products)
        {
            _configurationBuilder.AddProduct(p, ProductType.Consumable);
        }

        foreach(var s in subscriptions)
        {
            _configurationBuilder.AddProduct(s, ProductType.Subscription);
        }


#if false//AMAZON
        var gp = _configurationBuilder.Configure<IAmazonConfiguration>();
        gp.WriteSandboxJSON(_configurationBuilder.products);
#else
        var gp = _configurationBuilder.Configure<IGooglePlayConfiguration>();
#endif

        UnityPurchasing.Initialize(this, _configurationBuilder);
#if GAME_OF_WHALES
        GameOfWhales.OnPurchaseVerified += OnPurchaseVerified;
#endif

	}
	
    void OnPurchaseVerified(string transactionID, string state)
    {
        Debug.Log("GowStoreListener: OnPurchaseVerified state: " + state);
    }

    void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _store = controller;
        _storeExt = extensions;

#if GAME_OF_WHALES
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
#endif
        
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

		if (sku == null) {
			Debug.LogError ("Sku is null");
		} else {
			int index = System.Array.IndexOf(products, sku);
			if (index < 0)
			{
				index = products.Length + System.Array.IndexOf(subscriptions, sku);
			}

			GowProduct p = productViews[index];
			if (!p)
				return PurchaseProcessingResult.Pending;

			int coins = p.coins;

#if GAME_OF_WHALES
			SpecialOffer offer = GameOfWhales.GetSpecialOffer(sku);
			if (offer != null)
				coins = (int)(coins * offer.countFactor);

			player.incMoney(coins);

			GameOfWhales.InAppPurchased(
				e.purchasedProduct.definition.id,
				(float)e.purchasedProduct.metadata.localizedPrice,
				e.purchasedProduct.metadata.isoCurrencyCode,
				e.purchasedProduct.transactionID,
				e.purchasedProduct.receipt);

			GameOfWhales.Acquire("coins", coins, sku, 1, "bank");
#endif
		}

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
