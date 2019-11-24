using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultimediaObject3D : MultimediaObject
{
    public Turn3DObjectToLeft _turnLeft;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _closePoint = GetComponent<ClosePoint>();
        //_raycastReceiver = GetComponentInParent<RaycastReceiverMultimedia>();
        _turnLeft = GetComponent<Turn3DObjectToLeft>();
        //sceneNumber = GetComponentInParent<Scene>()._sceneNumber;

        _multimediaType = "3D";
        minScale = transform.localScale;
        maxScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void RotateToLeft()
    {
        transform.Rotate(0, 1, 0);
    }
    
    public override void RotateToRight()
    {
        transform.Rotate(0, -1, 0);
    }
}
