using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastReceiverPointer : MonoBehaviour, TimedInputHandler
{
  
    public Pointer _pointer;
    public GameObject _cameraMove;

	private Camera m_MainCamera;
    public  MainCamera _mainCamera;

    private EventTrigger _trigger;
    public int _sceneNumber;

    // Start is called before the first frame update
    void Start()
    {

        Scene[] scenes = GameObject.FindObjectsOfType<Scene>();
        _mainCamera = GameObject.FindObjectOfType<MainCamera>();
        _pointer = GetComponentInChildren<Pointer>();
        //if (_cameraMove != null)
        //    _mainCamera = _cameraMove.GetComponentInChildren<MainCamera>();

        _sceneNumber = GetComponentInParent<Scene>()._sceneNumber;
        _trigger = GetComponentInParent<EventTrigger>();

        gameObject.tag = "Pointer";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HandleTimedInput()
    {
        if (_mainCamera != null)
        {
            _mainCamera.MoveCamera(_pointer.index);
        }
    }
    public void ChangeVisibility(bool isVisible)
    {
        _trigger.enabled = isVisible;
        enabled = isVisible;
    }
}
