using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPreview : MonoBehaviour
{
    SpriteRenderer spriteRend;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void ChangeSprite(Sprite s)
    {
        spriteRend.sprite = s;
    }
}
