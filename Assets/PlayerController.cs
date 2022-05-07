using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public List<Transform> movePositions = new List<Transform>();
    public NavMeshAgent myNavMeshAgent;
    int positionIndex;
    float nextShoot, fireRate, timeToMove, moveRate;
    ContactDetector1 contactDetector1;
    public GameObject contactDetector1GO;
    //public List<GameObject> knifes = new List<GameObject>();
    public GameObject knife, startPosDetectorGO;
    StartPosDetector startPosDetector;
    //public Camera cam;
    ObjectPooler objectPooler;
    private void Awake()
    {
        contactDetector1 = contactDetector1GO.GetComponent<ContactDetector1>();
        startPosDetector = startPosDetectorGO.GetComponent<StartPosDetector>();
        
    }
    void Start()
    {
        positionIndex = 0;
        nextShoot = 0f;
        timeToMove = 0f;
        moveRate = 3f;
        //fireRate = 0.3f;
        //for (int i = 0; i < 100; i++)
        //{
        //    knifes.Add(knife);
        //    knifes[i].SetActive(false);
        //}
        objectPooler = ObjectPooler.Instance;
    }
    void FixedUpdate()
    {
        if (!contactDetector1.isReached1)
        {
            //Debug.Log("Not reached");
            MovePlayer();
        }
        if (contactDetector1.isReached1)
        {
            Shoot();
        }
    }
    void MovePlayer()
    {
        if (startPosDetector.isShootingTime)
        {
            Shoot();
            return;
        }
        if(Input.GetKey(KeyCode.Mouse0) && Time.time > timeToMove)
        {
            timeToMove = Time.time + moveRate;
            myNavMeshAgent.SetDestination(movePositions[positionIndex].position);
            if (positionIndex < 2)
            {
                positionIndex++;
            }
        }
    }
    void Shoot()
    {
        objectPooler.SpawnFromPool("Knife", transform.position, Quaternion.identity);
        //if(Input.GetKey(KeyCode.Mouse0) && Time.time > nextShoot)
        //{
        //    nextShoot = Time.time + fireRate;
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        //throw knife
        //        Debug.Log("Shooting");
        //    }
        //    IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        //    if (pooledObj != null)
        //    {
        //        pooledObj.OnObjectSpawn();
        //    }
        //}
    }
}
