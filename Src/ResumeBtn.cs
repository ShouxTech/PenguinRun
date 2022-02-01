using Godot;
using System;

public class ResumeBtn : Button {
    Control pauseMenu;

    public override void _Ready() {
        pauseMenu = GetParent<Control>();
    }

    public override void _Pressed() {
        pauseMenu.Visible = false;
        GameState.paused = false;
    }
}