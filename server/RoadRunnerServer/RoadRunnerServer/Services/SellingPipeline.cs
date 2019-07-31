using System;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using RoadRunnerServer.Shared;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RoadRunnerServer.Services
{
    public class SellingPipeline: ISellingPipeline
    {
        private readonly ICustomerOrderDataBase _db;
        private readonly IProductService _productService;
        public DateTime LastUpdated { get; private set; }

        private readonly BufferBlock<PipelineItem> _input;
        public ITargetBlock<PipelineItem> ProcessLine => _input;

        public SellingPipeline(ICustomerOrderDataBase db, IProductService productService)
        {
            _db = db;
            _productService = productService;

            _input = new BufferBlock<PipelineItem>();
            var resolveItem = new TransformBlock<PipelineItem, PipelineItem>( pi => ResolveItem(pi));           
            var saveToDb = new ActionBlock<PipelineItem>(async pi => await SaveToDb(pi));
            _input.LinkTo(resolveItem, new DataflowLinkOptions { PropagateCompletion = true});
            resolveItem.LinkTo(saveToDb);
        }

        private async Task<PipelineItem> ResolveItem(PipelineItem pipelineItem)
        {
            await Task.Delay(1000);
            var product = _productService.GetProduct(pipelineItem.ItemId);
            pipelineItem.Bag.Add(product);
            pipelineItem.Bag.Add(product);
            return pipelineItem;
        }


        private async Task SaveToDb(PipelineItem pipelineItem)
        {
            await Task.Delay(1000);
            var product = pipelineItem.Bag.OfType<Product>().FirstOrDefault();
            if (product != null)
            {
                var orderLine = new ItemLine { Id = pipelineItem.ItemId, Name = product.Name, Price = product.Price, ProductId = product.Id };
                _db.Append(orderLine);
                LastUpdated = DateTime.Now;
            }
            else
            {
                Trace.Write($"Error no Item to save !!!");
            }

        }
    }
}



;
