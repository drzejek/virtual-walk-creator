using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public interface InputHandler : IEventSystemHandler
{
    void HandleInput();
}