using UnityEngine;

public class BTNScript : MonoBehaviour
{
    public void ExitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void RemoveRecord()
    {
        GameManager.Instance.RemoveHighRecord();
    }
}
