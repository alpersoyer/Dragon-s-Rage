using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToken : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    public void OnMouseDown()
    {
        if (matched == false)
        {
            GameControl controlScript = gameControl.GetComponent<GameControl>();

            if (spriteRenderer.sprite == back) // Kartın arkası görünüyorsa
            {
                if (controlScript.TokenUp(this))
                {
                    spriteRenderer.sprite = faces[faceIndex]; // Kartın yüzünü göster
                    transform.localScale = new Vector3(1.2f, 1.2f, 1); // %20 büyüt
                    controlScript.CheckTokens();
                }
            }
            else // Kartın yüzü görünüyorsa
            {
                spriteRenderer.sprite = back; // Kartın arkasını göster
                transform.localScale = new Vector3(0.625f, 0.625f, 1); // Orijinal boyuta geri dön
                controlScript.TokenDown(this);
            }
        }
    }

    private void Awake()
    {
        gameControl = GameObject.Find("GameControl");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
