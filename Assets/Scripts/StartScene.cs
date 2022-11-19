using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void LoadGameLevel(int GameScene)
    {
        GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusicClass>().StopMusic();
        SceneManager.LoadScene("OFFICIAL GAMEPLAY");
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
