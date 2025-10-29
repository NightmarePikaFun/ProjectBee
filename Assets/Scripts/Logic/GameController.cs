using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField]
    private List<HiveChunk> chunks;

    public PlayerData Player {  get; private set;}

    public void Construct()
    {
        Player = new PlayerData("PikaFun");

        //TODO is tmp
        Bee drone = new Bee(new Genetics(1, 4, 2), Color.red);
        Bee queen = new Bee(new Genetics(2, 1, 3), new Color(0.1f, 0.1f, 0.1f, 1) ,true);
        Player.AddBee(drone);
        Player.AddBee(queen);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    private IEnumerator HiveTiker()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(8);
            foreach (var chunk in chunks)
            {
                var item = chunk as ITick;
                item.LiveTick(new WeatherData());
            }
            /*foreach (var hive in hives)
            {
                hive.Production();
                hive.LifeCycle();
                HiveModel.UpdateView();
            }*/
            //Tick 
        }
    }
}


public interface ITick
{
    public void LiveTick() =>  throw new System.NotImplementedException();
    public void LiveTick(WeatherData data) => throw new System.NotImplementedException();
}

public interface IUpgrades
{
    public abstract void AddUpgrade(Upgrade upgrade);
    public abstract void RemoveUpgrade(Upgrade upgrade);
}

public class WeatherData
{
    //TODO TMP 
}