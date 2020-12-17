using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void InstructionScreen()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void CreditsScreen()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
