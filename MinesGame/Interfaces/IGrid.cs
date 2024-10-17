namespace MinesGame.Interfaces;

public interface IGrid
{
    public int Size { get; set; }
    void PlaceMines();
    bool HasMine(Position position);
}
