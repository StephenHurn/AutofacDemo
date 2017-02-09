namespace AutofacDemo
{
    using System;

    /// <summary>
    /// Defines my instance per lifetime scope class.
    /// </summary>
    public class MyInstancePerMatchingLifetimeScope : IDisposable
    {
        /// <summary>
        /// The object number
        /// </summary>
        private static int objectNumber = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyInstancePerMatchingLifetimeScope"/> class.
        /// </summary>
        public MyInstancePerMatchingLifetimeScope()
        {
            this.ThisObjectId = objectNumber++;
        }

        /// <summary>
        /// Gets the this object identifier.
        /// </summary>
        /// <value>
        /// The this object identifier.
        /// </value>
        public int ThisObjectId { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "MyInstancePerMatchingLifetimeScope: " + this.ThisObjectId;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            System.Console.WriteLine("Disposing " + this.ToString());
        }
    }
}
