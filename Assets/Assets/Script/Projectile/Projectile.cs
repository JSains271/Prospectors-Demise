using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float speed;
    private float travelDistance;
    private float xStartPos;

    [SerializeField]
    private float gravity;

    private Rigidbody2D rb;

    private bool isGravityOn;
    private bool hasHitGround;

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Transform damagePosition;

    public Stats stats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        stats= GetComponent<Stats>();

        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;

        isGravityOn = false;

        xStartPos = transform.position.x;
    }

    private void Update()
    {
        if (!hasHitGround)
        {

            if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        //attackDetails.damageAmount = damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Stats>().DecreaseHealth(10);
            Destroy(this.gameObject);
        }
    }
}