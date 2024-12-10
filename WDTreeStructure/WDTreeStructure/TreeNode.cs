using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDTreeStructure
{
    internal class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string name)
        {
            Name = name;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }

        public void Display(int level = 0)
        {
            Console.WriteLine(new string(' ', level * 4) + "- " + Name);
            foreach (var child in Children)
            {
                child.Display(level + 1);
            }
        }
    }
}
