using Godot;
using System;

public class Camera : Camera2D {
    Penguin penguin;

    public override void _Ready() {
        penguin = GetNode<Penguin>("../Penguin");
    }

    public override void _Process(float delta) {
        Position = new Vector2(penguin.Position.x + 100, Position.y);
    }
}