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
    [SerializeField]
    private HiveSlot queenComb;
    [SerializeField]
    private HiveSlot droneComb;
    [SerializeField]
    private List<HiveSlot> otherCombs;
    [SerializeField]
    private BeeDescriptionView beeDescriptionView;
    [SerializeField]
    private BeeDisplayView beeDisplayView;

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
        if(hive.ContainBee())
        {
            ShowAllSlot();
            /*if(true)//contains only queen)
            {
                ShowDroneComb();
            }*/
        }
        else
        {
            ShowQueenComb();
        }
    }

    public void ShowAllSlot()
    {
        foreach(var item in otherCombs)
        {
            item.Hide();
            item.SetListener(ShowBeeDescription);
        }
        queenComb.SetListener(ShowBeeDescription);
        droneComb.SetListener(ShowBeeDescription);
    }

    public void ShowBeeDescription()
    {
        beeDescriptionView.Show();
    }

    public void ShowQueenComb()
    {
        queenComb.Hide();
        queenComb.SetListener(beeDisplayView.Show);
    }

    public void ShowDroneComb()
    {
        droneComb.Hide();
        droneComb.SetListener(beeDisplayView.Show);
    }

    public void Hide()
    {
        Debug.Log("+");
        beeDisplayView.Hide();
        beeDescriptionView.Hide();
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
