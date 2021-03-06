﻿using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Steve : MonoBehaviour {

    //HIDE IN INSPECTOR
    [HideInInspector]
    public List<Element> _elementQueue = new List<Element>();

    //PUBLIC
    public Bob bob;
    public float speed = 5;
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";

    //PRIVATE

    // Use this for initialization
    void Start() {
        //Element.addElement(_elementQueue, new SteveMovement(this));
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        Element.updateQueue(_elementQueue);
    }
}