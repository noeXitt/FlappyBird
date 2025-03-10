using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    Renderer xD;
    [SerializeField] Vector2 velocidad;

    // Start is called before the first frame update
    void Start()
    {
        xD = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xD.material.mainTextureOffset += velocidad * Time.deltaTime;
    }
}
