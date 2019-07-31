using System;
using System.Collections.Generic;


namespace RoadRunnerServer.Shared
{
    public class PipelineItem
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int ItemId { get; set; }
        public LineTypeEnum ItemType { get; set; }

        public List<object> Bag { get; } = new List<object>();
    }
}
