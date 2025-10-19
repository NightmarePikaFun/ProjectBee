using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tmp : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Transform cube;
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Button btn;

    private Vector3 startPoint;
    private Tween tween;

    private Hive hive;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = cube.position;
        image.enabled = false;
        btn.onClick.AddListener(() => { ButtonAction(!image.enabled); });

        hive = new Hive(7);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void ButtonAction(bool state)
    {
        if (state)
        {
            tween = cube.DOMoveY(startPoint.y + 2, 1, false).SetLoops(-1, LoopType.Yoyo);

        }
        else
        {
            if(tween != null)
                tween.Kill();
            cube.position = startPoint;
        }

        image.enabled = state;
    }

    private void OnMouseDown()
    {
        

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button) {
            case PointerEventData.InputButton.Left:
                Debug.Log("L+D");
                break;
            case PointerEventData.InputButton.Right:
                ControllerUI.Instance.ShowHiveView(hive);
                Debug.Log("R+D");
                break;
        }
        if (Input.GetMouseButtonDown(0))
            
        if (Input.GetMouseButtonDown(1))
        {
            //
           
        }
    }
}
