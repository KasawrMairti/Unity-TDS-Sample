using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    private float timeLimitMax = 3.0f;
    private float timeLimit = 0.0f;

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        timeLimit = 0.0f;
        text.color = new(text.color.r, text.color.g, text.color.b, 1.0f);
    }

    private void Update()
    {
        if (timeLimit < timeLimitMax)
        {
            timeLimit += Time.deltaTime;

            transform.Translate(Vector2.up * 1.0f * Time.deltaTime);
            text.color = Color.Lerp(text.color, new(text.color.r, text.color.g, text.color.b, 0.0f), Time.deltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        } 
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
