using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float timeRemaining = 45f;

    public void Update()
    {
        if (timeRemaining == 0f) return;

        float newTimeRemaining = timeRemaining - Time.deltaTime;
        if (newTimeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGameTextController.text = "Out of time!";
            SceneManager.LoadScene("EndGame");
        }
        else
        {
            timeRemaining = newTimeRemaining;
        }

        UpdateCountdownDisplay();
    }

    void UpdateCountdownDisplay()
    {
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        countdownText.text = seconds.ToString("00") + "s";
    }
}
