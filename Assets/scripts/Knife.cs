﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;
    private bool isActive=true;
    private Rigidbody2D rb;//control physics
    private BoxCollider2D knifeCollider;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }
    private void Update(){
        if(Input.GetMouseButtonDown(0) && isActive){
            rb.AddForce(throwForce,ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(!isActive)
            return;
        isActive=false;
        if(collisionInfo.collider.tag=="coin"){
            rb.velocity = new Vector2(0,0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collisionInfo.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x,-0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x,1.2f);
        }else if(collisionInfo.collider.tag=="knife1"){
            rb.velocity=new Vector2(rb.velocity.x,-2);
        }
    }
    
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
