using Godot;
using System;

public class Camera : Camera2D {
    private Penguin penguin;

    private int speed = 100;

    public override void _Ready() {
        penguin = GetNode<Penguin>("../Penguin");
    }

    public override void _Process(float delta) {
        if (GameState.paused) return;
        
        Position = new Vector2(Position.x + (speed * delta), Position.y);
        if (penguin.Position.x + 220 < Position.x) {
            GetTree().ChangeScene("res://Scenes/GameOver.tscn");
        } else if (penguin.Position.x > Position.x) { // If the character is beyond half of the screen.
            speed = 165;
        } else {
            speed = 100;
        }
    }
}