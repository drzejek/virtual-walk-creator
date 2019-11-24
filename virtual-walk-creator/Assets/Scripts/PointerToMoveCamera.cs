using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerToMoveCamera : Pointer
{

    void Start()
    {
        //positionIn = transform.localPosition;
        _rend = GetComponent<Renderer>();
        _rend.material.color = new Color(1, 0, 0, 0.5f);
    }
}
