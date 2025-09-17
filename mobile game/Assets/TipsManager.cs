using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tipsTextObject;

    void Start()
    {
        tipsTextObject.enabled = false;
        tipsTextObject.faceColor = Color.red;
    }

    void ShowTip(string tip)
    {

    }
}
