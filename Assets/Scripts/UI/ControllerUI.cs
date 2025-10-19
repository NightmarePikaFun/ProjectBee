using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUI : MonoBehaviour
{
    public static ControllerUI Instance { get; private set; }

    [SerializeField]
    private HiveView hiveView;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHiveView(Hive hive)
    {
        hiveView.Show();
        hiveView.UpdateInfo(hive);
    }
}
