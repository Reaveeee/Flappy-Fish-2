using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    GameObject fishToUpgrade;
    [SerializeField] GameObject deleteParticles;
    Fish fish1;
    Fish fish2;

    [SerializeField]public int type;
    void Start()
    {
        //Type 0: Cooldown
        //Type 1: Speed
        //Type 2: Amount
        type = Random.Range(0, 2);

        GetFishEvents();
    }

    private void Update()
    {
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WaterBall"))
        {
            fishToUpgrade = GameObject.Find(collision.gameObject.GetComponent<WaterBall>().owner);
            switch (type)
            {
                case 0:
                    fishToUpgrade.GetComponent<Fish>().cooldown *= 0.8f;
                    break;
                case 1:
                    fishToUpgrade.GetComponent<Fish>().shootForce *= 1.2f;
                    break;
            }
            Instantiate(deleteParticles, transform.position, deleteParticles.transform.rotation);
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
