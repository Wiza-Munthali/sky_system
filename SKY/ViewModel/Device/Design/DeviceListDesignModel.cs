using System.Collections.Generic;

namespace SKY
{
    /// <summary>
    /// The design-time data for a <see cref="DeviceListViewModel"/>
    /// </summary>
    public class DeviceListDesignModel : DeviceListViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static DeviceListDesignModel Instance =>new DeviceListDesignModel();
        #endregion

        #region Constructor
        /// <summary>
        /// Default condtructor
        /// </summary>
        public DeviceListDesignModel()
        {
            Items = new List<DeviceListItemViewModel>
            {
                new DeviceListItemViewModel
                {
                    Initials = "WM",
                    Name = "Wiza",
                    Device = "Samsung S7 Edge",
                    Serial = "#009122",
                    ProfilePictureRGB = "3099c5"

                },
                new DeviceListItemViewModel
                {
                    Initials = "SM",
                    Name = "Sly",
                    Device = "Samsung S7 Edge",
                    Serial = "#009122",
                    ProfilePictureRGB = "fe4503"
                },
                new DeviceListItemViewModel
                {
                    Initials = "AM",
                    Name = "Alpha",
                    Device = "Samsung S7 Edge",
                    Serial = "#009122",
                    ProfilePictureRGB = "00d405"

                },
                new DeviceListItemViewModel
                {
                    Initials = "BM",
                    Name = "Beta",
                    Device = "Samsung S7 Edge",
                    Serial = "#009122",
                    ProfilePictureRGB = "fe4503"
                },
                new DeviceListItemViewModel
                {
                    Initials = "OM",
                    Name = "Omega",
                    Device = "Samsung S7 Edge",
                    Serial = "#009122",
                    ProfilePictureRGB = "3099c5"
                },
               
            };

        }
        #endregion
    }
}
