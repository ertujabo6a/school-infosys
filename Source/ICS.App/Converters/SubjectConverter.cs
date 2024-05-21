using CommunityToolkit.Maui.Converters;
using ICS.DAL.Entities;
using System.Globalization;
using ICS.BL.Models;

namespace ICS.App.Converters;

public class SubjectConverter : BaseConverterOneWay<SubjectListModel, string>
{
    public override string ConvertFrom(SubjectListModel value, CultureInfo? culture) => $"{value.SubjectAbbr}";

    public override string DefaultConvertReturnValue { get; set; } = string.Empty;
}
