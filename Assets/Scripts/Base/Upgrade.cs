using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    public readonly string upgradeName;
    public readonly Sprite upgradeSprite;
}

public class WeatherUpgrade : Upgrade
{
    public readonly Weather weather = Weather.None;
    public readonly Temperature temperature = Temperature.None;
    public readonly Flower flower = Flower.None;
    public readonly ActiveTime activeTime = ActiveTime.None;
}

public class GeneticsUpgrade : Upgrade
{
    public readonly float productionMultiplayer = 0;
    public readonly float liveMultiplayer = 0;
}

