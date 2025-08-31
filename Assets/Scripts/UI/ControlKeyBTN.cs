using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlKeyBTN : BTNScript
{
    [SerializeField] private Sprite[] btnSprites;
    [SerializeField] private TextMeshProUGUI keyTxt;
    [SerializeField] private PlayerActionType playerActionType;

    private bool isInActivated;

    private void Start()
    {
        isInActivated = false;
        SetKeyTxt();
        SetImage();
    }

    void OnGUI()
    {
        if (!isInActivated)
            return;

        Event e = Event.current;
        if (e.isMouse && e.type == EventType.MouseDown)
        {
            isInActivated = false;
            SetImage();
        }
        else if (e.isKey && e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
        {
            KeyCode pressedKey = e.keyCode;

            KeyManager.instance.SetKey(pressedKey, playerActionType);
            KeyManager.instance.SaveKeyBindings();
            SetKeyTxt();
            isInActivated = false;
            SetImage();
        }
    }

    public void Activate()
    {
        isInActivated = !isInActivated;
        SetImage();
    }

    private void SetImage()
    {
        if (isInActivated)
            GetComponent<Image>().sprite = btnSprites[1];
        else
            GetComponent<Image>().sprite = btnSprites[0];
    }

    private void SetKeyTxt()
    {
        keyTxt.text = KeyManager.instance.Keys[playerActionType].ToString();
    }
}
