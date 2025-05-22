using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class VRMenuController : MonoBehaviour
{
    [Header("Панелі")]
    public GameObject mainMenuPanel;
    public GameObject instructionPanel;
    public GameObject settingsPanel;

    [Header("UI Елементи")]
    public Toggle soundToggle;

    [Header("Контролери")]
    public XRNode controllerNode = XRNode.LeftHand; // Вказано ЛІВИЙ контролер

    private bool menuVisible = false;
    private bool buttonWasPressed = false;

    void Start()
    {
        ShowMainMenu(); // Показати тільки головне меню
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);

        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed))
        {
            if (isPressed && !buttonWasPressed)
            {
                buttonWasPressed = true;

                if (!menuVisible)
                    OpenMenu();
                else
                    CloseMenu();
            }
            else if (!isPressed)
            {
                buttonWasPressed = false;
            }
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        mainMenuPanel.SetActive(true);
        instructionPanel.SetActive(false);
        settingsPanel.SetActive(false);
        menuVisible = true;
    }

    public void CloseMenu()
    {
        mainMenuPanel.SetActive(false);
        instructionPanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
        menuVisible = false;
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        instructionPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ShowInstructions()
    {
        mainMenuPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMain()
    {
        ShowMainMenu();
    }

    public void ToggleSound(bool isOn)
    {
        AudioListener.volume = isOn ? 1f : 0f;
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
