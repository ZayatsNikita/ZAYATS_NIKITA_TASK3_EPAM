namespace Task3.AbstractModels.ComonInterfaces
{
    /// <summary>
    /// An Interface that describes items that can Be painted
    /// </summary>
    internal interface IPainted
    {
        /// <summary>
        /// The method of painting the object
        /// </summary>
        /// <param name="color">The color in which to paint the object</param>
        public void Paint(ShapeColor color);
    }
}
