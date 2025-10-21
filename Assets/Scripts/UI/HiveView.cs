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
    private HiveSlot mainComb;
    [SerializeField]
    private List<HiveSlot> otherCombs;
    [SerializeField]
    private BeeDescriptionView beeDescriptionView;
    [SerializeField]
    private BeeDisplayView beeDisplayView;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => { Hide(); HiveModel.ResetHive(); });
        HiveModel.View = this;
    }

    public void UpdateInfo(Hive hive)
    {
        beeDescriptionView.Hide();
        beeDisplayView.Hide();
        int beeCount = hive.ContainBee();
        if (hive.BeeQueen != null)
        {
            ShowAllSlot(hive);
        }
        else if(beeCount == 0)
        {
            ShowQueenComb();
        }
        else if(beeCount < 2)
        {
            ShowDroneComb();
        }
    }

    public void ShowAllSlot(Hive hive)
    {
        foreach(var item in otherCombs)
        {
            item.Hide();
            item.SetListener(ShowBeeDescription);
        }
        queenComb.Hide();
        queenComb.SetListener(ShowBeeDescription);
        droneComb.Hide();
        droneComb.SetListener(ShowBeeDescription);
        mainComb.Hide();
        mainComb.Construct(hive.BeeQueen);
        mainComb.SetListener(ShowBeeDescription);
    }

    public void ShowBeeDescription()
    {
        beeDescriptionView.Show();
    }

    public void ShowQueenComb()
    {
        queenComb.Hide();
        beeDisplayView.Construct(GameController.Instance.Player.Queens);
        //Add to queen and drone separate because player change one of this
        queenComb.SetListener(beeDisplayView.Show);
    }

    public void ShowDroneComb()
    {
        queenComb.Hide();
        queenComb.SetListener(ShowBeeDescription);
        droneComb.Hide();
        beeDisplayView.Construct(GameController.Instance.Player.Drones);
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
