namespace Task3.AbstractModels.ComonInterfaces
{
    /// <summary>
    /// An interface that describes two dimensional things.
    /// </summary>
    interface I2DObject
    {
        /// <summary>
        /// Property that should return the area of the object.
        /// </summary>
        public double Area { get; }
        /// <summary>
        /// Property describing the perimeter of the object.
        /// </summary>
        public double Perimeter { get; } 
    }
}
