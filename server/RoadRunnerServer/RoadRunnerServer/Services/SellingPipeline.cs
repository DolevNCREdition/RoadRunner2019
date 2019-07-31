using System;
using System.Threading.Tasks.Dataflow;
using RoadRunnerServer.Shared;

namespace RoadRunnerServer.Services
{
    public class SellingPipeline: ISellingPipeline
    {
        private readonly ICustomerOrderDataBase _db;
        private readonly BufferBlock<ItemLine> _input;
        public ITargetBlock<ItemLine> ProcessLine => _input;

        public SellingPipeline(ICustomerOrderDataBase db)
        {
            _db = db;
            _input = new BufferBlock<ItemLine>();
            var saveToDb = new ActionBlock<ItemLine>(itemLine=> SaveToDb(itemLine));
            _input.LinkTo(saveToDb);
        }



        private void SaveToDb(ItemLine itemLine)
        {
            _db.Append(itemLine);
        }
    }
}



;
