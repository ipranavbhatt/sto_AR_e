using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


[System.Serializable]
public struct Data{
    public string icon_url;
    public string id;
    public string url;
    public string value;
}

public class APIDemo : MonoBehaviour
{
    [SerializeField] Text uiNameText;
    [SerializeField] RawImage uiRawImage;

    string jsonURL = "https://api.chucknorris.io/jokes/random";

    void Start(){
        StartCoroutine(GetData(jsonURL));
    }

    IEnumerator GetData(string url2){
        UnityWebRequest request = UnityWebRequest.Get(url2);
        yield return request.Send();

        if(request.isNetworkError){
            //error...
        }else{
            //success...
            Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text);
            uiNameText.text = data.value;
            StartCoroutine(GetImage(data.icon_url));
            // Debug.Log(request);
        }
        request.Dispose();
    }
    IEnumerator GetImage(string url1){

         UnityWebRequest request = UnityWebRequestTexture.GetTexture(url1);
        yield return request.Send();

        if(request.isNetworkError){
            //error...
        }else{
            //success...
           uiRawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }

}
