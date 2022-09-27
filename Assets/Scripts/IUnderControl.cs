public interface IUnderControl
{
    public bool IsActive { get; }
    public void Activate();
    public void Deactivate();
    public void Toggle();
}
