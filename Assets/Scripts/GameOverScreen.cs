using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text bestTimeText;

    private void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        bestTimeText.text = "GAME OVER\nBEST TIME: " + FormatTime(bestTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
