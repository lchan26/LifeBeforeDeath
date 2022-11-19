using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameButton : MonoBehaviour
{
    public void callLoadScene(){
        GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusicClass>().StopMusic();
        SceneManager.LoadScene("OFFICIAL GAMEPLAY");
    }
}
