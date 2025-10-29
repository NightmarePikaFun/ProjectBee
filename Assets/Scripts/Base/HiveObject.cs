using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HiveObject : MonoBehaviour, IPointerClickHandler, ITick, IUpgrades
{
    private Hive _hive;
    private bool _state;

    private List<Upgrade> upgrades;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                GameController.Instance.Player.AddHoney(_hive.CollectHoney());
                Debug.Log("L+D");
                break;
            case PointerEventData.InputButton.Right:
                HiveModel.Hive = _hive;
                ControllerUI.Instance.ShowHiveView(_hive);
                Debug.Log("R+D");
                break;
        }
    }

    public void LiveTick(WeatherData weather)
    {
        if (!_state)
            return;
        _hive.LiveTick(weather);
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        _hive.AddUpgrade(upgrade);
    }

    public void RemoveUpgrade(Upgrade upgrade)
    {
        _hive.RemoveUpgrade(upgrade);
    }
}
