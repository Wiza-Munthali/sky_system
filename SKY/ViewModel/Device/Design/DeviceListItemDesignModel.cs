namespace SKY
{    
    /// <summary>
    /// The design-time data for a <see cref="DeviceListItemViewModel"/>
    /// </summary>
   public class DeviceListItemDesignModel : DeviceListItemViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static DeviceListItemDesignModel Instance =>new DeviceListItemDesignModel();
        #endregion

        #region Constructor
        /// <summary>
        /// Default condtructor
        /// </summary>
        public DeviceListItemDesignModel()
        {
            Initials = "WM";
            Name = "Wiza";
            Device = "Samsung S7 Edge";
            Serial = "#009122";
            ProfilePictureRGB = "3099c5";
        }
        #endregion
    }
}
