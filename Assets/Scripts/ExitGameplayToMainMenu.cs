using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameplayToMainMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusicClass>().PlayMusic();
        SceneManager.LoadScene("MenuScene");
    }
}
