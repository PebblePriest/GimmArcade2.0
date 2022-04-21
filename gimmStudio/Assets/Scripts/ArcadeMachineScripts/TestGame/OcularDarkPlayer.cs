using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OcularDarkPlayer : MonoBehaviour
{
        public VideoPlayer videoPlayer;
        public string videoUrl = "https://www.youtube.com/watch?v=nADTdV8wsXQ";

        // Start is called before the first frame update
        void Start()
        {
            videoPlayer.url = videoUrl;
            videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.Prepare();
        }

       
}
