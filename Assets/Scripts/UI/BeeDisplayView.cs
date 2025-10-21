using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDisplayView : MonoBehaviour, IVisabilityUI
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private BeeElementView prefab;
    [SerializeField]
    private Transform parent;

    private List<BeeElementView> elements;
    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
    }

    public void Construct(List<Bee> bees)
    {
        if(elements == null)
            elements = new List<BeeElementView>();
        ClearData();
        foreach(var bee in bees)
        {
            BeeElementView view = Instantiate(prefab, parent);
            view.Construct(bee, () =>
            {
                HiveModel.AddBee(bee);
            });
            elements.Add(view);
        }
    }

    public void ClearData()
    {
        foreach(var item in elements)
        {
            Destroy(item.gameObject);
        }
        elements.Clear();
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
