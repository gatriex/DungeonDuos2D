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
        if (Input.GetButtonDown("Ability1")) {
            Debug.Log("Ability1");
            Element.addElement(steve._elementQueue, new ElementMoveOverTime(10, bob.transform.position, steve.transform.position, steve.gameObject, false));
            Element.addElement(bob._elementQueue, new ElementMoveOverTime(10, steve.transform.position, bob.transform.position, bob.gameObject, false));
            Element.addElement(steve._elementQueue, new SteveMovement(steve));
            finished = true;
        }
    }

    public override void onRemove() {
        steve.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}