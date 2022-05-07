using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCubeScript : MonoBehaviour, IPooledObject
{
    Vector3 direction;
    Camera cam;
    float nextShoot, fireRate, speed = 200f;
    Rigidbody rigidbody;
    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        fireRate = 0.3f;
    }
    //void FixedUpdate()
    //{
    //    
    //}
    public void TakeDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    public void OnObjectSpawn()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextShoot)
        {
            nextShoot = Time.time + fireRate;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //throw knife
                Debug.Log("Shooting to " + hit.point + " vector");
                rigidbody.velocity = hit.point;
                //transform.Translate(hit.point, Space.Self);
                //rigidbody.AddForce(hit.point * speed * Time.deltaTime);
                //rigidbody.MovePosition(hit.point * Time.deltaTime);
                if (false)
                {
                    //move forward
                }
            }
        }
    }
}
