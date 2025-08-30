using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenModeBTN : BTNScript
{
    [SerializeField] private TextMeshProUGUI keyTxt;

    private void Start()
    {
        Screen.fullScreen = true;
        UpdateKeyTxt();
    }


    public void Activate()
    {
        Screen.fullScreen = !Screen.fullScreen;
        UpdateKeyTxt();
    }

    private void UpdateKeyTxt()
    {
        keyTxt.text = Screen.fullScreen ? "Full Screen" : "Windowed Screen";
    }

}
