namespace Shapes.Models.Contracts
{
    public interface IShape
    {
        string Draw();

        double CalculatePerimeter();

        double CalculateArea();
    }
}
