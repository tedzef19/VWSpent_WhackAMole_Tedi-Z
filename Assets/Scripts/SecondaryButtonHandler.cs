using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryButtonHandler : MonoBehaviour
{
    public ResetPanel resetPanel;

    private void Update()
    {
        // Keyboard 2
        if (Keyboard.current != null && Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            resetPanel?.ShowResetPanel();
        }

        // PICO B-Button (rechter Controller)
        if (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            resetPanel?.ShowResetPanel();
        }
    }
}