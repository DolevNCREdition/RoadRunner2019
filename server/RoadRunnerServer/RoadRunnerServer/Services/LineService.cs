using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Services
{
    public class LineService : ILineService
    {
        private readonly ICustomerOrderDataBase _db;
        private readonly ISellingPipeline _sellingPipeline;

        public LineService(ICustomerOrderDataBase db, ISellingPipeline sellingPipeline)
        {
            _sellingPipeline = sellingPipeline;
            _db = db;
        }


        public IEnumerable<Product> GetCustomerOrder()
        {
            return _db.GetAll();
        }

        public async Task<bool> AppendLineAsync(LineTypeEnum lineType, int productId)
        {
            var pipelineItem = new PipelineItem
            {
                ItemId = productId,
                ItemType = lineType,
            };
            return  await _sellingPipeline.ProcessLine.SendAsync(pipelineItem);
        }

        public void CloseTransaction()
        {
            var allItems = _db.GetAll().ToList();
            for (int i = 0; i < allItems.Count; i++)
            {
                _db.Remove(i);
            }            
        }
    }

    
}
