using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI Text;

    private ScoreManager ScoreManager;

    private void Start()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        Text.text = ScoreManager.Score.ToString();
    }
}
