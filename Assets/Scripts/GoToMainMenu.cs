using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public void callLoadMainMenu()
    {

        // GameObject.FindGameObjectWithTag("OverMusic").GetComponent<MenuMusicClass>().StopMusic();
        SceneManager.LoadScene("MenuScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
