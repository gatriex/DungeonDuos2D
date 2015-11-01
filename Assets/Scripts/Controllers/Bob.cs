using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Bob : MonoBehaviour {

    //HIDE IN INSPECTOR
    [HideInInspector]
    public List<Element> _elementQueue = new List<Element>();

    //PUBLIC
    public Steve steve;
    public float speed = 5;
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";

    //PRIVATE
    private Animator anim;

    // Use this for initialization
    void Start() {
        Element.addElement(_elementQueue, new BobMovement(this));
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 0) {
            anim.SetInteger("isWalking", 1);
        } else {
            anim.SetInteger("isWalking", 0);
        }
        Element.updateQueue(_elementQueue);
    }
}