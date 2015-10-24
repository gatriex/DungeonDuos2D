using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    //HIDE IN INSPECTOR
    [HideInInspector]
    public List<Element> _elementQueue = new List<Element>();

    //PUBLIC
    public float speed = 1;

    //PRIVATE

    // Use this for initialization
    void Start() {
        Element.addElement(_elementQueue, new ElementStandardControl(this));
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        Element.updateQueue(_elementQueue);
    }
}
