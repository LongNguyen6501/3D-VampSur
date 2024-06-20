using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    public int XPGained = 1;

    private UnityEngine.AI.NavMeshAgent navAgent;

    public Rigidbody zombieBody;

    public float speed = 6f;
    public float enemyDamage;
    public float range;

    public bool readyToHit = true;
    bool allowReset = true;
    public float hittingDelay = 0.5f;

    public Transform player;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgent.speed = speed;
    }

    void Update()
    {
        navAgent.SetDestination(player.position);
        float distanceFromPlayer = Vector3.Distance(player.position, zombieBody.transform.position);
        if (distanceFromPlayer <= range && readyToHit == true)
        {
            Attack();
        }
    }

    private void Attack()
    {
        readyToHit = false;
        player.GetComponent<PlayerHP>().TakeDamage(enemyDamage);
        if (allowReset)
        {
            Invoke("ResetHit", hittingDelay);
            allowReset = false;
        }
    }

    private void ResetHit()
    {
        readyToHit = true;
        allowReset = true;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            player.GetComponent<PlayerHP>().AddXP(XPGained);
            Destroy(gameObject);
        }
    }
}
