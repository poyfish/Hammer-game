using System.Collections;
using UnityEngine;
using TMPro;

public class TipsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tipsTextObject;
    public Color textColor;
    public float fadeTime = 1f;

    public void ShowTip(string tip)
    {
        StopAllCoroutines();

        Color c = textColor;
        c.a = 1f;
        tipsTextObject.color = c;

        tipsTextObject.text = tip;
        StartCoroutine(FadeOutTip());
    }

    private IEnumerator FadeOutTip()
    {
        Color c = tipsTextObject.color;

        float elapsed = 0f;
        while (elapsed < fadeTime)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(1f - (elapsed / fadeTime));
            c.a = alpha;
            tipsTextObject.color = c;
            yield return null;
        }

        c.a = 0f;
        tipsTextObject.color = c;
    }
}
