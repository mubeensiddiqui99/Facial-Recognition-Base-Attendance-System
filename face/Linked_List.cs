using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
namespace face
{
    [Serializable]
    public class ListNode<T> //T is the generic type.
            {
                public ListNode(T elem) { val = elem; prev = next = null; }
                public T val; //node data
                public ListNode<T> prev;//previous link
                public ListNode<T> next;//next link
            }
    [Serializable]
    class Linked_List<T>
            {
                public Linked_List() 
                { 
                   pfirst = plast = null;
                   count = 0;
                }
                protected ListNode<T> pfirst;
                protected ListNode<T> plast;
                protected int count;
                public void Add(T val)
                {
                    ListNode<T> newnode = new ListNode<T>(val);
                    //empty list
                    if (pfirst == null && plast == null)
                    {
                        pfirst = newnode;
                        plast = newnode;
                    }
                    else
                    {
                        newnode.next = null; //The next link of the item is null.
                        plast.next = newnode;
                        newnode.prev = plast;
                        plast = newnode;
                    }
                }
                public void showall()
                {
                    ListNode<T> t;
                    if (countitem() > 0)
                    {
                        Console.WriteLine("All items in the list:");
                        for (t = pfirst; t != null; t = t.next)
                        {

                            Console.WriteLine(t.val);
                        }
                    }
                    else Console.WriteLine("No item found!");
                }
                public int countitem()
                {
                    ListNode<T> i;
                    int t = 0;
                    for (i = pfirst; i != null; i = i.next)
                    {
                        t = t + 1;
                    }
                    return t;
                }
                public ListNode<T> getHead()
                {
                    return pfirst;
                }
                public void delete(ListNode<T> rn)
                {
                    ListNode<T> temp=pfirst;
                    while(temp!=null)
                   {
                        if (temp==rn)
                        {
                            if(temp==pfirst)
                            {
                                temp.next.prev = null;
                                pfirst = temp.next;
                                break;
                            }
                            if (temp == plast)
                            {
                                MessageBox.Show("here");
                                temp.prev.next = null;
                                plast = temp.prev;
                                break;
                            }
                            else
                            {
                                temp.prev.next = temp.next;
                                temp.next.prev = temp.prev;
                            }
                        }
                        temp = temp.next;
                   }
                }
            }
}
