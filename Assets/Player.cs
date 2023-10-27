using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public static Player Instance { get; private set; }

    Transform playerPos;
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GetComponent<Transform>();
    }


    public Transform getPlayerPosition()
    {
        return playerPos;
    }
}
