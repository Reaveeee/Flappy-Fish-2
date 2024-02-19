using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIndicator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Fish fish;
    bool maxSize;
    Color waterballBlue = new Color(0, 0.5756109f, 1);

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fish = GetComponentInParent<Fish>();
    }
    void Update()
    {
        transform.localScale = new Vector3(0.59f / (fish.cooldown/fish.timer), 0.59f / (fish.cooldown / fish.timer), 0);

        if (transform.localScale.x == 0.59f && !maxSize)
        {
            spriteRenderer.color = Color.white;
            LeanTween.color(this.gameObject, waterballBlue, 0.4f);
            maxSize = true;
        }
        if(transform.localScale.x < 0.59f)
        {
            maxSize = false;
        }
    }
}
