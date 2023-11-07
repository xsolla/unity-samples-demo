using UnityEngine;
using UnityEngine.UI;

public class PopupPage : MonoBehaviour
{
    // Declaration of variables for UI elements
    public Text TitleText;
    public Text MessageText;
    public Button CloseButton;

    private void Start()
    {
        // Handling of BackButton click
        CloseButton.onClick.AddListener(() => Destroy(gameObject));
    }
}