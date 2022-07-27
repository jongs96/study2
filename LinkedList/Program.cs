using System;

namespace LinkedList
{//경력자 뽑을 경우 linked list 구현을 시키기도함.
    class Node<T>//(<T>템플릿 익숙해지기)인스탄스로 만들어지는 Node class
    {
        public T v;
        public Node<T> next;//인스탄스 내에 v, next 존재. v : value, n : next adress
        public Node(T n)//생성자
        {
            v = n;
            next = null;
        }
    }

    class LinkedList<T>
    {//단방향 Linked list, 이전에 generic으로 사용한것은 양방향 
        Node<T> head = null;//처음 생기는 상자(List). 해당 값만 가지고 있으면 된다.
                            //다음 주소값으로 계속 이어져 있기 때문에.
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
            //class로 만든 node 변수는 '참조형 변수' >> 주소값을 가지고 있는 변수
            //c#은 주소값을 알수는 없음. 포인터와 비교하지말고 그냥 주소를 가진 변수다 
            //new Node<T> 이런식의 변수는 인스턴스가 생성됨.
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
                    return;//함수 바로 종료.
                }
                i++;
                node = node.next;
            }
        }//해당 인덱스에 새로운 값이 들어가는 함수 구현.

        public void Remove(T v)
        {
            Node<T> node = head;
            Node<T> prev = null;//이전값 선언
            while(node != null)
            {
                if(node.v.Equals(v))//T의 타입이 정해져있지 않은 상황에서 
                {
                    if(prev == null)//예외사항1: head 가 지워지는 경우
                    {
                        head = node.next;
                    }
                    else
                    {
                        prev.next = node.next; //제거할 노드v 를 찾으면 이전값 주소 = 다음값 주소
                    }//꼬리가 지워지는 경우 이전 값에 null이 잘 들어감.
                    count--;
                    return;
                }
                prev = node; //참조가 바뀌기전에 이전값 저장
                node = node.next;
            }
        }
        public void RemoveAt(int n)
        {
            Node<T> node = head;
            Node<T> prev = null;
            int i = 0;
            while(node != null)
            {
                if(i==n)
                {
                    if(prev == null)
                    {
                        head = node.next;
                    }
                    else
                    {
                        prev.next = node.next;
                    }
                    count--;
                    return;
                }
                prev = node;
                node = node.next;
                i++;
            }
        }
        public delegate bool Equal(T n);
        public void RemoveAll(Equal func)
        {
            Node<T> node = head;
            Node<T> prev = null;
            while(node != null)
            {
                if(func(node.v))
                {
                    if(prev == null)
                    {
                        head = node.next;
                    }
                    else
                    {
                        prev.next = node.next;
                    }
                    node = node.next;
                    count--;
                    continue;
                }
                prev = node;
                node = node.next;
            }
        }
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
            list.Add("aa");
            list.Add("bb");
            list.Add("bb");
            list.Add("aa");
            list.Add("bb");
            list.Add("cc");
            list.Add("cc");

            //list[2]= ("Kim");//값이 kim으로 변경되는 함수구현해오기
            //list.Remove("cc");
            //list.RemoveAt(2);
            list.RemoveAll(v => v == "bb");

            for (int i =0; i<list.Count; ++i)
            {
                Console.Write($"[{list[i]}]");
            }
            Console.WriteLine();
        }
    }
}
//참조의 개념을 그림으로 이해하기.

//Linked list
//배열보다 공간활용도가 좋다
//탐색시간 좋지않다. head로부터 계속 출발해나가야하기때문에

//이진트리
//:작으면 왼쪽 크면 오른쪽 형태의 다리가 2개인 트리구조의 자료구조
//Red black tree 알고리즘을 통해서 균형잡힌 이진트리를 만들 수 있다.