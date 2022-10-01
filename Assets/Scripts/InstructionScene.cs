using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionScene : MonoBehaviour
{
    public void LoadGameLevel(int GameScene)
    {
        SceneManager.LoadScene("Instruction");
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
