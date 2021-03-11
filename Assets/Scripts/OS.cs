using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class OS : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private bool active;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            active = !active;
            MediaPlayer(active);
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
