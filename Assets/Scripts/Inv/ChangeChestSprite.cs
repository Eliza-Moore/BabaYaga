using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeChestSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite spriteOn;
    public Sprite spriteOff;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer.sprite = spriteOff;
        }
    }

    public void Change()
    {
        if (spriteRenderer.sprite == spriteOff)
        {
            spriteRenderer.sprite = spriteOn;

        }
        else 
        {
            spriteRenderer.sprite = spriteOff;
        }
    }
}
