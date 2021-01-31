using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    public Rigidbody2D farBuildings;
    public Rigidbody2D mostFarBuildings;
    public Rigidbody2D sky;

    private PlayerMovementController moveCtrl;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        moveCtrl = GameSystem.instance.player.GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = -moveCtrl.GetSpeed().x;
        farBuildings.velocity = new Vector3(speed / 8, 0f, 0f);
        mostFarBuildings.velocity = new Vector3(speed / 10, 0f, 0f);
        sky.velocity = new Vector3(-0.1f, 0f, 0f);
    }
}
