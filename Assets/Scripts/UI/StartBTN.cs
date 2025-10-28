using UnityEngine;

public class StartBTN : BTNScript
{
    [SerializeField] private string sceneName;

    public void EnterMainScene()
    {
        GameManager.Instance.SetGameMode(GameMode.Casual);
        GameManager.Instance.MoveScene(sceneName);
    }

    public void EnterChallengeScene()
    {
        GameManager.Instance.SetGameMode(GameMode.Challenge);
        GameManager.Instance.MoveScene(sceneName);
    }
}
