using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Actions")]
    public static Action onFruitClicked;
    public static Action<Vector2> onFruitClickedPosition;
    


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            ManageTouch();
        }
        //if (Input.GetMouseButtonDown(0))
        //    ThrowRaycast();
    }


    private void ManageTouch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                ThrowRaycast(touch.position);
            }
        }
    }


    void ThrowRaycast(Vector2 touchPosition)
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(touchPosition));

        if (hit.collider == null)
            return;
        onFruitClicked?.Invoke();
        onFruitClickedPosition?.Invoke(hit.point);
        //Debug.Log("Hit: " + hit.collider.gameObject.name);

    }
}
