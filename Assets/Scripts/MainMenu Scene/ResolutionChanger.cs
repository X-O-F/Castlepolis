using TMPro;
using UnityEngine;
public class ResolutionChanger : MonoBehaviour
{
    public TextMeshProUGUI currentResolutionLabel;
    private static bool hasSetRes = false;
    private static string currentRes;

    void Start() // Automatically pick best compatible resolution
    {
        Resolution userResolution = Screen.currentResolution;
        int userWidth = userResolution.width;
        int userHeight = userResolution.height;
        Debug.Log("User desktop resolution: " + userWidth + "x" + userHeight);

        if (hasSetRes)
        {
            UpdateResolutionLabel();
            return;
        }

        if (userWidth >= 3840 && userHeight >= 2160)
        {
            SetResolution3840x2160();
        }
        else if (userWidth >= 2560 && userHeight >= 1440)
        {
            SetResolution2560x1440();
        }
        else if (userWidth >= 1920 && userHeight >= 1080)
        {
            SetResolution1920x1080();
        }
        else
        {
            SetResolution1280x720();
        }
        hasSetRes = true;
    }

    public void SetResolution1280x720()
    {
        Screen.SetResolution(1280, 720, false);
        currentRes = "1280x720";
        UpdateResolutionLabel();
    }

    public void SetResolution1920x1080()
    {
        Screen.SetResolution(1920, 1080, false);
        currentRes = "1920x1080";
        UpdateResolutionLabel();
    }

    public void SetResolution2560x1440()
    {
        Screen.SetResolution(2560, 1440, false);
        currentRes = "2560x1440";
        UpdateResolutionLabel();
    }

    public void SetResolution3840x2160()
    {
        Screen.SetResolution(3840, 2160, false);
        currentRes = "3840x2160";
        UpdateResolutionLabel();
    }

    private void UpdateResolutionLabel()
    {
        currentResolutionLabel.SetText("Current: " + currentRes);
    }
}
