using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keybinding : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject mouseBlocker;
    TextMeshProUGUI keybindText;

    bool leftKeybind;

    bool binding = false;
    private void Start()
    {
        keybindText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (binding)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey))
                {
                    if(leftKeybind)
                    {
                        gameManager.keybindLeft = vKey;
                    }
                    else
                    {
                        gameManager.keybindRight = vKey;
                    }
                    keybindText.text = vKey.ToString();
                    mouseBlocker.GetComponent<Image>().enabled = false;
                    binding = false;
                }
            }
        }
        
    }

    public void setKeybind()
    {
        leftKeybind = (this.gameObject.name == "KeybindButtonLeft");
        mouseBlocker.GetComponent<Image>().enabled = true;
        binding = true;
    }
}
