using System;
using UnityEngine;
using UnityEngine.UI;

namespace XsollaSamplesDemo
{
    public class AuthHubPage : MonoBehaviour
    {
        // Declaration of variables for UI elements
        public Button RegisterButton;
        public Button SignInButton;

        // Declaration of events
        public static event Action RegisterButtonClicked;
        public static event Action SignInButtonClicked;

        private void Start()
        {
            // Handling the Register button click
            RegisterButton.onClick.AddListener(() => {
                // Invoke the event
                RegisterButtonClicked?.Invoke();
            });

            // Handling the SignIn button click
            SignInButton.onClick.AddListener(() => {
                // Invoke the event
                SignInButtonClicked?.Invoke();
            });
        }
    }
}