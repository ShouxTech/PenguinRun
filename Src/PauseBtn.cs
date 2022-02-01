using Godot;
using System;

public class PauseBtn : TextureButton {
    Control pauseMenu;

    public override void _Ready() {
        pauseMenu = GetNode<Control>("../PauseMenu");
    }

    public override void _Pressed() {
        GameState.paused = true;
        pauseMenu.Visible = true;
    }
}