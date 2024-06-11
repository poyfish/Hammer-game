using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float TimeScale;

    public void Apply()
    {
        Time.timeScale = TimeScale;
    }
}
