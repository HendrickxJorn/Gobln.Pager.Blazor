# Gobln.Pager.Blazor

Gobln.Pager.Blazor is an easy to use dynamic .Net pager libery for Blazor and up, written in C#.

## Frameworks

* .Net Core 3.1 and higher
* .Net Core 2.1 and higher

## Page

### How to use

Install Gobln.Pager.Blazor, trough [Nuget](https://nuget.org/) or other means.

PM > Install-Package Gobln.Pager.Blazor

Use the tag <Pager> and give it the current page and you will get the 10 first items from you page.
To Change the page size or the selected page you only need to add the attribute PagerOptions.
To know the selected page, use the eventcallback attribute OnPageIndexChange.

### Examples

```html

<Pager Page=@pageList.GetCurrentPage() OnPageIndexChange="ChangePageing" />

//with pageoptions
<Pager Page=@pageList.GetCurrentPage() OnPageIndexChange="ChangePageing" PagerOptions="@(new PagerOptions() { ItemShowOrder = new[] { ItemShow.PagesItemsRange } } )" />

```
```csharp
//Code

// Create an List oject
var list = new List<TestModel>()
            {
                new TestModel(){ Id = 1, Name = "Tester1", Date = new DateTime( 2015, 5,1 ) },
                new TestModel(){ Id = 2, Name = "Tester2", Date = new DateTime( 2015, 5,2 ) },
                new TestModel(){ Id = 3, Name = "Tester3", Date = new DateTime( 2015, 5,3 ) },
                new TestModel(){ Id = 4, Name = "Tester4", Date = new DateTime( 2015, 5,4 ) },
                new TestModel(){ Id = 5, Name = "Tester5", Date = new DateTime( 2015, 5,5 ) },
                new TestModel(){ Id = 6, Name = "Tester6", Date = new DateTime( 2015, 5,1 ) },
                new TestModel(){ Id = 7, Name = "Tester7", Date = new DateTime( 2015, 5,2 ) },
                new TestModel(){ Id = 8, Name = "Tester8", Date = new DateTime( 2015, 5,3 ) },
                new TestModel(){ Id = 9, Name = "Tester9", Date = new DateTime( 2015, 5,4 ) },
                new TestModel(){ Id = 10, Name = "Tester10", Date = new DateTime( 2015, 5,5 ) },
            };

// Create an PageList object
var pageList = list.ToPageList();

// Or create an PageList object directly

pageList = new PageList<TestModel>()
            {
                new TestModel(){ Id = 1, Name = "Tester1", Date = new DateTime( 2015, 5,1 ) },
                new TestModel(){ Id = 2, Name = "Tester2", Date = new DateTime( 2015, 5,2 ) },
                new TestModel(){ Id = 3, Name = "Tester3", Date = new DateTime( 2015, 5,3 ) },
                new TestModel(){ Id = 4, Name = "Tester4", Date = new DateTime( 2015, 5,4 ) },
                new TestModel(){ Id = 5, Name = "Tester5", Date = new DateTime( 2015, 5,5 ) },
                new TestModel(){ Id = 6, Name = "Tester6", Date = new DateTime( 2015, 5,1 ) },
                new TestModel(){ Id = 7, Name = "Tester7", Date = new DateTime( 2015, 5,2 ) },
                new TestModel(){ Id = 8, Name = "Tester8", Date = new DateTime( 2015, 5,3 ) },
                new TestModel(){ Id = 9, Name = "Tester9", Date = new DateTime( 2015, 5,4 ) },
                new TestModel(){ Id = 10, Name = "Tester10", Date = new DateTime( 2015, 5,5 ) },
            };

// Create an Page object with pagesize 2 and pageindex 3
pageList = list.ToPage(3, 2);

// Create an Page object from a prepaged list where that the pagesize 10, pageindex 10 and the total item count 100
pageList = list.ToPage(5, 10, 100, prePaged: true);

// Use PageFilter of IPageFilter
var pagerFilter = new PagerFilter()
    {
        PageIndex = 5,
        PageSize = 2
    };

var pageList = testList.ToPage(pagerFilter);


//to change the page

protected void ChangePageing(int pageIndex)
{
    SimpleList.CurrentPageIndex = pageIndex;
}

```

For more examples, check the test project

## Installing Gobln.Pager

The project is on [Nuget](https://www.nuget.org/packages/Gobln.Pager.Blazor/). Install via the NuGet Package Manager.

PM > Install-Package Gobln.Pager

## License

[Apache License, Version 2.0](http://opensource.org/licenses/Apache-2.0).

## Documentation and Readme file

I'm going to provide an documentation file, but haven't started on one yet.
As for the Readme file, if there are any inconsitencies or grammatical errors feel free to let me know by an pull request. This also counts for problems in de code.

## Issues and Contributions

* If something is broken and you know how to fix it, send a pull request.
* If you have no idea what is wrong, create an issue.

## Any feedback and contributions are welcome

If you have something you'd like to improve do not hesitate to send a Pull Request