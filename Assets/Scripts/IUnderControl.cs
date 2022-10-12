using UnityEngine;

public interface IUnderControl
{
    public bool IsActive { get; }
    public void Activate();
    public void Deactivate();
    public void Toggle();

    public void SetBaseColor(Color color) { }
}
