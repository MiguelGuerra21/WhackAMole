using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
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
        
        SceneManager.LoadSceneAsync(GameScenes.GameScene.ToString());

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowScores()
    {
        SceneManager.LoadSceneAsync(GameScenes.ScoreTable.ToString());
    }
}
