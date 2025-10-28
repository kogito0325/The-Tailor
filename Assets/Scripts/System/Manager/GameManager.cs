using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    None,
    Challenge,
    Casual
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    public static GameManager Instance;

    public GameMode CurrentGameMode { get; private set; }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(setting);

        CurrentGameMode = GameMode.None;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setting.SetActive(!setting.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (CurrentGameMode == GameMode.Casual)
                MoveScene("MainScene");
            else if (CurrentGameMode == GameMode.Challenge)
                MoveScene("ChallengeScene");
        }
    }

    public void RemoveHighRecord()
    {
        PlayerPrefs.SetFloat("high_score", 0f);
        MoveScene("TitleScene");
    }

    public void SetGameMode(GameMode gameMode)
    {
        CurrentGameMode = gameMode;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
