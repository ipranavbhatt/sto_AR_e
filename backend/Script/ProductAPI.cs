using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
    public class Product
    {
        public int id;
        public string name;
        public string description;
        public float price;
        public float rating;
        public string image;
        public int shop_id;
        public string shop_name;
    }

    [System.Serializable]
    public class Data1
    {
        
        public string next;
        public string previous;
        public int count;
        public int page_total;
        public List<Product> results;
    }

    // public List<Result> lstResults = new List<Result>();

public class ProductAPI : MonoBehaviour
{

    public string IDshop;
    string jsonURL = "http://143.110.189.18/products/";

    void Start(){
        StartCoroutine(GetData(jsonURL));
    }

    IEnumerator GetData(string url1){
        UnityWebRequest request = UnityWebRequest.Get(url1);
        yield return request.SendWebRequest();

        if(request.isNetworkError){
            //error...
        }else{
            //success...
            GameObject product1 = transform.GetChild(0).gameObject;
            GameObject g;
            Data1 data1 = JsonUtility.FromJson<Data1>(request.downloadHandler.text);
            IDshop = PlayerPrefs.GetString("shopID");
            // Debug.Log(data1.results.shop_id);
            for(int i = 0; i< data1.count; i++){
                // print("Hello");
                // if(data1.shop_id == )
                if(data1.results[i].shop_id.ToString() == IDshop){
                g = Instantiate(product1, transform);
                g.transform.GetChild(0).GetComponent<Text>().text = data1.results[i].name;
                g.transform.GetChild(1).GetComponent<Text>().text = data1.results[i].description;
                g.transform.GetChild(2).GetComponent<Text>().text = (data1.results[i].price).ToString();
                g.transform.GetChild(3).GetComponent<Text>().text = (data1.results[i].rating).ToString();
                g.transform.GetChild(5).GetComponent<Text>().text = (data1.results[i].id).ToString();

                UnityWebRequest request1 = UnityWebRequestTexture.GetTexture(data1.results[i].image);
            
                    yield return request1.SendWebRequest();

                    if (request1.isNetworkError)
                    {
                        //error...
                    }
                    else{
                        // Debug.Log(DownloadHandlerTexture.GetContent(request1));
                        g.transform.GetChild(4).GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(request1);
                    }
                    request1.Dispose();
            }
            else{
                continue;
            }
            }
            // if(root.next != null){
            //     StartCoroutine(GetData(root.next));
            // }
            Destroy(product1);
        }
        request.Dispose();
    }
}

