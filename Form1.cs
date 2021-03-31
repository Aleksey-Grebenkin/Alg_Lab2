using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alg_Lab2
{
    public partial class Form1 : Form
    {
        TwoThreeFourTree tree;
        public Form1()
        {
            InitializeComponent();
            tree = null;
            treeView1.ShowLines = false;
            treeView1.ShowPlusMinus = false;
        }
        private void RenderTree()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            if (tree != null)
                AddInTree(TwoThreeFourTree.GetHead(tree));
            treeView1.EndUpdate();
            treeView1.ExpandAll();
        }

        private void AddInTree(TwoThreeFourTree tree, TreeNode parent = null)
        {
            string text ="(";
            for (int i = 0; i < tree.Values.Count; i++)
            {
                text += tree.Values[i];
                if (i != tree.Values.Count-1)
                    text += ";";
            }
            text += ")";
            var node = new TreeNode(text);

            if (tree.Parent == null)
            {
                treeView1.Nodes.Add(node);
            }
            else
            {
                parent.Nodes.Add(node);
            }

            parent = node;
            if (tree.Children[0] != null)
                AddInTree(tree.Children[0], parent);
            if (tree.Children[1] != null)
                AddInTree(tree.Children[1], parent);
            if (tree.Children[2] != null)
                AddInTree(tree.Children[2], parent);
            if (tree.Children[3] != null)
                AddInTree(tree.Children[3], parent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = Int32.Parse(textBox1.Text);
            if (tree == null)
                tree = new TwoThreeFourTree(value);
            else
                TwoThreeFourTree.Add(value,tree);
            RenderTree();
        }
    }
}
