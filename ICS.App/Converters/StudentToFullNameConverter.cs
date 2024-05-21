using CommunityToolkit.Maui.Converters;
using ICS.DAL.Entities;
using System.Globalization;
using ICS.BL.Models;

namespace ICS.App.Converters;

public class StudentToFullNameConverter : BaseConverterOneWay<StudentListModel, string>
{
    public override string ConvertFrom(StudentListModel value, CultureInfo? culture) => $"{value.Name} {value.Surname}";

    public override string DefaultConvertReturnValue { get; set; } = string.Empty;
}
