using UnityEngine;
using UnityEngine.UI;

namespace XsollaSamplesDemo
{
    public class PurchasePopup : MonoBehaviour
    {
        // Declaration of variables for UI elements
        public Button BackButton;

        private void Start()
        {
            BackButton.onClick.AddListener(() => Destroy(gameObject));
        }
    }
}