using System.Collections.Generic;

namespace Gobln.Pager.Blazor
{
    public interface IPagerOptions
    {
        #region Label

        /// <summary>
        /// Label of the first page item
        /// </summary>
        string LabelFirstPageItem { get; set; }

        /// <summary>
        /// Label of the previous page item
        /// </summary>
        string LabelPreviousPageItem { get; set; }

        /// <summary>
        /// Label of the next page item
        /// </summary>
        string LabelNextPageItem { get; set; }

        /// <summary>
        /// Label of the last page item
        /// </summary>
        string LabelLastPageItem { get; set; }

        /// <summary>
        /// Label of the jump page item
        /// </summary>
        string LabelJumpPageItem { get; set; }

        #endregion Label

        #region

        /// <summary>
        /// Defines which page items will be displayed and in what order.
        /// </summary>
        ItemShow[] ItemShowOrder { get; set; }

        /// <summary>
        /// The amount of visible pagenumbers on each side of the selected page.
        /// </summary>
        int VisableItemsPerSide { get; set; }

        /// <summary>
        /// Hide the page if there is no paging
        /// If <see cref="Gobln.Pager.Page{T}"/> is null then the pager not be shown regardless of setting.
        /// </summary>
        bool HideIfNotPaged { get; set; }

        /// <summary>
        /// NavTag Attributes
        /// </summary>
        IEnumerable<KeyValuePair<string, object>> NavTagAttributes { get; set; }

        /// <summary>
        /// Data-attibute name, contains the page number.
        /// </summary>
        string DataIndexName { get; set; }

        /// <summary>
        /// Use icons instead of text for the labels.
        /// </summary>
        bool UseIcons { get; set; }

        /// <summary>
        /// Display/highlight the active page.
        /// BootStrap
        /// </summary>
        bool ActiveDisplay { get; set; }

        /// <summary>
        /// Size of the pager.
        /// BootStrap only
        /// </summary>
        PagerSizeEnum PagerSize { get; set; }

        /// <summary>
        /// Alignment of the pager.
        /// </summary>
        PagerAlignmentEnum PagerAlignment { get; set; }

        #endregion

        #region Visibility

        /// <summary>
        /// Always show the fist page item even when it's disabled
        /// </summary>
        bool AlwaysShowFirstPageItem { get; set; }

        /// <summary>
        /// Always show the previous page item even when it's disabled
        /// </summary>
        bool AlwaysShowPreviousPageItem { get; set; }

        /// <summary>
        /// Always show the next page item even when it's disabled
        /// </summary>
        bool AlwaysShowNextPageItem { get; set; }

        /// <summary>
        /// Always show the last page item even when it's disabled
        /// </summary>
        bool AlwaysShowLastPageItem { get; set; }

        /// <summary>
        /// Always show the jump page item even when it's disabled
        /// </summary>
        bool AlwaysShowJumpPageItem { get; set; }

        #endregion Visibility
    }
}
