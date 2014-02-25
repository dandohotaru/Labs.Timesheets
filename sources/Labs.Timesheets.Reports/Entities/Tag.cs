using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Entities
{
    public class Tag : Entity
    {
        public string Name { get; protected set; }

        public string Notes { get; protected set; }
    }
}