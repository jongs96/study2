using System;

namespace LinkedList
{//경력자 뽑을 경우 linked list 구현을 시키기도함.
    class Node<T>
    {
        public T v;
        public Node<T> next;
        public Node(T n)//생성자
        {
            v = n;
            next = null;
        }
    }

    class LinkedList<T>
    {//단방향 Linked list, 이전에 generic으로 사용한것은 양방향 
        Node<T> head = null;
        int count = 0;
        public int Count
        {
            get => count;
        }
        public T this[int n]//list[i]형식으로 불러 사용하기 위해 프로퍼티를 만든다.
        {//this : 해당 인스탄스를 말하는 것
            get => Get(n);
            set => Set(n, value);
        }
        public void Add(T n)
        {//꼬리를 찾고 next에 다음 노드를 이어줌
            count++;
            Node<T> node = head;
            while(node != null)
            {
                if(node.next == null)
                {
                    node.next = new Node<T>(n);
                    return;
                }
                node = node.next;
            }
            head = new Node<T>(n);//head가 null일경우
        }

        public T Get(int n)
        {
            int i = 0;//리스트넘버
            Node<T> node = head;//node라는 Node클래스변수 생성 head부터 연결리스트순차로 이동.
            while(node != null)//next값이 null일때
            {
                if (i == n)//넘버값 입력받은 n일때, 
                {
                    return node.v;//node 의 value값 return
                }
                i++;
                node = node.next;
            }
            return default(T);//head가 null일경우
        }

        public void Set(int n, T v)
        {
            int i = 0;
            Node<T> node = head;
            while (node != null)
            {
                if (i == n)
                {
                    node.v = v;
                }
                i++;
                node = node.next;
            }
        }//해당 인덱스에 새로운 값이 들어가는 함수 구현.
    }
    class Program
    {
        static void Main(string[] args)
        {//node : 값을 저장하는 변수,value + next(다음값위치참조) >>class 형태로 만들어짐
         //배열처럼 연속된 상자인 것처럼 연결이 일어나는 형태
         //첫번째 node : Head 에서 next확인 ... 확인 next 에 null 값이 있다면 tail 마지막값임.
         //추가(add) : 맨 마지막 꼬리에 추가.
            LinkedList<string> list = new LinkedList<string>();
            list.Add("aa");
            list.Add("bb");
            list.Add("cc");

            list.Set(0, "Kim");//첫번째 값이 kim으로 변경되는 함수구현해오기

            for (int i =0; i<list.Count; ++i)
            {
                Console.Write($"[{list[i]}]");
            }
            Console.WriteLine();
        }
    }
}
