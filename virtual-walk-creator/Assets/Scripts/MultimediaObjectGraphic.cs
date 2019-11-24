using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultimediaObjectGraphic : MultimediaObject
{
    private GameObject _camera;
    private RectTransform _rectTrans;
    //private RaycastReceiverMultimedia _raycastReceiver;

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
        //sceneNumber = GetComponentInParent<Scene>()._sceneNumber;

        _multimediaType = "graphic";
        minScale = transform.localScale;
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        //PushOutIfVideoIsFinished();
    }
  
    public void PushOutIfVideoIsFinished(UnityEngine.Video.VideoPlayer vp)
    {
        _raycastReceiver.AnimateOut();
    }
}
