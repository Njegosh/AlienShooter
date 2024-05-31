using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FocusThis : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject focus;

    void Start()
    {
        Focus();
    }

    public void Focus(){
        EventSystem.current.SetSelectedGameObject(focus);
    }
}
