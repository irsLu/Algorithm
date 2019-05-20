  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }

class Solution
{
    public ListNode mergeKLists(ListNode[] lists)
    {
        if (lists == null)
            return null;

        if (lists.Length == 1)
            return lists[0];

        if (lists.Length == 2)
            return merge2Lists(lists[0], lists[1]);

        int mid = lists.Length / 2;

        ListNode[] l1 = new ListNode[mid];

        for (int i = 0; i < mid; i++)
            l1[i] = lists[i];

        ListNode[] l2 = new ListNode[lists.Length - mid];

        for (int i = mid, j = 0; i < lists.Length; i++, j++)
            l2[j] = lists[i];

        return merge2Lists(mergeKLists(l1), mergeKLists(l2));

    }

    public ListNode merge2Lists(ListNode l1, ListNode l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        ListNode head = null;

        if (l1.val <= l2.val)
        {
            head = l1;
            head.next = merge2Lists(l1.next, l2);
        }
        else
        {
            head = l2;
            head.next = merge2Lists(l1, l2.next);
        }

        return head;
    }
}