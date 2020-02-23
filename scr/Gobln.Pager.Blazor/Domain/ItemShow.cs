namespace Gobln.Pager.Blazor
{
    /// <summary>
    /// Enumerator for the items that can be shown
    /// </summary>
    public enum ItemShow
    {
        /// <summary>
        /// First item
        /// </summary>
        FirstItem = 0,

        /// <summary>
        /// Previous item
        /// </summary>
        PreviousItem = 1,

        /// <summary>
        /// Jump previous item
        /// </summary>
        JumpPreviousItem = 2,

        /// <summary>
        /// Page item
        /// </summary>
        PagesItems = 3,

        /// <summary>
        /// Jump next item
        /// </summary>
        JumpNextItem = 4,

        /// <summary>
        /// Next item
        /// </summary>
        NextItem = 5,

        /// <summary>
        /// Last item
        /// </summary>
        LastItem = 6,

        /// <summary>
        /// Page item with range of items
        /// </summary>
        PagesItemsRange = 7,
    }
}
