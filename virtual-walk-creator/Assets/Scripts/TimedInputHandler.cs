using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public interface TimedInputHandler : IEventSystemHandler
{
    void HandleTimedInput();
}