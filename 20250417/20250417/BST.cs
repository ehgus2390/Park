/***********************************************************
[이진탐색트리]
- 이진 속성과 탐색 속성을 적용한 트리
- 이진 탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
- 이진 : 부모노드는 최대 2개의 자식노드를 가질수 있다.
- 탐색 : 자신의 노드보다 작은 값은 왼쪽, 큰값은 오른쪽에 위치

<이진 탐색 트리 탐색>
- 아래의 이진탐색 트리에서 17탐색
- 루트 노드부터 시작해서 탐색하는 값과 비교
- 작은 경우 왼쪽 자식노드로, 큰 경우 자식노드를 탐색

<이진 탐색트리 삽입>
- 아래의 이진탐색트리에서 35 삽입한다면
- 루트 노드부터 시작해서 삽입하는 값과 비교
- 작은경우 왼쪽, 큰 경우 오른쪽으로 하강
- 만약 빈공간이라면 빈 공간에 삽입

<이진 탐색트리 삭제>
1. 자식이 0개인 노드의 삭제 : 단순삭제
2. 자식이 1개인 노드의 삭제라면 (만약 38을 삭제하려면?)
ㄴ 삭제하는 노드를 기준으로 오른쪽 자식중 가장 작은 값 노드와 교체 후 삭제


3. 자식 1개인 경우 : 삭제하는 노드의 부모와 자식을 연결후 삭제.

***********************************************************/

namespace _20250417
{
    internal class CBST
    {
        public class BinarySearchTree<T> where T: IComparable<T>
        {
            private class Node
            {
                public T item;
                public Node parent;
                public Node left;
                public Node right;
                //노드 생성자
                public Node(T item, Node parent, Node left, Node right)
                {
                    this.item = item;
                    this.parent = parent;
                    this.left = left;
                    this.right = right;
                }
            }
            private Node root;     //트리의 루트노드(가장 상위노드)

            public BinarySearchTree()
            {
                root = null; 
            }
            public bool Add(T item)
            {
                if (root == null)
                {
                    Node newNode = new Node(item, null, null, null);
                    root = newNode;
                    return true;
                }
                Node current = root;

                while (current != null)
                {
                    if (item.CompareTo(current.item)<0)
                    {
                        if (current.left == null)
                        {
                            Node newNode = new Node(item, null, null, null);
                            current.left = newNode;
                            newNode.parent = current;
                            return true;
                        }
                        current = current.left;
                    }
                    else if (item.CompareTo(current.item)>0)
                    {
                        if (current.right == null)
                        {
                            Node newNode = new Node(item, null, null, null);
                            current.right = newNode;
                            newNode.parent = current;
                            return true;
                        }
                        current = current.right;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }//And of Add

            public bool Remove(T item)
            { 
                Node findNode = FindNode(item);
                if (findNode != null)
                { 
                    EraseNode(findNode);
                    return true;  //리턴트루
                }
                return false;   //아니면 리턴펄스
            }
            //특정 값이 트리에 존재하는 확인하는 메서드
            public bool Contains(T item)
            { 
                Node findNode = FindNode(item);
                return findNode != null;
            }
            //특정값을 가진 노드를 찾는 메서드
            private Node FindNode(T item)
            {
                if (root == null) return null;
                Node current = root;
                while (current != null)
                {
                    //왼쪽
                    if (item.CompareTo(current.item) < 0)
                    {
                        current = current.left;
                    }
                    //오른쪽
                    else if (item.CompareTo(current.item) > 0)
                    {
                        current = current.right;
                    }
                    else
                    {
                        return current;
                    }
                }
                return null;
            }
            private void EraseNode(Node node) 
            {
                //1.삭제할 노드가 자식이 없는경우(리프노드)
                if (node.left == null && node.right == null)
                {
                    Node parent = node.parent;
                    //삭제할 노드가 루트인 경우
                    if (parent == null)
                    {
                        root = null;
                    }
                    //삭제할 노드가 부모의 왼쪽 자식
                    else if (parent.left == node)
                    {
                        parent.left = null;
                    }
                    //삭제할 노드가 부모의 오른쪽 자식
                    else if (parent.right == node)
                    {
                        parent.right = null;
                    }
                }
                //2.삭제할 노드가 하나의 자식만 가지는 경우
                else if (node.left != null || node.right != null)
                {
                    Node parent = node.parent;
                    //왼쪽자식이 없으면 오른쪽 자식을 선택
                    Node child = node.left != null ? node.left : node.right;

                    if (parent == null)
                    {
                        root = child;
                        child.parent = null;
                    }
                    //삭제할 노드가 부모의 왼쪽이면
                    else if(parent.left == node)
                    {
                        parent.left = child;
                        child.parent = parent;
                    }
                    else if(parent.right == node)
                    {
                        parent.right = child;
                        child.parent = parent;
                    }

                }
                //3.삭제할 노드가 두개의 자식을 가지는 경우
                else
                {
                    Node nextNode = node.right;
                    while (nextNode.left != null)
                    {
                        nextNode = nextNode.left;
                    }
                    node.item = nextNode.item;
                    EraseNode(nextNode);
                }
            }

            //중위순회
            public void InorderTraversal()
            {
                InorderTraversal(root);
            }
            private void InorderTraversal(Node node)
            {
                if (node == null) return;
                InorderTraversal(node.left);
                Console.Write(node.item + " ");
                InorderTraversal(node.right);
            }

            //전위순회
            public void PreOrderTraversal()
            {
                PreOrderTraversal(root);
            }
            private void PreOrderTraversal(Node node)
            {
                if (node == null) return;
                Console.Write(node.item + " ");
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }
            //후위순회
            public void PostOrderTraversal()
            {
                PostOrderTraversal(root);
            }
            private void PostOrderTraversal(Node node)
            {
                if (node == null) return;
                PostOrderTraversal(node.left);
                PostOrderTraversal(node.right);
                Console.Write(node.item + " ");
            }
        }
        
        static void Main()
        {
            //이진탐색기반으로 만들어진것.
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(30);
            bst.Add(70);
            bst.Add(20);
            bst.Add(40);
            bst.Add(60);
            bst.Add(80);

            Console.WriteLine();
            Console.WriteLine("중위순회");
            bst.InorderTraversal();
            Console.WriteLine();
            Console.WriteLine("전위순회");
            bst.PreOrderTraversal();
            Console.WriteLine();
            Console.WriteLine("후위순회");
            bst.PostOrderTraversal();

            Console.WriteLine();
            Console.WriteLine(bst.Contains(40));
            Console.WriteLine(bst.Contains(90));

            bst.Remove(20);
            Console.WriteLine(bst.Contains(20));
        }
    }
}
