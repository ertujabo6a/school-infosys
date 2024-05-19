using CommunityToolkit.Maui.Converters;
using ICS.DAL.Entities;
using System.Globalization;
using ICS.BL.Models;

namespace ICS.App.Converters;

public class ActivityConverter : BaseConverterOneWay<EvaluationDetailModel, string>
{
    public override string ConvertFrom(EvaluationDetailModel value, CultureInfo? culture) => $"{value.Activity} {value.SubjectAbbr}";

    public override string DefaultConvertReturnValue { get; set; } = string.Empty;
}
