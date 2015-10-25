using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Element {
    Enemy enemy;
    float timer;
    bool right;

    public EnemyMovement(Enemy enemy) {
        this.enemy = enemy;
        timer = 50f;
        right = true;
    }

    public override void onActive() {

    }

    public override void update() {
        if (right) {
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.right * enemy.speed;
            timer++;
            if (timer > 100) {
                right = false;
            }
        } else {
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * enemy.speed;
            timer--;
            if (timer < 0) {
                right = true;
            }
        }

    }

    public override void onRemove() {

    }
}