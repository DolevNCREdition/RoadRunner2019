using System;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Services
{
    public class SellingPipeline: ISellingPipeline
    {
        private readonly ICustomerOrderDataBase _db;
        private readonly IProductService _productService;

        private readonly BufferBlock<PipelineItem> _input;
        public ITargetBlock<PipelineItem> ProcessLine => _input;

        public SellingPipeline(ICustomerOrderDataBase db, IProductService productService)
        {
            _db = db;
            _productService = productService;

            _input = new BufferBlock<PipelineItem>();
            var resolveItem = new TransformBlock<PipelineItem, PipelineItem>( pi => ResolveItem(pi));           
            var saveToDb = new ActionBlock<PipelineItem>(pi=> SaveToDb(pi));
            _input.LinkTo(resolveItem);
            resolveItem.LinkTo(saveToDb);
        }

        private PipelineItem ResolveItem(PipelineItem pipelineItem)
        {
            var product = _productService.GetProduct(pipelineItem.ItemId);
            pipelineItem.Bag.Add(pipelineItem.ItemType, product);
            pipelineItem.Bag.Add(pipelineItem.ItemType, product);
            return pipelineItem;
        }


        private void SaveToDb(PipelineItem pipelineItem)
        {
            if (pipelineItem.Bag[LineTypeEnum.Product] is Product product)
            {
                var orderLine = new ItemLine { Id = pipelineItem.ItemId, Name = product.Name, Price = product.Price };
                _db.Append(orderLine);
            }
            else
            {
                Trace.Write($"Error no Item to save !!!");
            }
        }
    }
}



;
