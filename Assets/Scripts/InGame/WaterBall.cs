using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class WaterBall : MonoBehaviour
{
    Fish fish1;
    Fish fish2;
    public string owner;
    private void Start()
    {
        GetFishEvents();
        changeDark();
    }
    void Update()
    {
        if(transform.position.x < -100 || transform.position.x > 100)
        {
            Destroy(this.gameObject);
        }
    }
    void GetFishEvents()
    {
        fish1 = GameObject.Find("FishLeft").GetComponent<Fish>();
        fish2 = GameObject.Find("FishRight").GetComponent<Fish>();

        fish1.OnEndGame += Delete;
        fish2.OnEndGame += Delete;
    }

    void Delete(GameObject ignore, GameObject ignore2)
    {
        Destroy(this.gameObject);
    }

    void changeDark()
    {
        LeanTween.color(gameObject, Color.blue, 1f);
        Invoke("changeBright", 1f);
    }
    void changeBright()
    {
        LeanTween.color(gameObject, Color.white, 1f);
        Invoke("changeDark", 1f);
    }
}
