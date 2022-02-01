using Godot;
using System;

public class PlayAgain : Button {
    public override void _Ready() {
        
    }

    private void Play() {
        GetTree().ChangeScene("res://Scenes/Main.tscn");
    }

    public override void _UnhandledKeyInput(InputEventKey eventKey) {
        if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Space) {
            Play();
        }
    }

    public override void _Pressed() {
        Play();
    }
}