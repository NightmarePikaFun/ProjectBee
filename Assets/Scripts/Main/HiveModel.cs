using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HiveModel
{
    public static Hive Hive;
    public static HiveView View;
    public static void AddBee(Bee bee)
    {
        if (Hive.AddBee(bee))
        {
            GameController.Instance.Player.RemoveBee(bee);
            View.UpdateInfo(Hive);
        }

    }
}
