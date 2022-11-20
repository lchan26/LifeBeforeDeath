using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoreManager : MonoBehaviour
{
    [SerializeField] List<Chore> chores;
    public void onChoreComplete()
    {
        bool completed = true;
        foreach (Chore c in chores)
        {
            if (!c.completed)
            {
                completed = false;
            }
        }
        if (completed)
        {

            GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusicClass>().PlayMusic();
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
