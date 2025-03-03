using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerBox : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject hpPanel;
    [SerializeField] private Slider slider;

    [SerializeField] private float hpMax;
    private float hp;

    private void Awake()
    {
        hp = hpMax;
        slider.value = hp / hpMax;
    }

    public void Damaged(float damaged)
    {
        if (!hpPanel.activeSelf)
            hpPanel.SetActive(true);

        hp -= damaged;

        if (hp > 0) slider.value = hp / hpMax;
        else
        {
            slider.value = 0.0f;

            gameObject.SetActive(false);
        }
    }
}
