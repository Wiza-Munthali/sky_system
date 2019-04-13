using SKY.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace SKY
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.SignUp:
                    return new SignUpPage();

                case ApplicationPage.HomePage:
                    return new HomePage();

                case ApplicationPage.DashBoard:
                    return new DashBoardPage();

                case ApplicationPage.Settings:
                    return new Settings();

                case ApplicationPage.Reminder:
                    return new Reminder();

                case ApplicationPage.AddPage:
                    return new AddPage();

                case ApplicationPage.Help:
                    return new Help();

                case ApplicationPage.Message:
                    return new Messages();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
