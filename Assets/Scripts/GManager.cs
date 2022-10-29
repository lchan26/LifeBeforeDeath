using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    [SerializeField] private Timer internalTimer;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (internalTimer.TimeLeft < 1)
        {
            GameOver();
        }

    }

    void GameOver()
    {
        print("ah!");
        SceneManager.LoadScene("GameOverScene");
    }
}
