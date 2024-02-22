using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    Camera camera;
    GameManager gameManager;
    Fish fish1, fish2;
    [SerializeField] GameObject resetButton;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        camera = Camera.main;
        transform.position = new Vector3(camera.ViewportToScreenPoint(Vector3.right).x / 2, camera.ViewportToScreenPoint(Vector3.up).y + 100, 0);
        GetFishEvents();
    }

    void Update()
    {
        
    }

    void GetFishEvents()
    {
        fish1 = GameObject.Find("FishLeft").GetComponent<Fish>();
        fish2 = GameObject.Find("FishRight").GetComponent<Fish>();

        fish1.OnEndGame += Appear;
        fish2.OnEndGame += Appear;
    }

    void Appear(GameObject ignore, GameObject ignore2)
    {
        LeanTween.moveY(this.gameObject, camera.ViewportToScreenPoint(Vector3.up).y / 2, 0.5f).setEaseOutCubic();
        Invoke("ShowResetButton", 1);
    }
    void Disappear()
    {
        LeanTween.moveY(this.gameObject, camera.ViewportToScreenPoint(Vector3.up).y + 100, 0.5f).setEaseInCubic();
        Invoke("destoy", 1);
    }

    void ShowResetButton()
    {
        LeanTween.moveY(resetButton, resetButton.transform.position.y - 20, 0.5f).setEaseOutCubic();
    }
    public void Restart()
    {
        gameManager.DelayedStart();
        Disappear();
        SceneManager.LoadScene("InGame");
    }
    void destoy()
    {
        Destroy(GameObject.Find("Canvas"));
    }
}
