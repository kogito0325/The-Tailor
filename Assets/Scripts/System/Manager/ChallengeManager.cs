using UnityEngine;
using TMPro;

public class ChallengeManager : MonoBehaviour
{
    public float CurrentScore {  get; private set; }

    [SerializeField] private GameObject endWindow;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI winScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private TextMeshProUGUI highRecordTxt;

    private float _highScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endWindow.SetActive(false);
        
        _highScore = PlayerPrefs.GetFloat("high_score", 0f);
        highScoreTxt.text = "최고기록: " + ((int)_highScore).ToString() + "점";
        CurrentScore = 0f;
        scoreTxt.text = "0점";
        highRecordTxt.gameObject.SetActive(false);
    }

    public void AddScore(float scoreAmount)
    {
        CurrentScore += scoreAmount;
        scoreTxt.text = ((int)CurrentScore).ToString() + "점";
    }

    public void EndProcess()
    {
        ActivateEndWindow();
        if (CurrentScore > _highScore)
        {
            UpdateHighScore(CurrentScore);
        }
    }

    public void UpdateHighScore(float score)
    {
        PlayerPrefs.SetFloat("high_score", score);
        _highScore = score;
        highScoreTxt.text = "최고기록: " + ((int)_highScore).ToString() + "점";
        highRecordTxt.gameObject.SetActive(true);
    }

    public void ActivateEndWindow()
    {
        endWindow.SetActive(true);
        winScoreTxt.text = ((int)CurrentScore).ToString() + "점";
    }
}
