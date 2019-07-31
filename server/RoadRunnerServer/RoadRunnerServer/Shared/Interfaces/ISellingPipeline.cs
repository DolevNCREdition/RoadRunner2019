using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace RoadRunnerServer.Shared
{
    public interface ISellingPipeline
    {
        ITargetBlock<PipelineItem> ProcessLine { get; }
    }
}
