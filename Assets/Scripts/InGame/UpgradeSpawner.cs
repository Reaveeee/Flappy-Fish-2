using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    Fish fish1;
    Fish fish2;

    float timer = 0;
    int min_cooldown = 5;
    int max_cooldown = 8;
    int cooldown;
    [SerializeField] GameObject upgradeItemPrefab;
    GameObject upgradeItem;

    void Start()
    {
        GetFishEvents();
        cooldown = Random.Range(min_cooldown, max_cooldown);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= cooldown)
        {
            timer = 0;
            cooldown = Random.Range(min_cooldown, max_cooldown);
            spawnUpgrade();
        }
    }

    void spawnUpgrade()
    {
        upgradeItem = Instantiate(upgradeItemPrefab, this.transform);
        upgradeItem.GetComponent<Rigidbody2D>().velocity = -Vector3.up;
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
