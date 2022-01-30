using Godot;
using System;

public class Penguin : KinematicBody2D {
    private float gravity = 200;
    private float speed = 135;
    private float jumpForce = 7000;

    private Vector2 upDirection = new Vector2(0, -1);

    private Vector2 velocity;

    private AnimatedSprite sprite;

    public override void _Ready() {
        sprite = GetNode<AnimatedSprite>("Sprite");
    }

    private void MoveOnSlope() {
        int slides = GetSlideCount();
        for (int i = 0; i < slides; i++) {
            KinematicCollision2D touched = GetSlideCollision(i);
            if (IsOnFloor() && touched.Normal.y < 1 && (velocity.x != 0.0 || velocity.y != 0.0)) {
                velocity.y = touched.Normal.y;
            }
        }
    }

    private void Move(float delta) {
        velocity.y += delta * gravity;

        if (Input.IsActionPressed("move_left")) {
            sprite.FlipH = true;
            sprite.Play("Walking");
            velocity.x = -speed;
        } else if (Input.IsActionPressed("move_right")) {
            sprite.FlipH = false;
            sprite.Play("Walking");
            velocity.x = speed;
        } else {
            sprite.Play("Default");
            velocity.x *= 0.65f;
        }

        if (Input.IsKeyPressed((int)KeyList.Space) && IsOnFloor()) {
            velocity.y -= delta * jumpForce;
        }

        if (!IsOnFloor()) {
            sprite.Play("Jumping");
        }

        MoveAndSlide(velocity, upDirection, true, 4, Mathf.Deg2Rad(60));
    }

    private void CheckForSpike() {
        KinematicCollision2D touched = GetLastSlideCollision();
        if (touched != null) {
            object name = touched.Collider.Get("name");
            if ((string)name == "Spikes") {
                GetTree().ChangeScene("res://Scenes/GameOver.tscn");
            }
        }
    }

    public override void _Process(float delta) {
        
    }

    public override void _PhysicsProcess(float delta) {
        Move(delta);
        MoveOnSlope();
        CheckForSpike();
    }
}