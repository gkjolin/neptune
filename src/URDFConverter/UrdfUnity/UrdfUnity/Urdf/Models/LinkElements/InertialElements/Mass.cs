﻿namespace UrdfUnity.Urdf.Models.LinkElements.InertialElements
{
    /// <summary>
    /// Represents the mass of the link in kilograms.
    /// </summary>
    /// <seealso cref="http://wiki.ros.org/urdf/XML/inertial"/>
    public class Mass
    {
        /// <summary>
        /// The mass value of the link in kilograms.
        /// </summary>
        public double Value { get; }


        /// <summary>
        /// Creates a new instance of Mass with the value specified.
        /// </summary>
        /// <param name="value">The mass of the link in kilograms</param>
        public Mass(double value)
        {
            this.Value = value;
        }
    }
}