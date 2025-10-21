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
        Bee drone = new Bee(new Genetics(1, 1, 1));
        Bee queen = new Bee(new Genetics(1, 1, 1), true);
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
