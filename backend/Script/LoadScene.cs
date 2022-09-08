using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void SceneLoader(int SceneIndex){

        SceneManager.LoadScene(SceneIndex);
    }
}
