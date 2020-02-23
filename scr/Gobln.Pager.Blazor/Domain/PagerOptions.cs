using System.Collections.Generic;

namespace Gobln.Pager.Blazor
{
    /// <summary>
    /// The options of the pager
    /// </summary>
    public class PagerOptions : IPagerOptions
    {
        #region Label

        /// <summary>
        /// Label of the first page item
        /// </summary>
        public string LabelFirstPageItem { get; set; } = "First";

        /// <summary>
        /// Label of the previous page item
        /// </summary>
        public string LabelPreviousPageItem { get; set; } = "Previous";

        /// <summary>
        /// Label of the next page item
        /// </summary>
        public string LabelNextPageItem { get; set; } = "Next";

        /// <summary>
        /// Label of the last page item
        /// </summary>
        public string LabelLastPageItem { get; set; } = "Last";

        /// <summary>
        /// Label of the jump page item
        /// </summary>
        public string LabelJumpPageItem { get; set; } = "...";

        #endregion Label

        #region

        /// <summary>
        /// Defines which page items will be displayed and in what order.
        /// </summary>
        public ItemShow[] ItemShowOrder { get; set; } = new ItemShow[7] { ItemShow.PreviousItem, ItemShow.FirstItem, ItemShow.JumpPreviousItem, ItemShow.PagesItems, ItemShow.JumpNextItem, ItemShow.LastItem, ItemShow.NextItem };

        /// <summary>
        /// The amount of visible pagenumbers on each side of the selected page.
        /// </summary>
        public int VisableItemsPerSide { get; set; } = 3;

        /// <summary>
        /// Hide the pager if there is no paging.
        /// If <see cref="Gobln.Pager.Page{T}"/> is null then the pager not be shown regardless of setting.
        /// </summary>
        public bool HideIfNotPaged { get; set; } = true;

        /// <summary>
        /// Data-attibute name, contains the page number.
        /// </summary>
        public string DataIndexName { get; set; } = "pageIndex";

        /// <summary>
        /// NavTag Attributes
        /// </summary>
        public IEnumerable<KeyValuePair<string, object>> NavTagAttributes { get; set; }

        /// <summary>
        /// Use icons instead of text for the labels.
        /// </summary>
        public bool UseIcons { get; set; } = false;

        /// <summary>
        /// Display/highlight the active page.
        /// BootStrap only
        /// </summary>
        public bool ActiveDisplay { get; set; } = false;

        /// <summary>
        /// Size of the pager.
        /// BootStrap only
        /// </summary>
        public PagerSizeEnum PagerSize { get; set; } = PagerSizeEnum.Normal;

        /// <summary>
        /// Alignment of the pager.
        /// </summary>
        public PagerAlignmentEnum PagerAlignment { get; set; } = PagerAlignmentEnum.Left;

        #endregion

        #region Visibility

        /// <summary>
        /// Always show the fist page item even when it's disabled
        /// </summary>
        public bool AlwaysShowFirstPageItem { get; set; } = true;

        /// <summary>
        /// Always show the previous page item even when it's disabled
        /// </summary>
        public bool AlwaysShowPreviousPageItem { get; set; } = true;

        /// <summary>
        /// Always show the next page item even when it's disabled
        /// </summary>
        public bool AlwaysShowNextPageItem { get; set; } = true;

        /// <summary>
        /// Always show the last page item even when it's disabled
        /// </summary>
        public bool AlwaysShowLastPageItem { get; set; } = true;

        /// <summary>
        /// Always show the jump page item even when it's disabled
        /// </summary>
        public bool AlwaysShowJumpPageItem { get; set; } = true;

        #endregion Visibility
    }
}
