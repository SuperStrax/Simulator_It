using System;
using TMPro;
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
    public GameObject backround;
    public GameObject smallBackround;

    public void Start()
    {
        textDialog.text = message[numberDialog];
        headText .text = header[numberDialog];
        ColorName();
        character.overrideSprite = characters[numberDialog];
    }

    private void Update()
    {
        if (characters[numberDialog].name == "UIMask") character.color = new Color(0, 0, 0, 150);
        else character.color = new Color(255, 255, 255, 255);

        if (message[numberDialog].Length < 50)
        {
            smallBackround.SetActive(true);
            backround.SetActive(false);
        }
        else
        {
            smallBackround.SetActive(false);
            backround.SetActive(true);
        }
    }

    void ColorName()
    {
        switch(headText.text)
        {
            case "������":
                headText.color = new Color32(213, 138, 148, 255);
                break;
            case "�������":
                headText.color = new Color32(185, 162, 129, 255);
                break;
            case "����":
                headText.color = new Color32(250, 167, 108, 255);
                break;
            case "������":
                headText.color = new Color32(175, 11, 9, 255);
                break;
            case "���� ����������":
                headText.color = new Color32(166, 202, 240, 255);
                break;
            case "������� ������������":
                headText.color = new Color32(181, 156, 255, 255);
                break;
            case "����� ���������":
                headText.color = new Color32(98, 99, 155, 255);
                break;
            case "�������� �������":
                headText.color = new Color32(250, 167, 108, 255);
                break;
            case "����":
                headText.color = new Color32(213, 138, 148, 255);
                break;
            case "�������":
                headText.color = new Color32(181, 156, 255, 255);
                break;
            case "�����":
                headText.color = new Color32(98, 99, 155, 255);
                break;
            case "������":
                headText.color = new Color32(166, 202, 240, 255);
                break;
            case "����":
            case "�����":
            case "������":
            case "�������":
                headText.color = Color.gray;
                break;
        }
    }

    public void NextDialog()
    {
        try
        {
            numberDialog++;
            textDialog.text = message[numberDialog];
            headText.text = header[numberDialog];
            ColorName();
            character.overrideSprite = characters[numberDialog];
        }
        catch (IndexOutOfRangeException)
        {
            Destroy(windowDialogue);
            throw;
        }
    }

    public void Ending()
    {
        Destroy(gameObject);
    }
}
