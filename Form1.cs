﻿using System;
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
                AddInTree(tree);
            treeView1.EndUpdate();
            treeView1.ExpandAll();
        }

        private void AddInTree(TwoThreeFourTree tree, TreeNode parent = null)
        {
            var node = new TreeNode("("+tree.ValueLeft.ToString()+","+ tree.ValueMiddle.ToString() + "," + tree.ValueRight.ToString() + ")");
            node.ForeColor = Color.White;

            if (tree.Parent == null)
            {
                treeView1.Nodes.Add(node);
            }
            else
            {
                parent.Nodes.Add(node);
            }
            parent = node;
            if (tree.Left != null)
                AddInTree(tree.Left, parent);
            if (tree.MiddleLeft != null)
                AddInTree(tree.MiddleLeft, parent);
            if (tree.MiddleRight != null)
                AddInTree(tree.MiddleRight, parent);
            if (tree.Right != null)
                AddInTree(tree.Right, parent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = Int32.Parse(textBox1.Text);
            if (tree == null)
                tree = new TwoThreeFourTree(value);
            else
                tree.Add(value);
            RenderTree();
        }
    }
}
