using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genetics 
{
    public float HealthMultplayer { get; private set; }
    public float ProductionMultiplayer { get; private set; }
    public float LifeTimeMultiplayer { get; private set; }

    public Temperature Temperature { get; private set; }
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
    Cathemerality,
    None
}

public enum Temperature
{
    Hot,
    Warm,
    Normal,
    Chilly,
    Cold,
    None
}

public enum Flower
{
    Red,
    Orange,
    None
}

public enum Weather
{
    Sunny,
    Rainy,
    Snowy,
    Foggy,
    None
}

public enum Humidity
{
    None
}