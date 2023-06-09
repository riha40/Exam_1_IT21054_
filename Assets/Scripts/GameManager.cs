using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event System.Action OnGameLost;
    public float finalTime;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void GameLost()
    {
        OnGameLost?.Invoke();
        Invoke(nameof(RestartGame), 5f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetFinalTime(float time)
    {
        finalTime = time;
    }

    public float GetFinalTime()
    {
        return finalTime;
    }

}
