using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SpyPlugin
{
    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        [Description("Whether or not this Spy Role is enabled.")]
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether debug messages will be shown.
        /// </summary>
        [Description("Whether or not to display debug messages in the server console.")]
        public bool Debug { get; set; }


        /// <summary>
        /// Role configs for Spy.
        /// </summary>
        [Description("A CI Agent between the MTFs")]
        public SpyRole SpyRoleConfig { get; set; } = new();



    }
}