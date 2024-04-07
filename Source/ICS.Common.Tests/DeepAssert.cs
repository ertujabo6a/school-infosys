using KellermanSoftware.CompareNetObjects;
using Xunit.Sdk;

namespace ICS.Common.Tests;

public static class DeepAssert
{
    // Taken from project https://github.com/nesfit/ICS
    // File https://github.com/nesfit/ICS/blob/master/src/CookBook/CookBook.Common.Tests/DeepAssert.cs
    // License https://github.com/nesfit/ICS/blob/master/LICENSE

    public static void Equal<T>(T? expected, T? actual, params string[] propertiesToIgnore)
    {
        CompareLogic compareLogic = new()
        {
            Config =
            {
                MembersToIgnore = propertiesToIgnore.ToList(),
                IgnoreCollectionOrder = true,
                IgnoreObjectTypes = true,
                CompareStaticProperties = false,
                CompareStaticFields = false
            }
        };

        ComparisonResult comparisonResult = compareLogic.Compare(expected!, actual!);
        if (!comparisonResult.AreEqual)
        {
            EqualException.ForMismatchedValues(expected, actual, comparisonResult.DifferencesString);
        }
    }

    public static void Contains<T>(T? expected, IEnumerable<T>? collection, params string[] propertiesToIgnore)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            CompareLogic compareLogic = new()
            {
                Config =
                {
                    MembersToIgnore = propertiesToIgnore.ToList(),
                    IgnoreCollectionOrder = true,
                    IgnoreObjectTypes = true,
                    CompareStaticProperties = false,
                    CompareStaticFields = false
                }
            };

            if (!collection.Any(item => compareLogic.Compare(expected, item).AreEqual))
            {
                throw new Exception();
            } }
}
