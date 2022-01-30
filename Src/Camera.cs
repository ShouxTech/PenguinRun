using Godot;
using System;

public class Camera : Camera2D {
    Penguin penguin;
    TextureRect background;

    public override void _Ready() {
        penguin = GetNode<Penguin>("../Penguin");
        background = GetNode<TextureRect>("../Background");
    }

    public override void _Process(float delta) {
        Position = new Vector2(penguin.Position.x, Position.y);
        //background.RectPosition = new Vector2(0, background.RectPosition.y);
    }
}