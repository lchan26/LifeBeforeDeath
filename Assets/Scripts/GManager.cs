using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    [SerializeField] private Timer internalTimer;

    private bool isLoaded;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (internalTimer.TimeLeft == internalTimer.timeLimit)
        {
            isLoaded = true;
        }
        if (internalTimer.TimeLeft < 1 & isLoaded)
        {
            GameOver();
        }

    }

    void GameOver()
    {
        GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusicClass>().PlayMusic();
        SceneManager.LoadScene("GameOverScene");
    }
}
