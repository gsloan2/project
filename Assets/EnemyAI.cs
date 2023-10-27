using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    public Transform targetPlayer;
    private float range;
    // Start is called before the first frame update
    void Start()
    {
        range = 50;
        targetPlayer = Player.Instance.getPlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        targetPlayer = Player.Instance.getPlayerPosition();
        //check if player is within range
        if (Vector2.Distance(transform.position, targetPlayer.position) < range)
        {
            //if player is in range go torwards it
        }
    }
}
