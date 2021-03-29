using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteShop : MonoBehaviour
{
    public GameObject shop;
    
    /// <summary>
    /// otevře tabulku s obchodem
    /// </summary>
    void OnMouseDown()
    {
        if (this.gameObject.name == "paletteShop")
            OpenShop();
    }

    public void OpenShop()
    {
        if (shop.activeSelf)
            shop.SetActive(false);
        else
            shop.SetActive(true);
    }
}
