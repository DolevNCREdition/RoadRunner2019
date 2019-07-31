using System;
using System.Collections.Generic;


namespace RoadRunnerServer.Shared
{
    public class PipelineItem
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int ItemId { get; set; }
        public LineTypeEnum ItemType { get; set; }

        public Dictionary<LineTypeEnum, object> Bag { get; } = new Dictionary<LineTypeEnum, object>();
    }
}
