using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveChunk : MonoBehaviour, ITick
{
    [SerializeField]
    private Temperature chunkTemperature;
    [SerializeField]
    private Humidity chunkHumidity;
    [SerializeField]
    private Weather chunkWeather;

    [SerializeField]
    private List<Upgrades> upgrades = new List<Upgrades>();

    [SerializeField]
    private List<HiveObject> hiveObjects;
    public void LiveTick(WeatherData weather)
    {
        //Add upgrades on weather bees etc
        foreach(var hive in hiveObjects)
        {
            hive.LiveTick(weather);
        }
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
