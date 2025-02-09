using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton(){
        Debug.Log("Play button clicked!");
        SceneManager.LoadScene("_Scene_0");
    }

}
