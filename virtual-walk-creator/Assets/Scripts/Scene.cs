using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public int _sceneNumber;
    private Vector3 _scenePosition;

    // Start is called before the first frame update
    void Start()
    {
        _scenePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetScenePosition()
    {
        return _scenePosition;
    }

    public int GetSceneNumber()
    {
        return _sceneNumber;
    }
}
