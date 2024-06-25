using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable : MonoBehaviour
{
    public string SaveKey;

    public int Cost;

    public GameObject offer;
    public GameObject bought;

    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        bought.SetActive(false);
        offer.SetActive(true);

        if(PlayerPrefs.GetInt(SaveKey) == 1) Buy();
    }

    private void Reset()
    {
        PlayerPrefs.SetInt(SaveKey, 0);
    }

    public void TryBuy()
    {
        if (scoreManager.Score >= Cost)
        {
            PlayerPrefs.SetInt(SaveKey, 1);
            PlayerPrefs.Save();

            scoreManager.RemoveScore(Cost);

            Buy();
        }
    }

    public void Buy()
    {
        bought.SetActive(true);
        offer.SetActive(false);
    }
}
