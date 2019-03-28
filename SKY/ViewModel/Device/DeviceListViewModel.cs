using System.Collections.Generic;

namespace SKY
{
    /// <summary>
    /// View model for the overview device list 
    /// </summary>
    public class DeviceListViewModel : BaseViewModel
    {
        /// <summary>
        /// The device list items for the lsit
        /// </summary>
        public List<DeviceListItemViewModel> Items { get; set; }
    }
}
