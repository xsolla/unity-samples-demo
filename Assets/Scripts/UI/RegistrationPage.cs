using System;
using UnityEngine;
using UnityEngine.UI;
using Xsolla.Auth;
using Xsolla.Core;

namespace XsollaSamplesDemo
{
    public class RegistrationPage : MonoBehaviour
    {
        // Declaration of variables for UI elements
        public InputField UsernameInput;
        public InputField EmailInputField;
        public InputField PasswordInputField;
        public Button RegisterButton;

        // Declaration of events
        public static event Action RegistrationSuccess;
        public static event Action<Error> RegistrationError;

        private void Start()
        {
            // Handling the Register button click
            RegisterButton.onClick.AddListener(() => {
                // Get the username, email and password from input fields
                var username = UsernameInput.text;
                var email = EmailInputField.text;
                var password = PasswordInputField.text;

                // Call the user registration method
                // Pass credentials and callback functions for success and error cases
                XsollaAuth.Register(username, password, email, OnSuccess, OnError);
            });
        }

        private void OnSuccess(LoginLink loginLink)
        {
            Debug.Log("Registration successful");

            // Add actions taken in case of success
            RegistrationSuccess?.Invoke();
        }

        private void OnError(Error error)
        {
            Debug.LogError($"Registration failed. Error: {error.errorMessage}");

            // Add actions taken in case of error
            RegistrationError?.Invoke(error);
        }
    }
}