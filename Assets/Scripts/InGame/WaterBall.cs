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
}
