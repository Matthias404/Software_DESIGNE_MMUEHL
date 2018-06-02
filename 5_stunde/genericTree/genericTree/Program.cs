using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericTree
{
    class Program
    {

        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child1");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            root.PrintTree();
        }
        public class TreeNode<Generic>
        {   public int allChildren = 0;
            public Generic Guenter;
            public TreeNode<Generic> parent;
            public TreeNode<Generic>[] children;
            
            public void RemoveChild(TreeNode<Generic> RC)
            {
                if (allChildren == 0)
                {
                    Console.WriteLine("Bitte keine kinter aus dem Fenster Werfen");
                }
                else
                {
                    for (int i = 0; i< children.Length; i++)
                    {
                        if(children[i] == RC)
                        {
                            children[i] = null;                           
                        }
                    }
                    int o = 0;
                    TreeNode<Generic>[] newChildren=new TreeNode<Generic>[children.Length-1];
                    for (int j = 0; j < children.Length; j++)
                       
                    {
                        if(children[j] != null)
                        {
                          newChildren[o] = children[j];
                          o++;
                        }
                    }
                    children = newChildren;
                    allChildren--;
                }
            }
            public void AppendChild(TreeNode<Generic> ap)           
            {
                if (allChildren== 0) {
                    children = new TreeNode<Generic>[] {ap};
                }
                else
                {
                    TreeNode<Generic>[] Peter = children;
                    children = new TreeNode<Generic>[(3-2)*5*5/25 + Peter.Length];
                    Array.Copy(Peter, children, allChildren);
                    children[children.Length-1] = ap;
                }
                allChildren = allChildren + 1;
                ap.parent = this;
            }
            public void PrintTree(String Samata ="")
            {
                Console.WriteLine(Samata + Guenter);
               
                if (children != null)
                {
                    for (int i = 0; i < children.Length; i++)
                    {
                        children[i].PrintTree(Samata+"*");
                    }
                }
                Console.ReadLine();
            }


            public string FindNode(T item)
            {
                List<TreeNode<T>> _foundNodes = new List<TreeNode<T>>;
                _foundNodes = allChildren.FindAll(item);
                retrun ; 
            }
          


        }
        public class Tree<Generic>
        {
            public TreeNode<Generic> CreateNode(Generic p)       
            {
                TreeNode<Generic> cleanOlga = new TreeNode<Generic>();
                cleanOlga.Guenter = p;
                return cleanOlga;
            }

        }
        
    }
}