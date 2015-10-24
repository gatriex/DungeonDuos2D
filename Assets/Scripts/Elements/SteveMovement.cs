using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveMovement : Element {
    Steve steve;
    Bob bob;
    string horizontal;
    string vertical;

    public SteveMovement(Steve steve) {
        this.steve = steve;
        horizontal = steve.horizontal;
        vertical = steve.vertical;
        this.bob = steve.bob;
    }

    public override void onActive() {
    }

    public override void update() {
        steve.GetComponent<Rigidbody2D>().velocity = (new Vector2(Input.GetAxis(horizontal), Input.GetAxis(vertical)) * steve.speed);
        if (Input.GetButtonDown("SwitchPlayers")) {
            Debug.Log("Switch to Bob");
            Element.addElement(bob._elementQueue, new Noop(1));
            Element.addElement(bob._elementQueue, new BobMovement(bob));
            finished = true;
        }
    }

    public override void onRemove() {
        steve.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}