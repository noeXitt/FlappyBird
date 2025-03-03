using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private RawImage backgroundImage;
    [SerializeField] private float xAxis, yAxis;

    // Update is called once per frame
    [SerializeField]
    private void Update()
    {
        backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, backgroundImage.uvRect.size);
    }
}
