using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Noop : Element {
    int life = 0;

    public Noop(int stunTicks) {
        life = stunTicks;
    }

    public override void update() {
        life--;
        if (life <= 0)
            finished = true;
    }
}