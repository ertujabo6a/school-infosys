using CommunityToolkit.Maui.Converters;
using ICS.DAL.Entities;
using System.Globalization;
using ICS.BL.Models;

namespace ICS.App.Converters;

public class ActivityConverter : BaseConverterOneWay<ActivityListModel, string>
{
    public override string ConvertFrom(ActivityListModel value, CultureInfo? culture) => $"{value.Type} {value.SubjectAbbr} {value.StartTime} {value.EndTime}";

    public override string DefaultConvertReturnValue { get; set; } = string.Empty;
}
