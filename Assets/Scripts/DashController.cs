using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    PlayerMovement player_control;

    private void Awake()
    {
        player_control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
