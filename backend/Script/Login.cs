using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LoginData
{
    public string refresh;
    public string access;
}

public class Login : MonoBehaviour
{

    public InputField password;
    public InputField userID;
    public string token;
    public GameObject errorMessage;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    public void Start()
    {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile(@"C:\Users\Shruti\StoARe\Assets\Scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    public void Login1()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {

        // shopID = PlayerPrefs.GetString("shopID");
        // string url = "http://143.110.189.18/utils/message/";
        WWWForm formData = new WWWForm();

        formData.AddField("password", password.text.ToString());
        formData.AddField("username", userID.text.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://143.110.189.18/auth/token/", formData);

        yield return www.SendWebRequest();

        string result = www.downloadHandler.text;
        Debug.Log(result);
        LoginData loginData = JsonUtility.FromJson<LoginData>(result);
        if (loginData.access == null)
        {
            //errorMsg = result;
            errorMessage.SetActive(true);
        }
        else
        {
            Debug.Log(loginData.access);
            Debug.Log("Login successfull!");
            //SceneManager.LoadScene(scenePaths[2], LoadSceneMode.Single);
            SceneManager.LoadScene("shopAPI");
        }

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Login successfull!");
        }
    }

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}

