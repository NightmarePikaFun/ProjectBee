using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveChunk : MonoBehaviour, ITick, IUpgrades
{
    [SerializeField]
    private Temperature chunkTemperature;
    [SerializeField]
    private Humidity chunkHumidity;
    [SerializeField]
    private Weather chunkWeather;

    [SerializeField]
    private List<Upgrade> upgrades = new List<Upgrade>();

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

    public void AddUpgrade(Upgrade upgrade)
    {
        upgrades.Add(upgrade);
        foreach (var hive in hiveObjects)
        {
            hive.AddUpgrade(upgrade);
        }
    }

    public void RemoveUpgrade(Upgrade upgrade)
    {
        if (upgrades.Contains(upgrade))
        {
            upgrades.Remove(upgrade);
            foreach (var hive in hiveObjects)
            {
                hive.RemoveUpgrade(upgrade);
            }
        }
    }
}
