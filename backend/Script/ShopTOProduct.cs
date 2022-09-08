using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTOProduct : MonoBehaviour{

    // public Text name;
    public string name;
    public string id;

    public void clickShop(){

        GameObject gb = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        // Debug.Log(gb);
        name = gb.transform.GetChild(0).GetComponent<Text>().text.ToString();
        id = gb.transform.GetChild(4).GetComponent<Text>().text;
        // intID = id.ToString();
        // Debug.Log(name);
        // Debug.Log("Hello");
        PlayerPrefs.SetString("shopName", name);
        PlayerPrefs.SetString("shopID", id);
        // Debug.Log("Shop name is "+ PlayerPrefs.GetString("shopName"));
        // Debug.Log("Shop ID is "+ PlayerPrefs.GetString("shopID"));
    }

}

