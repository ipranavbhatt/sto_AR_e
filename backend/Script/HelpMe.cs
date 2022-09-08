using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class HelpMe : MonoBehaviour
{
    public string shopID;
    public InputField query;
    public GameObject msg;

    public void Help()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload(){
        
        shopID = PlayerPrefs.GetString("shopID");
        // string url = "http://143.110.189.18:8000/utils/message/";
        WWWForm formData = new WWWForm();
        formData.AddField("shop_id",shopID);
        formData.AddField("message",query.text.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://143.110.189.18/utils/message/", formData);

        yield return www.SendWebRequest();

        // Debug.Log(UnityWebRequest.DownloadHandler.text);
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else {
            msg.SetActive(true);
            Debug.Log("Form upload complete!");
        }
    }

    
}
