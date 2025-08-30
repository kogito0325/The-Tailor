using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlKeyBTN : BTNScript
{
    [SerializeField] private TextMeshProUGUI keyTxt;
    [SerializeField] private PlayerActionType playerActionType;

    private bool isInActivated;

    private void Start()
    {
        isInActivated = false;
        SetKeyTxt();
    }

    void OnGUI()
    {
        if (!isInActivated)
            return;

        Event e = Event.current;
        if (e.isMouse && e.type == EventType.MouseDown)
            isInActivated = false;
        else if (e.isKey && e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
        {
            KeyCode pressedKey = e.keyCode;

            KeyManager.instance.SetKey(pressedKey, playerActionType);
            KeyManager.instance.SaveKeyBindings();
            SetKeyTxt();
            isInActivated = false;
        }
    }

    public void Activate()
    {
        isInActivated = !isInActivated;
    }

    private void SetKeyTxt()
    {
        keyTxt.text = KeyManager.instance.Keys[playerActionType].ToString();
    }
}
