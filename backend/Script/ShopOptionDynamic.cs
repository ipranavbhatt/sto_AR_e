using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOptionDynamic : MonoBehaviour
{
    public Text shopName;
    void Start()
    {
        shopName.text += PlayerPrefs.GetString("shopName");
    }
}
