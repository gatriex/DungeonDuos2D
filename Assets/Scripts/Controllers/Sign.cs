using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Sign : MonoBehaviour {

    //HIDE IN INSPECTOR
    [HideInInspector]
    public List<Element> _elementQueue = new List<Element>();

    //PUBLIC
    public List<string> messages;
    public Canvas canvas;
    public Steve steve;
    public Bob bob;

    //PRIVATE

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        Element.updateQueue(_elementQueue);
    }

    void OnTriggerStay2D(Collider2D other) {
       if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.L)) {
            Element.addElement(_elementQueue, new DialogueActivate(canvas));
            Element.addElement(_elementQueue, new DialogueText(messages, canvas));
            Element.addElement(_elementQueue, new DialogueDeactivate(canvas));
            //Element.addElement(bob._elementQueue, new DoNothing());
            //Element.addElement(steve._elementQueue, new DoNothing());
        }
    }
}