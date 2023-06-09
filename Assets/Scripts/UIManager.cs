using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] RectTransform gameOver;

    void Start() {
        GameManager.instance.OnGameLost += OnGameLost;
    }

    private void OnGameLost()
    {
        gameOver.gameObject.SetActive(true);
    }
}
