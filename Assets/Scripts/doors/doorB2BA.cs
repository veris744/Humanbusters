using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorB2BA : doorCanvas
{
    private GameObject player;
    private GameObject mainCamera;
    private bool timeIsPassed;

    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeRoom();
        }
    }

    private void changeRoom()
    {
        if (Vector2.Distance(player.transform.position, new Vector2(28.75f, -14f)) < 0.5)
        {
            mainCamera.transform.position = new Vector3(45.6f, 0, -10);
            player.transform.position = new Vector3(41f, -1.5f, 0);
            player.GetComponent<Rigidbody2D>().AddForce(30f * Vector2.up);
        }
    }
}
