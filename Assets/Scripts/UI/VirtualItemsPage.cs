using System;
using UnityEngine;
using Xsolla.Catalog;
using Xsolla.Core;
using Xsolla.Samples.SellForRealMoney;

namespace XsollaSamplesDemo
{
    public class VirtualItemsPage : MonoBehaviour
    {
        // Declaration of variables for widget's container and prefab
        public Transform WidgetsContainer;
        public VirtualItemWidget WidgetPrefab;
        public GameObject Spinner;

        // Declaration of events
        public static event Action<OrderStatus> PurchaseSuccess;
        public static event Action<Error> ItemsRequestError;

        private void Start()
        {
            // Enabling the spinner while the authentication process is running
            Spinner.SetActive(true);

            // Starting the items request from the store after successful authentication
            // Pass the callback functions for success and error cases
            XsollaCatalog.GetCatalog(OnItemsRequestSuccess, OnError);
        }

        private void OnItemsRequestSuccess(StoreItems storeItems)
        {
            // Disabling the spinner after the items request is completed
            Spinner.SetActive(false);

            // Iterating the items collection
            foreach (var storeItem in storeItems.items)
            {
                // Skipping items without prices in real money
                if (storeItem.price == null)
                    continue;

                // Instantiating the widget prefab as child of the container
                var widget = Instantiate(WidgetPrefab, WidgetsContainer, false);

                // Assigning the values for UI elements
                widget.NameText.text = storeItem.name;
                widget.DescriptionText.text = storeItem.description;

                // Assigning the price and currency values for UI elements
                var price = storeItem.price;
                widget.PriceText.text = $"{price.amount} {price.currency}";

                // Loading the item image and assigning it to the UI element
                ImageLoader.LoadSprite(storeItem.image_url, sprite => widget.IconImage.sprite = sprite);

                // Assigning the click listener for the buy button
                widget.BuyButton.onClick.AddListener(() => {
                    // Starting the purchase process
                    // Pass the item SKU and callback functions for success and error cases
                    XsollaCatalog.Purchase(storeItem.sku, OnPurchaseSuccess, OnError);
                });
            }
        }

        private void OnPurchaseSuccess(OrderStatus status)
        {
            Debug.Log("Purchase successful");

            // Add actions taken in case of success
            PurchaseSuccess?.Invoke(status);
        }

        private void OnError(Error error)
        {
            Debug.LogError($"Error: {error.errorMessage}");

            // Add actions taken in case of error
            ItemsRequestError?.Invoke(error);
        }
    }
}