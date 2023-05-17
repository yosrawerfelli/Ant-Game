using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObjects : MonoBehaviour
{
    [SerializeField] private Transform CarryPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    private int layerMask;

    private GameObject CarryObject;
    //private int layerIndex;

    // Start is called before the first frame update
    void Start()
    {
        //layerIndex = LayerMask.NameToLayer("Objects");
        layerMask = LayerMask.GetMask("BigObjects");
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, -Vector2.right * transform.localScale, rayDistance,layerMask);
        
        if (hitInfo.collider!=null && hitInfo.collider.tag == "BigGrain")
        {
            //Carry object
            if (Input.GetKeyDown(KeyCode.R) && CarryObject == null)
            {
                CarryObject = hitInfo.collider.gameObject;
                CarryObject.GetComponent<Rigidbody2D>().isKinematic = true;
                CarryObject.transform.position = CarryPoint.position;
                CarryObject.transform.SetParent(transform);


            }
            //release object
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("it works");
                CarryObject.GetComponent<Rigidbody2D>().isKinematic = false;
                CarryObject.transform.SetParent(null);
                CarryObject = null;
            }
        
        }
        Debug.DrawRay(rayPoint.position, -Vector2.right * transform.localScale* rayDistance);
        /*if (hitInfo.collider!=null && hitInfo.collider.tag == "BigGrain")
        {
            Debug.Log("it works");
        }*/
        
    }
}
