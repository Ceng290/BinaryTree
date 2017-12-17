using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        Tree MyTree;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num;
            lbArray1.Text = "";
            label2.Text = "";
            num = rnd.Next(0, 100);
            lbArray1.Text = lbArray1.Text + num.ToString().PadLeft(3);
            MyTree = new Tree(num);

            int n = Convert.ToInt32(textBox1.Text);
            for (int i = 1; i < n; i++)
            {
                num = rnd.Next(0, 100);
                lbArray1.Text = lbArray1.Text + num.ToString().PadLeft(3);
                MyTree.AddRc(num);
            }

            string treestring = "";
            MyTree.Print(null, ref treestring);
            label2.Text = treestring;
        }
    }

    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }

    class Tree
    {
        Node top;
        public Tree()
        {
            top = null;
        }
        public Tree(int initial)
        {
            top = new BinaryTree.Node(initial);
        }
        public void Add(int value)
        {
            //non-recursive add
            if (top == null) //tree is empty
            {
                //Add item as the base node
                Node NewNode = new BinaryTree.Node(value);
                top = NewNode;
                return;
            }
            Node currentnode = top;
            bool added = false;
            do
            {
                // traverse tree
                if (value < currentnode.value)
                {
                    if (currentnode.left == null)
                    {
                        Node NewNode = new Node(value);
                        currentnode.left = NewNode;
                        added = true;
                    }
                    else
                    {
                        currentnode = currentnode.left;
                    }
                }
                if (value >= currentnode.value)
                {
                    if (currentnode.right == null)
                    {
                        Node NewNode = new Node(value);
                        currentnode.right = NewNode;
                        added = true;
                    }
                    else
                    {
                        currentnode = currentnode.right;
                    }
                }
            } while (!added);
        }
        public void AddRc(int value)
        {
            //recursive add
            AddR(ref top, value);
        }
        private void AddR(ref Node N, int value)
        {
            //private recursive search for where to add the new node
            if (N == null)
            {
                //Node doesn't exist add it here
                Node NewNode = new Node(value);
                N = NewNode; //Set the old Node reference to the newly created node thus attaching it to the three
                return; //End the function call and fall back
            }
            if (value < N.value)
            {
                AddR(ref N.left, value);
                return;
            }
            if(value >= N.value)
            {
                AddR(ref N.right, value);
                return;
            }
        }
        public void Print(Node N, ref string s)
        {
            //write out the tree in sorted order to the string newstring
            //implement using recursion
            if (N == null) { N = top; }
            if (N.left != null)
            {
                Print(N.left, ref s);
                s = s + N.value.ToString().PadLeft(3);
            }
            else
            {
                s = s + N.value.ToString().PadLeft(3);
            }
            if (N.right != null)
            {
                Print(N.right, ref s);

            }
        }
    }








}
