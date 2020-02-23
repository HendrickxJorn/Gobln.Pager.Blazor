using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gobln.Pager.BlazorCore31Test.Json
{
    public class TestDataLine
    {
        public int Index { get; set; }

        public Guid Guid { get; set; }

        public bool IsActive { get; set; }

        public int Age { get; set; }

        [Description("Name of tester")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        [Display(Name = "Creation Date", Description = "Date when this is created")]
        public DateTime Registered { get; set; }
    }
}
