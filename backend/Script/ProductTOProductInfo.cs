using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductTOProductInfo : MonoBehaviour
{
    public string productID;

    public void clickProduct(){

        GameObject gb = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        // Debug.Log(gb);
        // name = gb.transform.GetChild(0).GetComponent<Text>().text.ToString();
        productID = gb.transform.GetChild(5).GetComponent<Text>().text;
        // intID = id.ToString();
        // Debug.Log(name);
        // Debug.Log("Hello");
        // PlayerPrefs.SetString("shopName", name);
        PlayerPrefs.SetString("IDProduct", productID);
        // Debug.Log("Shop name is "+ PlayerPrefs.GetString("shopName"));
        // Debug.Log("Shop ID is "+ PlayerPrefs.GetString("shopID"));
    }
}
