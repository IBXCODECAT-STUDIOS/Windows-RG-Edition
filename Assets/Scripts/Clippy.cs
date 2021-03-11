using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clippy : MonoBehaviour
{
    public Text bubbleText;
    public Animator clippyAnim;
    public int clippyDelayMin;
    public int clippyDelayMax;

    public string startMsg;
    public string[] messages;

    private string clippyToggleName = "show";
    private bool clippyClicked;


    public void OnClippyClick()
    {
        clippyClicked = true;
    }

    IEnumerator Start()
    {
        clippyAnim.SetBool(clippyToggleName, true);
        bubbleText.text = startMsg;

        while(true)
        {
            if(clippyClicked)
            {
                clippyAnim.SetBool(clippyToggleName, false); //Hide Clippy
                yield return new WaitForSecondsRealtime(Random.Range(clippyDelayMin, clippyDelayMax)); //Wait
                clippyAnim.SetBool(clippyToggleName, true); //Show Clippy

                bubbleText.text = messages[Random.Range(0, messages.Length)]; //Choose random message.

                clippyClicked = false; //Clippy no longer clicked
            }
            else
            {
                yield return new WaitForEndOfFrame(); //Wait for next frame
            }
        }
    }
}
