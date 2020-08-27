namespace Red_BlackTree
{
    internal class Node<T>
    {
        // Fields
        private T item; // Generic object held by each node

        private Node<T> left, right, parent; // Links to children and parent
        private bool red = true; // Color of node

        // Constructor
        public Node(T item, Node<T> parent)
        {
            this.item = item;
            this.parent = parent;
            left = right = null;
        }

        // Properties
        public Node<T> Left
        {
            get
            { return left; }
            set
            { left = value; }
        }

        public Node<T> Right
        {
            get
            { return right; }
            set
            { right = value; }
        }

        public Node<T> Parent
        {
            get
            { return parent; }
            set
            { parent = value; }
        }

        public bool Red
        {
            get
            { return red; }
            set
            { red = value; }
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        // Similar get/set properties for Item and Red
    }
}