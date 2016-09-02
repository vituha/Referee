using QuickGraph;
using System;

namespace Walker
{
    class ReferencesWalker
    {
        public ArrayBidirectionalGraph<string, TaggedEdge<string, int>> Walk(string path)
        {
            return
                new BidirectionalGraph<string, TaggedEdge<string, int>>()
                    .ToArrayBidirectionalGraph();
        }
    }
}