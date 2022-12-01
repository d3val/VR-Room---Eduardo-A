using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClosedCaptionOfVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] ShowMessageFromList txt_list;
    // Update is called once per frame


    private void LateUpdate()
    {
        if (!videoPlayer.isPlaying)
        {
            txt_list.ShowMessageAtIndex(0);
            return;
        }
        txt_list.ShowMessageAtIndex(1);
    }
}
