using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiveSlot : MonoBehaviour, IVisabilityUI
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image beeImage;
    [SerializeField]
    private Image closedImage;
    public void Hide()
    {
        closedImage.enabled = false;
    }

    public void Show()
    {
        closedImage.enabled = true;
    }

    public void Construct(Bee bee)
    {
        beeImage.color = bee.BeeColor;
    }

    public void SetListener(Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(()=> { action?.Invoke(); });
    }
    // Start is called before the first frame update
    void Start()
    {
        //button.onClick.AddListener(() => { Debug.Log("Clicked on " + gameObject.name); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
