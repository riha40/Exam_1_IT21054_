using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float currentTime;
    public TMP_Text countdownText;

    private float bestTime;
    private bool isCounting = true;

    private void Update()
    {
        if (isCounting)
        {
            currentTime += Time.deltaTime;
            countdownText.text = FormatTime(currentTime);
        }
    }

    public void StopCounting()
    {
        isCounting = false;
        HandleGameEnded();
    }

    private void HandleGameEnded()
    {
        int finalTime = Mathf.FloorToInt(currentTime);
        GameManager.instance.SetFinalTime(finalTime);
        GameManager.instance.GameLost();
        UpdateTime();
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("TIME: {0:00}:{1:00}", minutes, seconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("FallingObj");
            StopCounting();
            Destroy(gameObject);
        }
    }

    private void UpdateTime()
    {
    if (currentTime > PlayerPrefs.GetFloat("BestTime", 0f))
    {
        PlayerPrefs.SetFloat("BestTime", currentTime);
        PlayerPrefs.Save();
    }
    }
}