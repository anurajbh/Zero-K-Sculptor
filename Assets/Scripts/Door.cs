using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool victoryCondition = false;
    public Image victoryPanel;
    private void OnCollisionEnter(Collision other)
    {
        if(victoryCondition && other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            victoryPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
