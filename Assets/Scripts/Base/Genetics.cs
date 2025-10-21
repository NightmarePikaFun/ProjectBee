using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genetics 
{
    public float HealthMultplayer { get; private set; }
    public float ProductionMultiplayer { get; private set; }
    public float LifeTimeMultiplayer { get; private set; }

    public ActiveTemperature Temperature { get; private set; }
    public ActiveTime Time { get; private set; }
    public Flower Flower { get; private set; }


    public Genetics(float healthMultplayer, float productionMultiplayer, float lifeTimeMultiplayer)
    {
        HealthMultplayer = healthMultplayer;
        ProductionMultiplayer = productionMultiplayer;
        LifeTimeMultiplayer = lifeTimeMultiplayer;
    }
}

public enum ActiveTime
{
    Durnial,
    Nocturnal,
    Cathemerality
}

public enum ActiveTemperature
{
    Hot,
    Warm,
    Normal,
    Chilly,
    Cold
}

public enum Flower
{
    Red,
    Orange,
}
