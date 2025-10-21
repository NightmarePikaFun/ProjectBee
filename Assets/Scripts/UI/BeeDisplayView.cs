using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDisplayView : MonoBehaviour, IVisabilityUI
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
