using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] LayerMask obstacleLayer;

    NavMeshAgent navMeshAgent;
    Renderer enemyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position, player.transform.position, out hit, obstacleLayer)) // Jos pelaajan ja vihollisen v�liss� on sein�
        {
            navMeshAgent.destination = player.transform.position; // seuraa pelaajaa
        }
        else // jos ei ole esteit�
        {
            if (enemyRenderer.isVisible) // ja jos pelaaja n�kee vihollisen
            {
                navMeshAgent.destination = transform.position; // vihollinen lopettaa liikkumisen
            }
            else
            {
                navMeshAgent.destination = player.transform.position; // ja jos pelaaja ei n�e sit�, se liikkuu
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }
}
