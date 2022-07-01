using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>{}
public class MouseManager : MonoBehaviour
{
    RaycastHit hitInfo; // 用来保存射线碰撞到的物体的相关信息

    public EventVector3 onMouseClicked;

    private void Update()
    {
        SetCursorTexture();
        MouseControl();
    }

    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitInfo))
        {
            // 切换鼠标贴图
        }
    }

    void MouseControl()
    {
        if(Input.GetMouseButtonDown(0)&& hitInfo.collider != null)
        {
            if(hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                onMouseClicked?.Invoke(hitInfo.point);
            }
        }    
    }
}
