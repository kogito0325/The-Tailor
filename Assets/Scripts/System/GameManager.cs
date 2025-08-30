using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    public static GameManager Instance;

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
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setting.SetActive(!setting.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
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
