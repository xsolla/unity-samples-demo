using System;
using UnityEngine;
using UnityEngine.UI;
using Xsolla.Auth;
using Xsolla.Core;

public class AuthPage : MonoBehaviour
{
    // Declaration of variables for UI elements
    public Button SignInButton;

    // Declaration of static events
    public static event Action SignInSuccess;
    public static event Action<Error> SignInError;

    private void Start()
    {
        // Handling of SignInButton click event
        SignInButton.onClick.AddListener(() => XsollaAuth.AuthWithXsollaWidget(OnAuthSuccess, OnAuthError, OnAuthCancel));
    }

    private void OnAuthSuccess()
    {
        SignInSuccess?.Invoke();
    }

    private void OnAuthError(Error error)
    {
        SignInError?.Invoke(error);
    }

    private void OnAuthCancel()
    {
        Debug.Log("CANCEL");
    }
}