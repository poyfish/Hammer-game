using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPlayer : MonoBehaviour
{
    public UnityEvent Event;


    [Button("Play event", EButtonEnableMode.Playmode)]
    public void PlayEvent()
    {
        Event.Invoke();
    }
}
