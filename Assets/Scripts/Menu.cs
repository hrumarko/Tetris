using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    static bool isPaused = false;
    public GameObject pauseUI;
    static int clickSound = 0;
    static int clickMusic = 0;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            } else{
                Pause();
            }
            
        }
    }

    public void Resume(){
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause(){
        isPaused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MenuButton(){
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit(){
        Application.Quit();
    }

    public void Sound(){
        if(clickSound == 0){
            Sounds.isSound = false;
            clickSound++;
        }else if(clickSound == 1){
            Sounds.isSound = true;
            clickSound = 0;
        }

        
    }

    public void MusicButton(){
        if(clickMusic == 0){
            Music.StopMusic();
            clickMusic++;
        }else if(clickMusic == 1){
            Music.StartMusic();
            clickMusic = 0;
        }
        
    }
}
