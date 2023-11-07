using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CartridgeInsert : MonoBehaviour
{
    public Sprite broken;
    public GameObject cartridge1;
    public GameObject cartridge2;
    public GameObject cartridge3;
    public bool selected = false;

    public void cartridgeDelete()
    {
        Destroy(cartridge1);
        Destroy(cartridge2);
        Destroy(cartridge3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        selected = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        selected = false;
    }
}
