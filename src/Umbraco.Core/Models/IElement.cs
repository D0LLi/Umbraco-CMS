namespace Umbraco.Cms.Core.Models;

/// <summary>
///     Represents an Element.
/// </summary>
/// <remarks>
///     <para>An element can be published, but is not routed</para>
/// </remarks>
public interface IElement : IContentBase
{
    /// <summary>
    ///     Gets a value indicating whether the element is published.
    /// </summary>
    /// <remarks>The <see cref="PublishedVersionId" /> property tells you which version of the element is currently published.</remarks>
    bool Published { get; set; }

    PublishedState PublishedState { get; set; }

    /// <summary>
    ///     Gets a value indicating whether the element has been edited.
    /// </summary>
    /// <remarks>
    ///     Will return `true` once unpublished edits have been made after the version with
    ///     <see cref="PublishedVersionId" /> has been published.
    /// </remarks>
    bool Edited { get; set; }

    /// <summary>
    ///     Gets the version identifier for the currently published version of the element.
    /// </summary>
    int PublishedVersionId { get; set; }

    /// <summary>
    ///     Gets the name of the published version of the element.
    /// </summary>
    /// <remarks>When editing the element, the name can change, but this will not until the element is published.</remarks>
    string? PublishName { get; set; }

    /// <summary>
    ///     Gets the identifier of the user who published the element.
    /// </summary>
    int? PublisherId { get; set; }

    /// <summary>
    ///     Gets the date and time the element was published.
    /// </summary>
    DateTime? PublishDate { get; set; }

    /// <summary>
    ///     Gets the published culture infos of the element.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Because a dictionary key cannot be <c>null</c> this cannot get the invariant
    ///         name, which must be get via the <see cref="PublishName" /> property.
    ///     </para>
    /// </remarks>
    ContentCultureInfosCollection? PublishCultureInfos { get; set; }

    /// <summary>
    ///     Gets the published cultures.
    /// </summary>
    IEnumerable<string> PublishedCultures { get; }

    /// <summary>
    ///     Gets the edited cultures.
    /// </summary>
    IEnumerable<string>? EditedCultures { get; set; }

    /// <summary>
    ///     Gets a value indicating whether a culture is published.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         A culture becomes published whenever values for this culture are published,
    ///         and the element published name for this culture is non-null. It becomes non-published
    ///         whenever values for this culture are unpublished.
    ///     </para>
    ///     <para>
    ///         A culture becomes published as soon as PublishCulture has been invoked,
    ///         even though the document might not have been saved yet (and can have no identity).
    ///     </para>
    ///     <para>Does not support the '*' wildcard (returns false).</para>
    /// </remarks>
    bool IsCulturePublished(string culture);

    /// <summary>
    ///     Gets the date a culture was published.
    /// </summary>
    DateTime? GetPublishDate(string culture);

    /// <summary>
    ///     Gets a value indicated whether a given culture is edited.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         A culture is edited when it is available, and not published or published but
    ///         with changes.
    ///     </para>
    ///     <para>A culture can be edited even though the document might now have been saved yet (and can have no identity).</para>
    ///     <para>Does not support the '*' wildcard (returns false).</para>
    /// </remarks>
    bool IsCultureEdited(string culture);

    /// <summary>
    ///     Gets the name of the published version of the element for a given culture.
    /// </summary>
    /// <remarks>
    ///     <para>When editing the element, the name can change, but this will not until the element is published.</para>
    ///     <para>
    ///         When <paramref name="culture" /> is <c>null</c>, gets the invariant
    ///         language, which is the value of the <see cref="PublishName" /> property.
    ///     </para>
    /// </remarks>
    string? GetPublishName(string? culture);

    /// <summary>
    ///     Creates a deep clone of the current entity with its identity/alias and it's property identities reset
    /// </summary>
    /// <returns></returns>
    IContent DeepCloneWithResetIdentities();
}
