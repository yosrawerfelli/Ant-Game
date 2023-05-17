using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
   Material mat;
   float distance;
   Transform cam;

   [Range(0f,0.5f)]
   public float speed=0.2f;

   private void Start() 
   {
    mat = GetComponent<Renderer>().material;
    cam = Camera.main.transform;
   }
   private void Update() 
   {
    distance += Time.deltaTime * speed;
    mat.SetTextureOffset("_MainTex", Vector2.right * distance);
   }

   private void LateUpdate() 
   {
      transform.position = new Vector3(cam.position.x, cam.position.y,0);
   }
}
