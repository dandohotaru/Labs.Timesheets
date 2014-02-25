using System;
using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Models
{
    public class TagModel : IModel
    {
        public Guid TagId { get; set; }

        public string TagName { get; set; }
    }
}