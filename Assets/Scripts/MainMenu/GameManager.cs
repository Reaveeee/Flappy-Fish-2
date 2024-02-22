using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Fish fish1;
    Fish fish2;

    [SerializeField] StartGame startGame;
    [SerializeField] GameObject waterBallParent;
    GameObject[] waterBalls;

    public KeyCode keybindLeft;
    public KeyCode keybindRight;

    public bool firstGame = true;
    void Start()
    {
        keybindLeft = KeyCode.Underscore; 
        keybindRight = KeyCode.Underscore;
        startGame.OnStartGame += DelayedStart;
    }

    void Update()
    {
        
    }

    public void DelayedStart()
    {
        Invoke("GetFishEvents", 1);
    }

    void GetFishEvents()
    {
        fish1 = GameObject.Find("FishLeft").GetComponent<Fish>();
        fish2 = GameObject.Find("FishRight").GetComponent<Fish>();

        fish1.OnEndGame += EndGame;
        fish2.OnEndGame += EndGame;
    }

    void EndGame(GameObject winner, GameObject loser)
    {
        winner.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        winner.GetComponent<Fish>().enabled = false;
        winner.transform.rotation = Quaternion.Euler(0, 0, 0);
        Destroy(loser);
        LeanTween.move(winner, Vector2.zero, 0.5f).setEaseOutCubic();
        firstGame = false;
    }
}
