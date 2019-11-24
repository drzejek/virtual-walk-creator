using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultimediaObjectAudio : MultimediaObject
{
    public AudioSource _audioSource;
    private AudioClip Stem1Clip;
    public string filename;
    //private RaycastReceiverMultimedia _raycastReceiver;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        //_raycastReceiver = GetComponentInParent<RaycastReceiverMultimedia>();
        //sceneNumber = GetComponentInParent<Scene>()._sceneNumber;
        minScale = transform.localScale;
        maxScale = minScale;
        _audioSource.enabled = false;
        _multimediaType = "audio";
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (_audioSource != null && _audioSource.time >= _audioSource.clip.length)
        {
            PushOutIfAudioIsFinished();
        }
        */
    }

    public override void PlayMultimedia()
    {
        _audioSource.enabled = true;
    }
    public override void StopMultimedia()
    {
        _audioSource.enabled = false;
    }
    public void PushOutIfAudioIsFinished()
    {
        _raycastReceiver.AnimateOut();
    }

}
