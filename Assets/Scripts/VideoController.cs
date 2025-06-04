using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public GameObject videoPanel;
    public VideoPlayer videoPlayer;

    public void ShowVideo()
    {
        videoPanel.SetActive(true);
        videoPlayer.Play();
    }

    public void HideVideo()
    {
        videoPlayer.Stop();
        videoPanel.SetActive(false);
    }
}
