using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCanvas : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public bool HideByDefault;

    private void Start()
    {
        if (HideByDefault)
        {
            HideCanvas();
        }
    }
    public void ShowCanvas()
    {
        canvasGroup.alpha = 1;
        canvas.sortingOrder = 1;
    }
    public void HideCanvas()
    {
        canvasGroup.alpha = 0;
        canvas.sortingOrder = 0;
    }
}
