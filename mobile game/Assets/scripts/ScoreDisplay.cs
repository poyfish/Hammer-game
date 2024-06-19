using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public ScoreManager ScoreManager;

    void Update()
    {
        Text.text = ScoreManager.Score.ToString();
    }
}
