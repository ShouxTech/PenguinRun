using Godot;
using System;

public class MainMenuBtn : Button {
    public override void _Ready() {

    }

    public override void _Pressed() {
        GetTree().ChangeScene("res://Scenes/Menu.tscn");
        GameState.paused = false;
    }
}