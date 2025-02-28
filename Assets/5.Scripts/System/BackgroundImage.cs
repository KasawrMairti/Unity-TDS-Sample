using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    private float moveSpeed = 0.75f;

    [SerializeField] private SpriteRenderer nextImage;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 이미지 일정 거리이상 지나가면 순환시켜 무한정 이동하는 느낌을 구현
        if (transform.position.x < -spriteRenderer.bounds.size.x)
        {
            transform.position = new Vector3(nextImage.bounds.size.x + (nextImage.transform.position.x * 0.5f) - 0.05f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
