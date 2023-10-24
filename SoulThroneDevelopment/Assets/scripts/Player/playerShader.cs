using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShader : MonoBehaviour
{
    public SpriteRenderer characterRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Color colorTint = new Color(0.7f, 0.7f, 0.7f);
        characterRenderer.color = colorTint;
    }
}
