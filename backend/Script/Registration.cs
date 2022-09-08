using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

[System.Serializable]
public class ErrorData{

    public List<string> username;
    public List<string> password;
    public List<string> email;
}

public class Registration : MonoBehaviour
{
    public InputField fName;
    public InputField lName;
    public InputField userID;
    public InputField password;
    public InputField eMail;
    public Text errorMsg;
    public Text successMsg;
    public string errorPassword = "";
    public string errorEmail = "";
    public string errorUserName = "";

    public void Register()
    {
        StartCoroutine(Upload());
    }

     IEnumerator Upload(){
        
        // shopID = PlayerPrefs.GetString("shopID");
        // string url = "http://143.110.189.18:8000/utils/message/";
        WWWForm formData = new WWWForm();
        formData.AddField("username",userID.text.ToString());
        formData.AddField("password",password.text.ToString());
        formData.AddField("email",eMail.text.ToString());
        formData.AddField("first_name",fName.text.ToString());
        formData.AddField("last_name",lName.text.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://143.110.189.18/auth/register/", formData);

        yield return www.SendWebRequest();

        // Debug.Log(UnityWebRequest.DownloadHandler.text);
        string result = www.downloadHandler.text;
        ErrorData errorData = JsonUtility.FromJson<ErrorData>(result);
        Debug.Log(result);
        if(errorData.password.Count>0){
            errorPassword = errorData.password[0];
        }
        // errorPassword = errorData.password[0];
        // Debug.Log(errorData.username[0]);
        if(errorData.email.Count>0){
            errorEmail = errorData.email[0];
        }
        if(errorData.username.Count>0){
            errorUserName = errorData.username[0];
        }
        // errorUserName = errorData.username[0];
        // Debug.Log(result);
        errorMsg.text = "";
        if (www.isNetworkError || www.isNetworkError)
        {
            errorMsg.text = "Please try again!!";
            errorMsg.gameObject.SetActive(true);
            Debug.Log(www.error);
        }
        
        else {
            if(errorPassword.Length>0 || errorEmail.Length>0){
                errorMsg.text = errorPassword+"\n"+errorEmail+"\n"+errorUserName;
                // +" "+errorEmail;
                errorMsg.gameObject.SetActive(true);
            }
            else{
                
                successMsg.text = "Registration successfull!!";
                successMsg.gameObject.SetActive(true);
                Debug.Log("Registration successfull!!");
            }
            // msg.text = "Sign Up Successfull!!";
            
        }
    }
}
