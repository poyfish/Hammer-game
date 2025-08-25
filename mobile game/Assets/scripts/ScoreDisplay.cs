using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI Text;

    void Update()
    {
        Text.text = Systems.ScoreManager.Score.ToString();
    }
}
