using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscReturn : MonoBehaviour
{
    public string MenuScene = "MainMenu";

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            SceneManager.LoadScene(MenuScene);
        }
    }

}
