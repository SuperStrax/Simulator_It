using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDialog;
    public TextMeshProUGUI headText;
    public UnityEngine.UIElements.Button button;
    public GameObject windowDialogue;
    public Image character;
    public string[] message;
    public string[] header;
    public Sprite[] characters;
    public int numberDialog = 0;

    public void Start()
    {
        textDialog.text = message[numberDialog];
        headText .text = header[numberDialog];
        character.overrideSprite = characters[numberDialog];
    }

    public void NextDialog()
    {
        try
        {
            numberDialog++;
            if (characters[numberDialog].name == "UIMask") character.color = new Color(0, 0, 0, 150);
            else character.color = new Color(255, 255, 255, 255);
            textDialog.text = message[numberDialog];
            headText.text = header[numberDialog];
            character.overrideSprite = characters[numberDialog];
        }
        catch (IndexOutOfRangeException)
        {
            Destroy(windowDialogue);
            throw;
        }
    }
}
