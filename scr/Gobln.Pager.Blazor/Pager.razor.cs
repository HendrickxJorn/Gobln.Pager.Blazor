using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

namespace Gobln.Pager.Blazor
{
    public class PagerBase : ComponentBase
    {
        [Parameter]
        public IPage Page { get; set; }

        [Parameter]
        public IPagerOptions PagerOptions { get; set; } = new PagerOptions();

        [Parameter]
        public EventCallback<int> OnPageIndexChange { get; set; }

        public RenderFragment DynamicResult;

        protected override Task OnParametersSetAsync()
        {
            CreatePager();
            return base.OnParametersSetAsync();
        }

        protected override void OnInitialized()
        {
            CreatePager();
        }

        public void ChangePage(int pageIndex, bool isDisabled)
        {
            if (!isDisabled)
            {
                OnPageIndexChange.InvokeAsync(pageIndex);

                CreatePager();
            }
        }

        private void CreatePager()
        {
            if (PagerOptions == null)
            {
                throw new ArgumentNullException("PagerOptions");
            }

            if (PagerOptions.ItemShowOrder == null)
            {
                throw new ArgumentNullException("PagerOptions.ItemShowOrder");
            }

            if (Page != null && (Page.HasPaging || !PagerOptions.HideIfNotPaged))
            {
                //if (!PagerOptions.UrlDisable)
                //{
                //    if (string.IsNullOrWhiteSpace(PagerOptions.Url))
                //    {
                //        PagerOptions.Url = Helper.GetCurrentUrlString(html);
                //    }
                //    else
                //    {
                //        if (!Uri.TryCreate(PagerOptions.Url, UriKind.Absolute, out Uri uriResult))
                //        {
                //            throw new ArgumentException("Invalid Url. The Url does not start with http or https, or is invallid.", "pagerOptions.Url");
                //        }
                //    }
                //}

                //return new PagerBuilder(page, pagerOptions).Render();

                DynamicResult = builder =>
                {
                    builder.OpenElement(1, "nav");
                    builder.AddMultipleAttributes(2, PagerOptions.NavTagAttributes);
                    builder.AddContent(3, GenerateUl());
                    builder.CloseElement();
                };
            }
        }

        private RenderFragment GenerateUl()
        {
            RenderFragment tempDynamicResult;

            var classAtrr = "pagination";

            switch (PagerOptions.PagerSize)
            {
                case PagerSizeEnum.Large:
                    classAtrr += " pagination-lg";
                    break;

                case PagerSizeEnum.Small:
                    classAtrr += " pagination-sm";
                    break;
            }

            switch (PagerOptions.PagerAlignment)
            {
                case PagerAlignmentEnum.Center:
                    classAtrr += " justify-content-center";
                    break;

                case PagerAlignmentEnum.Right:
                    classAtrr += " justify-content-end";
                    break;
            }

            var sequence = 3;

            return tempDynamicResult = builder =>
            {
                builder.OpenElement(1, "ul");
                builder.AddAttribute(2, "class", classAtrr);

                foreach (var item in PagerOptions.ItemShowOrder)
                {
                    switch (item)
                    {
                        case ItemShow.FirstItem:
                            if (PagerOptions.AlwaysShowFirstPageItem || Page.CurrentPageIndex - PagerOptions.VisableItemsPerSide > 1)
                            {
                                builder.AddContent(sequence,
                                            GenerateIl(Page.CurrentPageIndex == 1,
                                                        GenerateSpanTag(PagerOptions.LabelFirstPageItem, "««", 1, disableTabing: Page.CurrentPageIndex == 1)));

                                sequence++;
                            }
                            break;

                        case ItemShow.PreviousItem:
                            if (PagerOptions.AlwaysShowPreviousPageItem || Page.CurrentPageIndex > 1)
                            {
                                var previous = Page.CurrentPageIndex - 1;

                                previous = previous < 1 ? 1 : previous;

                                builder.AddContent(sequence,
                                           GenerateIl(Page.CurrentPageIndex == previous,
                                                        GenerateSpanTag(PagerOptions.LabelPreviousPageItem, "«", previous, disableTabing: Page.CurrentPageIndex == previous)));

                                sequence++;
                            }
                            break;

                        case ItemShow.JumpPreviousItem:
                            if (PagerOptions.AlwaysShowJumpPageItem || Page.CurrentPageIndex - PagerOptions.VisableItemsPerSide > 2)
                            {
                                var previous = ((Page.CurrentPageIndex - PagerOptions.VisableItemsPerSide) / 2) + 1;

                                previous = previous < 1 ? 1 : previous;

                                builder.AddContent(sequence,
                                           GenerateIl(Page.CurrentPageIndex == previous,
                                                        GenerateSpanTag(PagerOptions.LabelJumpPageItem, string.Empty, previous, disableTabing: Page.CurrentPageIndex == previous)));

                                sequence++;
                            }
                            break;

                        case ItemShow.PagesItems:
                            builder.AddContent(sequence, GeneratePageNumbers());

                            sequence++;
                            break;

                        case ItemShow.PagesItemsRange:
                            builder.AddContent(sequence, GeneratePageNumbers(true));

                            sequence++;
                            break;

                        case ItemShow.JumpNextItem:
                            if (PagerOptions.AlwaysShowJumpPageItem || Page.CurrentPageIndex + PagerOptions.VisableItemsPerSide < Page.TotalPageCount - 1)
                            {
                                var next = Page.CurrentPageIndex + PagerOptions.VisableItemsPerSide;

                                next = ((Page.TotalPageCount - next) / 2) + next;

                                next = next > Page.TotalPageCount ? Page.TotalPageCount : next;

                                builder.AddContent(sequence,
                                           GenerateIl(next == Page.CurrentPageIndex,
                                                    GenerateSpanTag(PagerOptions.LabelJumpPageItem, string.Empty, next, disableTabing: Page.CurrentPageIndex == next)));

                                sequence++;
                            }
                            break;

                        case ItemShow.NextItem:
                            if (PagerOptions.AlwaysShowNextPageItem || Page.CurrentPageIndex < Page.TotalPageCount)
                            {
                                var next = Page.CurrentPageIndex + 1;

                                next = next > Page.TotalPageCount ? Page.TotalPageCount : next;

                                builder.AddContent(sequence,
                                               GenerateIl(next == Page.CurrentPageIndex,
                                                        GenerateSpanTag(PagerOptions.LabelNextPageItem, "»", next, disableTabing: Page.CurrentPageIndex == next)));

                                sequence++;
                            }
                            break;

                        case ItemShow.LastItem:
                            if (PagerOptions.AlwaysShowLastPageItem || Page.CurrentPageIndex + PagerOptions.VisableItemsPerSide < Page.TotalPageCount)
                            {
                                builder.AddContent(sequence,
                                           GenerateIl(Page.CurrentPageIndex == Page.TotalPageCount,
                                                        GenerateSpanTag(PagerOptions.LabelLastPageItem, "»»", Page.TotalPageCount, disableTabing: Page.CurrentPageIndex == Page.TotalPageCount)));



                                sequence++;
                            }
                            break;

                        default:
                            break;
                    }
                }

                builder.CloseElement();
            };
        }

        private RenderFragment GenerateIl(bool isDisabled, RenderFragment innerHtml, bool isActive = false)
        {
            RenderFragment tempDynamicResult;

            var classAtrr = "page-item";

            if (isDisabled && !isActive)
            {
                classAtrr += " disabled";
            }

            if (isActive)
            {
                classAtrr += " active";
            }

            return tempDynamicResult = builder =>
            {
                builder.OpenElement(1, "il");
                builder.AddAttribute(2, "class", classAtrr);
                builder.AddContent(3, innerHtml);
                builder.CloseElement();
            };
        }

        private static RenderFragment GenerateSpanTag(string label, string classNames, bool isAreaHidden = false)
        {
            RenderFragment tempDynamicResult;

            var sequence = 3;

            return tempDynamicResult = builder =>
            {
                builder.OpenElement(1, "span");

                if (!string.IsNullOrWhiteSpace(classNames))
                {
                    builder.AddAttribute(sequence, "class", classNames);

                    sequence++;
                }

                if (isAreaHidden)
                {
                    builder.AddAttribute(sequence, "aria-hidden", "true");
                    sequence++;
                }

                builder.AddContent(sequence, label);

                builder.CloseElement();
            };
        }

        //Rethink
        private RenderFragment GenerateSpanTag(string label, RenderFragment extraLabel, string icon, int pageIndex, bool isDisabled = false, bool disableTabing = false)
        {
            RenderFragment tempDynamicResult;

            var sequence = 5;

            return tempDynamicResult = builder =>
            {
                builder.OpenElement(1, "span");
                builder.AddAttribute(2, "class", "page-link");
                builder.AddAttribute(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, () => ChangePage(pageIndex, isDisabled)));
                builder.AddAttribute(4, $"data-{PagerOptions.DataIndexName}", pageIndex.ToString());

                if (disableTabing)
                {
                    builder.AddAttribute(sequence, "tabindex", "-1");

                    sequence++;
                }

                if (PagerOptions.UseIcons && !string.IsNullOrWhiteSpace(icon))
                {
                    builder.AddContent(sequence, GenerateSpanIconTag(icon));

                    sequence++;

                    builder.AddContent(sequence, GenerateSpanTag(label, "sr-only"));

                    sequence++;

                    builder.AddAttribute(sequence, "aria-label", label);
                }
                else
                {
                    builder.AddContent(sequence, label);

                    sequence++;

                    builder.AddContent(sequence, extraLabel);
                }

                builder.CloseElement();
            };
        }

        private RenderFragment GenerateSpanTag(string label, string icon, int pageIndex, bool isDisabled = false, bool disableTabing = false)
        {
            RenderFragment tempDynamicResult;

            var sequence = 5;

            return tempDynamicResult = builder =>
            {
                builder.OpenElement(1, "span");
                builder.AddAttribute(2, "class", "page-link");
                builder.AddAttribute(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, () => ChangePage(pageIndex, isDisabled)));
                builder.AddAttribute(4, $"data-{PagerOptions.DataIndexName}", pageIndex.ToString());

                if (disableTabing)
                {
                    builder.AddAttribute(sequence, "tabindex", "-1");

                    sequence++;
                }

                if (PagerOptions.UseIcons && !string.IsNullOrWhiteSpace(icon))
                {
                    builder.AddAttribute(sequence, "aria-label", label);

                    sequence++;

                    builder.AddContent(sequence, GenerateSpanIconTag(icon));

                    sequence++;

                    builder.AddContent(sequence, GenerateSpanTag(label, "sr-only"));

                    sequence++;
                }
                else
                {
                    builder.AddContent(sequence, label);

                    sequence++;
                }

                builder.CloseElement();
            };
        }

        private static RenderFragment GenerateSpanIconTag(string label)
        {
            RenderFragment tempDynamicResult;

            return tempDynamicResult = builder =>
            {
                builder.OpenElement(1, "span");
                builder.AddAttribute(2, "aria-hidden", "true");
                builder.AddContent(3, label);
                builder.CloseElement();
            };
        }

        private RenderFragment GeneratePageNumbers(bool numberRange = false)
        {
            RenderFragment tempDynamicResult;

            var startIndex = Page.CurrentPageIndex - PagerOptions.VisableItemsPerSide;
            var endIndex = Page.CurrentPageIndex + PagerOptions.VisableItemsPerSide;

            if (startIndex < 1)
            {
                startIndex = 1;
            }

            if (endIndex > Page.TotalPageCount)
            {
                endIndex = Page.TotalPageCount;
            }

            var sequence = 1;

            return tempDynamicResult = builder =>
            {
                for (int index = startIndex; index <= endIndex; index++)
                {
                    var text = numberRange
                        ? $"{((index - 1) * Page.PageSize) + 1 } - {((index - 1) * Page.PageSize) + Page.PageSize}"
                        : index.ToString();

                    var il = GenerateIl(Page.CurrentPageIndex == index,
                        PagerOptions.ActiveDisplay && Page.CurrentPageIndex == index
                            ? GenerateSpanTag(text, GenerateSpanTag("(current)", "sr-only"), string.Empty, index)
                            : GenerateSpanTag(text, string.Empty, index),
                        PagerOptions.ActiveDisplay && Page.CurrentPageIndex == index);

                    builder.AddContent(sequence, il);

                    sequence++;
                }
            };
        }
    }
}
