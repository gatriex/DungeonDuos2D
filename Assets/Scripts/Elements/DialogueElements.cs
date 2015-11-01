using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueActivate : Element {
    Canvas canvas;

    public DialogueActivate(Canvas canvas) {
        this.canvas = canvas;
    }

    public override void onActive() {
        canvas.enabled = true;
    }

    public override void update() {
        finished = true;
    }

    public override void onRemove() {
        
    }
}

public class DialogueDeactivate : Element {
    Canvas canvas;

    public DialogueDeactivate(Canvas canvas) {
        this.canvas = canvas;
    }

    public override void onActive() {
        canvas.enabled = false;
    }

    public override void update() {
        finished = true;
    }

    public override void onRemove() {

    }
}

public class DialogueText : Element {
    List<string> text;
    Canvas canvas;
    int current;
    int size;

    public DialogueText(List<string> text, Canvas canvas) {
        this.text = text;
        this.canvas = canvas;
    }

    public override void onActive() {
        size = text.Count;
        current = 0;
        Debug.Log(text.Count);
        if (size > 0) {
            canvas.GetComponentInChildren<Text>().text = text[current];
        }
        else {
            finished = true;
        }
    }

    public override void update() {
        if (Input.GetButtonDown("Submit")) {
            current++;
            if (current < size) {
                canvas.GetComponentInChildren<Text>().text = text[current];
            }
            else {
                finished = true;
            }
        }
    }

    public override void onRemove() {

    }
}