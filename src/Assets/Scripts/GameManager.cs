using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool win = false;
    public Button restartButton;
    public bool start = false;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            restartGame();
        }
        if (Input.GetKeyDown(KeyCode.P) && !start)
        {
            StartGame();
        }
        if (win)
        {
            restartButton.gameObject.SetActive(true);
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        titleScreen.SetActive(false);
        start = true;
    }
}