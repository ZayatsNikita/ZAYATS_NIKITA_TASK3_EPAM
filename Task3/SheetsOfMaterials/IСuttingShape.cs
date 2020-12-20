using Task3.AbstractModels;
namespace Task3
{
    /// <summary>
    /// An interface that is implemented by classes that cut out specific shapes.
    /// </summary>
    public interface IСuttingShape
    {
        /// <summary>
        /// Method for cutting out the corresponding shape.
        /// </summary>
        /// <param name="lengthOfSodes">Array of sides of the shape.</param>
        /// <returns>new Shape object</returns>
        public Shape CutShape(double[] lengthOfSodes);
    }
}
