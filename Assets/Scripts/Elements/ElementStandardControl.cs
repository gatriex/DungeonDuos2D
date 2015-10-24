using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementStandardControl : Element {
    Player player;

    public ElementStandardControl(Player player) {
        this.player = player;
    }

    public override void onActive() {
    }

    public override void update() {
        player.GetComponent<Rigidbody2D>().velocity = (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * player.speed);
    }

    public override void onRemove() {

    }
}