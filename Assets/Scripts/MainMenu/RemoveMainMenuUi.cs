using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMainMenuUi : MonoBehaviour
{
    [SerializeField] StartGame startGame;
    [SerializeField] Camera camera;

    RectTransform rectTransform;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rectTransform = GetComponent<RectTransform>();
        startGame.OnStartGame += removeMainMenuUi;
        if (!gameManager.firstGame)
        {
            transform.position = new Vector3(camera.ViewportToScreenPoint(Vector3.right).x / 2, camera.ViewportToScreenPoint(Vector3.up).y + 100, 0);
            //LeanTween.moveY(this.gameObject, camera.ViewportToScreenPoint(Vector3.up).y + 100, 0);
            LeanTween.moveY(this.gameObject, camera.ViewportToScreenPoint(Vector3.up).y / 2, 0.5f).setEaseOutCubic();
        }
    }

    void removeMainMenuUi()
    {
        LeanTween.moveY(this.gameObject, camera.ViewportToScreenPoint(Vector3.up).y + 100, 0.5f).setEaseInCubic();
        Invoke("destoy", 1);
    }

    void destoy()
    {
        Destroy(this.gameObject);
    }
}
