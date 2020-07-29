public class SpeederPlacementData
{
    private int _id;
    private float _position;
    private int _lap;

    public SpeederPlacementData(int id)
    {
        _id = id;
        _position = 0f;
        _lap = 0;
    }

    public int GetID()
    {
        return _id;
    }

    public float GetPosition()
    {
        return _position;
    }

    public void SetPosition(float newPosition)
    {
        _position = newPosition;
    }

    public int GetLap()
    {
        return _lap;
    }

    public void IncreaseLap()
    {
        _lap++;
    }
}
