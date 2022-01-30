using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 teamPos;

    [SerializeField]
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        teamPos = transform.position;
        teamPos.x = player.position.x;

        if (teamPos.x < minX) teamPos.x = minX;
        if (teamPos.x > maxX) teamPos.x = maxX;
        
        transform.position = teamPos;
    }
}
