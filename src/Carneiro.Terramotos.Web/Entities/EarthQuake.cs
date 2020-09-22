using System;

namespace Carneiro.Terramotos.Web.Entities
{
    /// <summary>
    /// Entity that represents an earth quake.
    /// </summary>
    public class EarthQuake : BaseEntity
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Gets or sets the magnitud.
        /// </summary>
        /// <value>
        /// The magnitud.
        /// </value>
        public decimal Magnitud { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EarthQuake"/> is sensed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if sensed; otherwise, <c>false</c>.
        /// </value>
        public bool Sensed { get; set; }

        /// <summary>
        /// Gets or sets the obs.
        /// </summary>
        /// <value>
        /// The obs.
        /// </value>
        public string Obs { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public long LocationId { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{Obs} ({Latitude},{Longitude})";
    }
}
