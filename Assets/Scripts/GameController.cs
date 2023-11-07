using UnityEngine;
using Xsolla.Core;

public class GameController : MonoBehaviour
{
    // Declaration of variables prefabs for UI pages
    public Transform PageContainer;
    public AuthPage AuthPagePrefab;
    public CatalogPage CatalogPagePrefab;
    public PopupPage PopupPagePrefab;

    // Current opened page
    private MonoBehaviour CurrentPage;

    private void Start()
    {
        // Subscribing to sign in events
        AuthPage.SignInSuccess += () => TogglePage(CatalogPagePrefab);
        AuthPage.SignInError += ShowErrorMessage;

        // Subscribing to virtual items events
        CatalogPage.PurchaseSuccess += ShowPurchaseSuccessMessage;
        CatalogPage.ItemsRequestError += ShowErrorMessage;

        // Opening the SignIn page
        TogglePage(AuthPagePrefab);
    }

    private void TogglePage<TPage>(TPage prefab) where TPage : MonoBehaviour
    {
        // Destroying the current page if it exists
        if (CurrentPage != null)
            Destroy(CurrentPage.gameObject);

        // Instantiating the new page
        CurrentPage = Instantiate(prefab, PageContainer, false);
    }

    private void ShowErrorMessage(Error error)
    {
        // Instantiating the error popup and setting the error message 
        var page = Instantiate(PopupPagePrefab, PageContainer, false);
        page.TitleText.text = "Error";
        page.MessageText.text = error.errorMessage;
    }

    private void ShowPurchaseSuccessMessage(OrderStatus orderStatus)
    {
        // Instantiating the success popup and setting the info message
        var page = Instantiate(PopupPagePrefab, PageContainer, false);
        page.TitleText.text = "Success";
        page.MessageText.text = "Purchase completed successfully";
    }
}