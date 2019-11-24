using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn3DObjectToLeft : Turn3DObject
{   
    public override void HandleInput()
    {
        _mult3DObj.RotateToLeft();
    }
}
