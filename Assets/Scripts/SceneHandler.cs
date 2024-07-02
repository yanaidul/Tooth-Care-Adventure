using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    //Method code yang dipanggil untuk restart game
    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Method code yang dipanggil untuk kembali ke main menu
    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Method code yang dipanggil untuk ke scene game sekection
    public void ToGameSelectionScene()
    {
        SceneManager.LoadScene(1);
    }

    //Method code yang dipanggil untuk ke scene game
    public void ToGameScene()
    {
        SceneManager.LoadScene(2);
    }
}
