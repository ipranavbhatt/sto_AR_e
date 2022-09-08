using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
    public class Result
    {
        public int id;
        public string name;
        public bool is_active;
        public string address;
        public string phone;
        public string email;
        public float rating;
        public string owner_name;
        public string description;
        public string license;
        public string image;
    }

    [System.Serializable]
    public class Root
    {
        public string next;
        public string previous;
        public int count;
        public int page_total;
        public List<Result> results;
    }

    // public List<Result> lstResults = new List<Result>();

public class ShopAPIDemo : MonoBehaviour
{
    // public string var;
    // [SerializeField] Text uiShopName;
    // [SerializeField] Text uiShopAddress;
    // [SerializeField] Text uiShopRating;
    // [SerializeField] Text uiShopDescription;
    // [SerializeField] RawImage uiShopImage;
    // [SerializeField] Result[] allShops;

    string jsonURL = "http://143.110.189.18/shops/";

    void Start(){
        StartCoroutine(GetData(jsonURL));
    }

    IEnumerator GetData(string url2){
        UnityWebRequest request = UnityWebRequest.Get(url2);
        yield return request.SendWebRequest();

        if(request.isNetworkError){
            //error...
        }else{
            //success...
            GameObject Shop1 = transform.GetChild(0).gameObject;
            GameObject g;
            Root root = JsonUtility.FromJson<Root>(request.downloadHandler.text);
            // Debug.Log(root.next.ToString());
            for(int i = 0; i< root.page_total; i++){
                // print("Hello");
                g = Instantiate(Shop1, transform);
                g.transform.GetChild(0).GetComponent<Text>().text = root.results[i].name;
                g.transform.GetChild(1).GetComponent<Text>().text = root.results[i].description;
                g.transform.GetChild(2).GetComponent<Text>().text = "Loc: " + root.results[i].address;
                g.transform.GetChild(3).GetComponent<Text>().text = (root.results[i].rating).ToString();
                g.transform.GetChild(4).GetComponent<Text>().text = (root.results[i].id).ToString();
                // Debug.Log(root.results[i].id);
                // g.transform.GetChild(2).GetComponent<Image>().sprite = allShops[i].Icon;

                // uiShopName.text = root.results[i].name;
                // uiShopAddress.text = root.results[i].address;
                // uiShopRating.text = (root.results[i].rating).ToString();
                // uiShopDescription.text = root.results[i].description;
                // StartCoroutine(GetImage("https://assets.chucknorris.host/img/avatar/chuck-norris.png"));
                // IEnumerator GetImage(string url1)
                // {
                    // print(root.results[i].image);
                UnityWebRequest request1 = UnityWebRequestTexture.GetTexture(root.results[i].image);
                                                                                   // print(request);
                    yield return request1.SendWebRequest();

                    if (request1.isNetworkError)
                    {
                        //error...
                    }
                    else
                    {
                        //success...
                        // print("reaching");
                        // GameObject Shop1 = transform.GetChild(0).gameObject;
                        // GameObject g;
                        // g = Instantiate(Shop1, transform);
                        // print("reaching");
                        // var texture = DownloadHandlerTexture.GetContent(request1);
                        // uiShopImage.texture = texture;
                        // print("hello"+((DownloadHandlerTexture)request.downloadHandler).texture);
                        // uiShopImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                        // print(uiShopImage.texture);
                        g.transform.GetChild(5).GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(request1);
                        // uiShopName.text = root.results[i].name;
                        // uiShopAddress.text = root.results[i].address;
                        // uiShopRating.text = (root.results[i].rating).ToString();
                        // uiShopDescription.text = root.results[i].description;
                        // Destroy(Shop1);
                    }
                    request1.Dispose();
                
                // print(root.results[i].image);
            }
            // if(root.next != null){
            //     StartCoroutine(GetData(root.next));
            // }
            Destroy(Shop1);
        }
        request.Dispose();
    }
    

}
