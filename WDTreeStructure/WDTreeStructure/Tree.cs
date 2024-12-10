using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDTreeStructure
{
    class Tree
    {
        public TreeNode Root { get; private set; }

        public void BuildFromFile(string filename)
        {
            var lines = File.ReadAllLines(filename);
            Queue<TreeNode> nodes = new Queue<TreeNode>();

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                var newNode = new TreeNode(trimmedLine);
                nodes.Enqueue(newNode);
            }

            if (nodes.Count > 0)
            {
                Root = nodes.Dequeue();

                var levelNodes = new Queue<TreeNode>();
                levelNodes.Enqueue(Root);

                while (nodes.Count > 0)
                {
                    var parent = levelNodes.Dequeue();
                    var childCount = Math.Min(2, nodes.Count); // Adjust number of children as needed

                    for (int i = 0; i < childCount; i++)
                    {
                        var child = nodes.Dequeue();
                        parent.AddChild(child);
                        levelNodes.Enqueue(child);
                    }
                }
            }
        }

        public void Display()
        {
            if (Root != null)
            {
                Root.Display();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }
    }

}
