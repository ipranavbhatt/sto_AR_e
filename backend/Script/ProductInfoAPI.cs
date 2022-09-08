using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
    public class ProductInfo
    {
        public int id;
        public string name;
        public string description;
        public float price;
        public float rating;
        public string image;
        public int shop_id;
        public string shop_name;
        public List<string> related_image_urls; 

    }


public class ProductInfoAPI : MonoBehaviour
{        
    public string productID;
    public GameObject productName;

    void Start(){

    productID= PlayerPrefs.GetString("IDProduct");
    string jsonURL = $"http://143.110.189.18/products/{productID}/";

        StartCoroutine(GetData(jsonURL));
    }

    IEnumerator GetData(string url1){
        UnityWebRequest request = UnityWebRequest.Get(url1);
        yield return request.SendWebRequest();

        if(request.isNetworkError){
            //error...
        }else{
            //success...
            GameObject product2 = transform.GetChild(0).gameObject;
            GameObject g;
            ProductInfo productInfo = JsonUtility.FromJson<ProductInfo>(request.downloadHandler.text);
            
                g = Instantiate(product2, transform);
                // g.transform.GetChild(0).GetComponent<Text>().text = data1.results[i].name;
                g.transform.GetChild(1).GetComponent<Text>().text = (productInfo.price).ToString()+" $";
                // g.transform.GetChild(2).GetComponent<Text>().text = (data1.results[i].price).ToString();
                // g.transform.GetChild(3).GetComponent<Text>().text = (data1.results[i].rating).ToString();
                g.transform.GetChild(4).GetComponent<Text>().text = productInfo.description;
                productName.transform.GetComponent<Text>().text = productInfo.name;

                    UnityWebRequest request1 = UnityWebRequestTexture.GetTexture(productInfo.image);
                    UnityWebRequest request2 = UnityWebRequestTexture.GetTexture(productInfo.related_image_urls[0]);
                    UnityWebRequest request3 = UnityWebRequestTexture.GetTexture(productInfo.related_image_urls[1]);
            
                   yield return request1.SendWebRequest();
                   yield return request2.SendWebRequest();
                   yield return request3.SendWebRequest();

                    if (request1.isNetworkError || request2.isNetworkError || request3.isNetworkError)
                    {
                        //error...
                    }
                    
                    else{
                        // Debug.Log(DownloadHandlerTexture.GetContent(request1));
                        g.transform.Find("Scroll Area/Content/First").GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(request1);
                        g.transform.Find("Scroll Area/Content/Second").GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(request2);
                        g.transform.Find("Scroll Area/Content/Third").GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(request3);
                    } 
                    request1.Dispose();  
                    request2.Dispose();  
                    request3.Dispose();               
                    Destroy(product2);
            }
             request.Dispose();
            }
            // if(root.next != null){
            //     StartCoroutine(GetData(root.next));
            // }
       
    }

