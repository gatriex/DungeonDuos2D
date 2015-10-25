using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElementMoveOverTime : Element {
    int total_life = 0;
    int life = 0;
    GameObject my_object;
    Vector3 destination;
    Vector3 initial_position;
    bool local;

    public ElementMoveOverTime(int stunTicks, Vector3 dest, Vector3 initial, GameObject my_object, bool local) {
        this.total_life = stunTicks;
        this.my_object = my_object;
        this.destination = dest;
        this.initial_position = initial;
        this.local = local;
    }

    public override void update() {
        life++;
        float ratio = (float)life / total_life;

        if (local)
            my_object.transform.localPosition = Vector3.Lerp(initial_position, destination, ratio);
        else
            my_object.transform.position = Vector3.Lerp(initial_position, destination, ratio);

        if (ratio >= 1.0f)
            finished = true;
    }
}