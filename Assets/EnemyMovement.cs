using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyMovement : NetworkBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (!isServer)
        {
            return;
        }

        GameObject nearestPlayer = FindNearestPlayer();
        if (nearestPlayer != null)
        {
            Vector3 direction = (nearestPlayer.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    GameObject FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(player.transform.position, currentPosition);
            if (distance < minDistance)
            {
                nearestPlayer = player;
                minDistance = distance;
            }
        }

        return nearestPlayer;
    }
}
