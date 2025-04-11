using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Transform playerPos;
    public Transform ObstaclePos;
    private Rigidbody rb;
    [SerializeField] private GameObject UIRestart;

    public ParticleSystem part;


    private PlayerMove PlayerMove;
    public GameObject player;
    void Start()
    {
        
        part = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        PlayerMove = player.GetComponent<PlayerMove>();
    }
    
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("Character"))
        {
            Vector3 rayDirection = playerPos.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirection, out hit, 40f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                // hit.rigidbody.AddExplosionForce(explosionForce, gameObject.transform.position, radius, 1, ForceMode.Impulse);
                if (hit.collider.CompareTag("Character"))//player detector
                {
                    Debug.Log("ouch");
                    PlayerMove.PlayerDeath();
                    UIRestart.SetActive(true);


                    // player.SetActive(false);
                    //  HealthScriptRef.Health = HealthScriptRef.Health - (100 - (hit.distance * 2));
                }


            }

        }

        if (other.tag.Equals("PushedObstacle"))
        {
            Vector3 rayDirectionToObstacle = ObstaclePos.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirectionToObstacle, out hit, 40f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
                // hit.rigidbody.AddExplosionForce(explosionForce, gameObject.transform.position, radius, 1, ForceMode.Impulse);
                if (hit.collider.CompareTag("PushedObstacle"))//player detector
                {
                    Debug.Log("ObstacleDestroyed");
                    Destroy(hit.collider.gameObject, 5f);
                    // player.SetActive(false);
                    //  HealthScriptRef.Health = HealthScriptRef.Health - (100 - (hit.distance * 2));
                }


            }

        }
    }

    IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);

    }

}
