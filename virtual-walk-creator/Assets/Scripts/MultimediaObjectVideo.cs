using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultimediaObjectVideo : MultimediaObject
{
    private GameObject _camera;
    private RectTransform _rectTrans;
    public UnityEngine.Video.VideoPlayer _videoPlayer;
    public string filename;

    private float timer;
    private float timeToWait = 1;
    private int counter;
    private int lastFrame;
    private string url;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        //_raycastReceiver = GetComponentInParent<RaycastReceiverMultimedia>();
        _closePoint = GetComponent<ClosePoint>();
        minScale = transform.localScale;
        _multimediaType = "video";

        counter = 0;
        timer = 0;
        SetColor();

        _videoPlayer.playOnAwake = false;

        _videoPlayer.loopPointReached += PushOutIfVideoIsFinished;
    }

    // Update is called once per frame
    void Update()
    {
        //PushOutIfVideoIsFinished();
    }
  
    public override void PlayMultimedia()
    {
        if (string.IsNullOrEmpty(url))
        {
            url = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
            Debug.Log(url);
        }

        _videoPlayer.url = url;
        //_videoPlayer.SetTargetAudioSource(0, audioSource);
       
        //_videoPlayer.frame = 0;
        _videoPlayer.Play();
    }
    public override void StopMultimedia()
    {
        _videoPlayer.Pause();
    }
    public void PushOutIfVideoIsFinished(UnityEngine.Video.VideoPlayer vp)
    {
        _raycastReceiver.AnimateOut();
        _videoPlayer.frame = 0;
    }
}
