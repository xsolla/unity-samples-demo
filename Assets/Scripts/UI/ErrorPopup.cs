using UnityEngine;
using UnityEngine.UI;

namespace XsollaSamplesDemo
{
    public class ErrorPopup : MonoBehaviour
    {
        // Declaration of variables for UI elements
        public Text ErrorMessageText;
        public Button BackButton;

        private void Start()
        {
            BackButton.onClick.AddListener(() => Destroy(gameObject));
        }
    }
}