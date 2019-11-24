using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastReceiverMultimedia : MonoBehaviour, TimedInputHandler
{
    public Pointer _pointer;
    public MultimediaObject _multObj;
    public ClosePoint _closePoint;

    private Turn3DObjectToLeft _turnLeft;
    private Turn3DObjectToRight _turnRight;

    public MultimediaObject3D _mult3DObj;

    private EventTrigger _trigger;
    public int _sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        _pointer = GetComponentInChildren<Pointer>();
        _multObj = GetComponentInChildren<MultimediaObject>();

        _sceneNumber = GetComponentInParent<Scene>()._sceneNumber;
        _trigger = GetComponent<EventTrigger>();

        _closePoint = GetComponentInChildren<ClosePoint>();
        _turnLeft = GetComponentInChildren<Turn3DObjectToLeft>();
        _turnRight = GetComponentInChildren<Turn3DObjectToRight>();

        gameObject.tag = "Multimedia";
    }

    // Update is called once per frame
    void Update()
    {
        if(_multObj.GetMultimediaType() == "audio")
        {
            _closePoint.transform.position = _multObj.GetGlobalPosition();
            _closePoint.transform.localPosition = _multObj.GetUp(_closePoint.transform.localPosition);
        }
        else
        {
            _closePoint.transform.position = _multObj.GetGlobalPosition();
            _closePoint.transform.localPosition = _multObj.GetTopRightCorner(_closePoint.transform.localPosition);
        }
        if (_multObj.GetMultimediaType() == "3D")
        {
            _turnLeft.transform.position = _multObj.GetGlobalPosition();
            _turnLeft.transform.localPosition = _multObj.GetDownLeft(_turnLeft.transform.localPosition);

            _turnRight.transform.position = _multObj.GetGlobalPosition();
            _turnRight.transform.localPosition = _multObj.GetDownRight(_turnRight.transform.localPosition);
        }
    }

    public void HandleTimedInput()
    {
        AnimateIn();
    }

    public void AnimateIn()
    {
        _multObj.PullIn();
        _closePoint.Show();
        _multObj.PlayMultimedia();
        _pointer.PushOut();

        if (_turnLeft != null && _turnRight != null)
        {
            _turnLeft.Show();
            _turnRight.Show();
        }
    }
    public void AnimateOut()
    {
        _multObj.StopMultimedia();
        _closePoint.Hide();
        _multObj.PushOut();
        _pointer.PullIn();

        if (_turnLeft != null && _turnRight != null)
        {
            _turnLeft.Hide();
            _turnRight.Hide();
        }
    }

    public void ChangeVisibility(bool isVisible)
    {
        _trigger.enabled = isVisible;
        enabled = isVisible;
    }
}
