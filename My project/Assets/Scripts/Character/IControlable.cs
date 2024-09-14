using UnityEngine;

public interface IControlable
{
    public void Move(Vector2 _direction);
    public void Jump();
    public void Dash();
}