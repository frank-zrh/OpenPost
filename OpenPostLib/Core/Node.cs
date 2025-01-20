using System;
using System.Collections.Generic;

namespace OpenPostLib.Core
{
    public class Node
    {
        public Node? Parent { get; set; }
        public Dictionary<string, Node> SubNodes { get; }

        public Guid ID { get; } = Guid.NewGuid();

        public Node()
        {
            SubNodes = new Dictionary<string, Node>();
        }

        public virtual Node? Route(string key)
        {
            // Get one sub node by the key
            if (SubNodes.TryGetValue(key, out var node))
            {
                return node;
            }

            //return the first one if SubNodes is not empty
            if (SubNodes.Count > 0)
            {
                foreach (var subNode in SubNodes)
                {
                    return subNode.Value;
                }
            }

            return null;
        }
    }
}