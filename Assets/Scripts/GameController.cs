using UnityEngine;
using Xsolla.Core;

namespace XsollaSamplesDemo
{
    public class GameController : MonoBehaviour
    {
        // Declaration of variables prefabs for UI pages
        public Transform PageContainer;
        public ErrorPopup ErrorPopupPrefab;
        public PurchasePopup PurchasePopupPrefab;
        public AuthHubPage AuthHubPagePrefab;
        public RegistrationPage RegistrationPagePrefab;
        public SignInPage SignInPagePrefab;
        public VirtualItemsPage VirtualItemsPagePrefab;

        // Current opened page
        private MonoBehaviour CurrentPage;

        private void Start()
        {
            // Registering the event handlers for error cases
            RegistrationPage.RegistrationError += ShowErrorPopup;
            SignInPage.SignInError += ShowErrorPopup;
            VirtualItemsPage.ItemsRequestError += ShowErrorPopup;

            // Registering the event handlers
            AuthHubPage.RegisterButtonClicked += () => TogglePage(RegistrationPagePrefab);
            AuthHubPage.SignInButtonClicked += () => TogglePage(SignInPagePrefab);
            RegistrationPage.RegistrationSuccess += () => TogglePage(SignInPagePrefab);
            SignInPage.SignInSuccess += () => TogglePage(VirtualItemsPagePrefab);
            VirtualItemsPage.PurchaseSuccess += ShowPurchasePopup;

            // Opening the AuthHub page
            TogglePage(AuthHubPagePrefab);
        }

        private void TogglePage<TPage>(TPage prefab) where TPage : MonoBehaviour
        {
            // Destroying the current page if it exists
            if (CurrentPage != null)
                Destroy(CurrentPage.gameObject);

            // Instantiating the new page
            CurrentPage = Instantiate(prefab, PageContainer, false);
        }

        private void ShowErrorPopup(Error error)
        {
            // Instantiating the error popup and setting the error message
            Instantiate(ErrorPopupPrefab, PageContainer, false).ErrorMessageText.text = error.errorMessage;
        }

        private void ShowPurchasePopup(OrderStatus orderStatus)
        {
            // Instantiating the purchase popup
            Instantiate(PurchasePopupPrefab, PageContainer, false);
        }
    }
}