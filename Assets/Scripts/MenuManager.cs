using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    
    public void loadScene()
    {
        if(playerNameInput.text != "")
        {
            DataManager.Instance.playerName = playerNameInput.text;
        }
        else
        {
            DataManager.Instance.playerName = "NoName";
        }

        SceneManager.LoadScene("main");
    }
}
