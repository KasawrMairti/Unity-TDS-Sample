using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : GameManager<UIManager>
{
    [SerializeField] private Transform damageTextCanvas;
    [SerializeField] private GameObject damageTextPrefab;

    private List<DamageIndicator> damageIndicators;

    protected override void Awake()
    {
        base.Awake();

        damageIndicators = new List<DamageIndicator>();

        DamageIndicator obj = Instantiate(damageTextPrefab).GetComponent<DamageIndicator>();
        obj.transform.SetParent(damageTextCanvas);
        obj.transform.localScale = new(1.0f, 1.0f, 1.0f);
        damageIndicators.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public void TextEnable(Vector2 pos, string txt, Color color)
    {
        bool enabled = false;

        foreach (DamageIndicator indicator in damageIndicators)
        {
            if (!indicator.gameObject.activeSelf)
            {
                indicator.gameObject.transform.position = pos;
                indicator.gameObject.SetActive(true);
                indicator.SetText(txt, color);

                enabled = true;
                break;
            }
        }

        if (enabled) return;

        DamageIndicator obj = Instantiate(damageTextPrefab).GetComponent<DamageIndicator>();
        obj.transform.SetParent(damageTextCanvas);
        obj.gameObject.transform.position = pos;
        obj.transform.localScale = new(1.0f, 1.0f, 1.0f);
        obj.SetText(txt, color);
        damageIndicators.Add(obj);
    }
}
