using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartGame : MonoBehaviour
{
    public event Action OnStartGame;

    bool active = false;
    [SerializeField] GameManager gameManager;

    private void Update()
    {
        if(gameManager.keybindLeft != KeyCode.Underscore && gameManager.keybindRight != KeyCode.Underscore && !active)
        {
            LeanTween.moveY(this.gameObject, transform.position.y - 20, 0.5f).setEaseOutCubic();
            active = true;
        }
        
    }

    public void startGame()
    {
        OnStartGame.Invoke();
        SceneManager.LoadScene("InGame");
    }
}
