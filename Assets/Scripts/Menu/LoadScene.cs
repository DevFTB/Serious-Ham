using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string Scene;
    // Start is called before the first frame update
    public void Load() {
        SceneManager.LoadScene(Scene);
    }
}
