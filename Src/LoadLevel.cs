using Godot;
using System;

public class LoadLevel : Node2D {
    Node levels;

    public override void _Ready() {
        levels = GetNode<Node>("Levels");

        foreach (Node level in levels.GetChildren()) {
            if (level.Name != GameState.level) {
                levels.RemoveChild(level);
            }
        }
    }
}