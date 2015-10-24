using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : Element {
    Bob bob;
    Steve steve;
    string horizontal;
    string vertical;

    public BobMovement(Bob bob) {
        this.bob = bob;
        horizontal = bob.horizontal;
        vertical = bob.vertical;
        this.steve = bob.steve;
    }

    public override void onActive() {
    }

    public override void update() {
        bob.GetComponent<Rigidbody2D>().velocity = (new Vector2(Input.GetAxis(horizontal), Input.GetAxis(vertical)) * bob.speed);
        if (Input.GetButtonDown("SwitchPlayers")) {
            Debug.Log("Switch to Steve");
            Element.addElement(steve._elementQueue, new Noop(1));
            Element.addElement(steve._elementQueue, new SteveMovement(steve));
            finished = true;
        }
    }

    public override void onRemove() {
        bob.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}