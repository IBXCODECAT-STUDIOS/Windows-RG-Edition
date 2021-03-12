using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class OS : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject startMenu;

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
}
