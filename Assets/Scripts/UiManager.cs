using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance { get { return _instance; } }
    private static UiManager _instance = null;

    [SerializeField]
    public Joystick joystick = null;
  


    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
