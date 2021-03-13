using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class OS : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject startMenu;
    public AudioSource shutdownSound;
    public AudioSource bootSound;
    public GameObject logoOverlay;

    private bool videoActive;
    private bool startActive;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            videoActive = !videoActive;
            MediaPlayer(videoActive);
        }

        if(Input.GetKeyDown(KeyCode.LeftWindows) || Input.GetKeyDown(KeyCode.RightWindows) || Input.GetKeyDown(KeyCode.Escape))
        {
            startActive = !startActive;
            startMenu.SetActive(startActive);
        }
    }

    public void MediaPlayer(bool enabled)
    {
        if(enabled)
        {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Stop();
            videoPlayer.gameObject.SetActive(false);
        }
    }

    public void Shutdown() { StartCoroutine(ShutdownRoutine()); }
    public void Restart() { StartCoroutine(RestartRoutine()); }

    IEnumerator ShutdownRoutine()
    {
        shutdownSound.Play();
        logoOverlay.SetActive(true);
        yield return new WaitForSecondsRealtime(2.5f);
        Debug.Log("Quitting Application");
        Application.Quit();
    }

    IEnumerator RestartRoutine()
    {
        shutdownSound.Play();
        logoOverlay.SetActive(true);
        yield return new WaitForSecondsRealtime(2.5f);
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarted");
    }
}
