using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DemoList : MonoBehaviour
{
    // Start is called before the first frame update
    [Serializable]
    public struct Shop{
        public string Name;
        public string Description;
        public Sprite Icon;
    }

    [SerializeField] Shop[] allShops;

    void Start()
    {

        GameObject Shop1 = transform.GetChild(0).gameObject;
        GameObject g;

        int N = allShops.Length;
        for (int i = 0; i < N; i++){
            g = Instantiate(Shop1, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = allShops[i].Name;
            g.transform.GetChild(1).GetComponent<Text>().text = allShops[i].Description;
            g.transform.GetChild(2).GetComponent<Image>().sprite = allShops[i].Icon;
        }

        Destroy(Shop1);
    }

}
