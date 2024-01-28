using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneBtn : MonoBehaviour
{
    public string nextFase;
    public void ChangeScene() {
        SceneManager.LoadScene(nextFase);
    }
}
