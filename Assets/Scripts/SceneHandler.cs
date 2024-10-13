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
        BGM.GetInstance().bgm.Stop();
        SceneManager.LoadScene(0);
    }

    //Method code yang dipanggil untuk ke scene game sekection
    public void ToGameSelectionScene()
    {
        if(!BGM.GetInstance().bgm.isPlaying) BGM.GetInstance().bgm.Play();
        SceneManager.LoadScene(1);
    }

    //Method code yang dipanggil untuk ke scene game
    public void ToKarangGigiGameScene()
    {
        if (!BGM.GetInstance().bgm.isPlaying) BGM.GetInstance().bgm.Play();
        SceneManager.LoadScene(2);
    }

    //Method code yang dipanggil untuk ke scene game
    public void ToCabutGigiGameScene()
    {
        if (!BGM.GetInstance().bgm.isPlaying) BGM.GetInstance().bgm.Play();
        SceneManager.LoadScene(3);
    }

    public void OnPauseGame()
    {
        Time.timeScale = 0;
    }

    public void OnResumeGame()
    {
        Time.timeScale = 1;
    }
}
