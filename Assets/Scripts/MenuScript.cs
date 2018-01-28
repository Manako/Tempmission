using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public AudioClip level1_audio;
    public AudioClip level2_audio;
    public AudioClip level3_audio;

    public AudioSource BackgroundAudio;

    public void exitApplication()
    {
        Debug.Log("Exiting application");
        Application.Quit();
    }

    public void startAudio(string level_name)
    {
        switch (level_name)
        {
            case "Level1": BackgroundAudio.clip = level1_audio;
                break;
            case "Level2":
                BackgroundAudio.clip = level2_audio;
                break;
            case "Level3": BackgroundAudio.clip = level3_audio;
                break;
        }
        Debug.Log(BackgroundAudio.clip);
        BackgroundAudio.Play();
    }

    public void loadNewGame()
    {
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            SceneManager.UnloadSceneAsync(scene);
        }

        SceneManager.LoadScene("TitleMenu");
    }

    public void loadNewLevel(string level_name)
    {
       
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            SceneManager.UnloadSceneAsync(scene);
            
        }

        SceneManager.LoadScene(level_name);
        SceneManager.LoadScene("Level_Overlay", LoadSceneMode.Additive);


    }
}
