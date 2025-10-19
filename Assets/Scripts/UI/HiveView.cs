using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiveView : MonoBehaviour, IVisabilityUI
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => { Hide(); });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo(Hive hive)
    {

    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
    }
}

public interface IVisabilityUI
{
    abstract void Hide();
    abstract void Show();

}
