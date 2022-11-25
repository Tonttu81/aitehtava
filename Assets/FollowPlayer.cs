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
        if (Physics.Linecast(transform.position, player.transform.position, out hit, obstacleLayer)) // Jos pelaajan ja vihollisen välissä on seinä
        {
            navMeshAgent.destination = player.transform.position; // seuraa pelaajaa
        }
        else // jos ei ole esteitä
        {
            if (enemyRenderer.isVisible) // ja jos pelaaja näkee vihollisen
            {
                navMeshAgent.destination = transform.position; // vihollinen lopettaa liikkumisen
            }
            else
            {
                navMeshAgent.destination = player.transform.position; // ja jos pelaaja ei näe sitä, se liikkuu
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
