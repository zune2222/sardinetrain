using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changScene: MonoBehaviour
{
    public void changeFirstScene()
    {
        SceneManager.LoadScene("playScene");
    }
    public void changeSecondScene()
    {
        SceneManager.LoadScene("stockScene");
    }
}
