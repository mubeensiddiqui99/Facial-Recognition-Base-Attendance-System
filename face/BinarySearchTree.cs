using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace face
{
     class BinNode
    {
        //constructors
        public BinNode(Student data)
        {
            this.data = data;
        }
        public BinNode() { }
        //properties 
        public BinNode right { get; set; } = null;
        public BinNode left { get; set; } = null;
        public Student data { get; set; }
    }


     class BinarySearchTree
    {
        public BinNode root { get; set; } = null;
        //normal insertion method (inserts T data into a bst instance)
        public void Insert(Student data)
        {
            if (root == null)
            {
                root = new BinNode(data);
            }

            BinNode current = root;

            while (current != null)
            {
                if (string.Compare(data.get_rollno(), current.data.get_rollno()) == 1)
                {
                    if (current.right != null)
                    {
                        current = current.right;
                        continue;
                    }
                    current.right = new BinNode(data);
                }

                else if (string.Compare(data.get_rollno(), current.data.get_rollno()) == -1)
                {
                    if (current.left != null)
                    {
                        current = current.left;
                        continue;
                    }
                    current.left = new BinNode(data);
                }

                else
                {
                    return;
                }

            }
        }
        public void preorder(BinNode root)
        {
            MessageBox.Show(root.data.get_rollno());
            if (root.left != null)
                preorder(root.left);
            if (root.right != null)
                preorder(root.right);
        }
        //insert all elements from an array
        public void InsertFromArray(Student[] array)
        {
            foreach (Student t in array)
            {
                this.Insert(t);
            }
        }
        public BinNode FindByValue(string data)
        {
            if (root == null)
                return null;
            BinNode temp = root;
            while (temp != null)
            {
                if (string.Compare(data, temp.data.get_rollno()) == 0)
                {
                    return temp;
                }
                if (string.Compare(data, temp.data.get_rollno()) == 1)
                {
                    temp = temp.right;
                }
                else
                {
                    temp = temp.left;
                }
            }
            return null;
        }

    }
}