using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

// [System.Serializable]
// public class LoginData{
//     public string refresh;
//     public string access;
// }

public class Order : MonoBehaviour
{

    public string productName;
    public string usrName;
    // public int quantity;
    public InputField qty;
    
    public void Order1()
    {
        StartCoroutine(Upload());
    }

     IEnumerator Upload(){
        
        // shopID = PlayerPrefs.GetString("shopID");
        // string url = "http://143.110.189.18:8000/utils/message/";
        WWWForm formData = new WWWForm();
        
        usrName = PlayerPrefs.GetString("userName");
        productName = PlayerPrefs.GetString("prodName");
        formData.AddField("product",productName);
        formData.AddField("quantity",qty.ToString());
        formData.AddField("order_by",usrName);
        

        UnityWebRequest www = UnityWebRequest.Post("http://143.110.189.18/order/", formData);

        yield return www.SendWebRequest();
        
        string result = www.downloadHandler.text;
        Debug.Log(result);
        LoginData loginData = JsonUtility.FromJson<LoginData>(result);
        Debug.Log(loginData.access);
        
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else {
            // msg.SetActive(true);
            Debug.Log("Login successfull!");
        }
    }
}

