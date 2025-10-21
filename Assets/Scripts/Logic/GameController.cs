using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField]
    private List<Hive> hives;

    public PlayerData Player {  get; private set;}

    public void Construct()
    {
        Player = new PlayerData("PikaFun");

        //TODO is tmp
        Bee drone = new Bee(new Genetics(1, 4, 2), Color.red);
        Bee queen = new Bee(new Genetics(2, 1, 3), new Color(0.01f, 0.01f, 0.01f, 1) ,true);
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private IEnumerator HiveTiker()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(8);
            foreach (var hive in hives)
            {
                hive.Production();
                hive.LifeCycle();
            }
            //Tick 
        }
    }
}
