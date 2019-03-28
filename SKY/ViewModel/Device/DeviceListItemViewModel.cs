namespace SKY
{
    /// <summary>
    /// View model for each device list item in the dashboard
    /// </summary>
   public class DeviceListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The display tag of the device list
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The name to show on the item list
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The device model to show on the list
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// The serial N.o for the device to be displayed on the list
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for red and blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

    }
}
