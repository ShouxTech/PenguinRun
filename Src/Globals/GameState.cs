using Godot;
using System;

public class GameState : Node {
    public static float score = 0;

    public override void _Ready() {

    }

    public static void Reset() {
        score = 0;
    }
}