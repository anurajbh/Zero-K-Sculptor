using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public int index = 1;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadTheScene);
    }

    private void LoadTheScene()
    {
        SceneManager.LoadScene(index);
    }
}
