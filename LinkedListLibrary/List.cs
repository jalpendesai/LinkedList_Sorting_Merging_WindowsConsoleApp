﻿// Fig. 19.4: LinkedListLibrary.cs
// ListNode, List and EmptyListException class declarations.
using System;

namespace LinkedListLibrary
{
    // class List declaration
    public class List
    {
        private ListNode firstNode;
        private ListNode lastNode;
        private string name; // string like "list" to display
        //public int numberOfElement = 0;  //For calculating number of elements present in the list
        private List mergedList;

        // construct empty List with specified name
        public List(string listName)
        {
            name = listName;
            firstNode = lastNode = null;
        } // end constructor

        // construct empty List with "list" as its name
        public List() : this("list")
        {
        } // end default constructor

        //-------------------------------------------------- Insert Node -----------------------------------------//
        // Insert object at front of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, firstNode refers to new node.
        public void InsertAtFront(object insertItem)
        {
            if (IsEmpty())
            {
                lastNode = new ListNode(insertItem);
                firstNode = lastNode;
            }
            else
                firstNode = new ListNode(insertItem, firstNode);
            //numberOfElement++;
        } // end method InsertAtFront

        // Insert object at end of List. If List is empty, 
        // firstNode and lastNode will refer to same object.
        // Otherwise, lastNode's Next property refers to new node.
        public void InsertAtBack(object insertItem)
        {
            if (IsEmpty())
                firstNode = lastNode = new ListNode(insertItem);
            else
            {
                lastNode.Next = new ListNode(insertItem);
                lastNode = lastNode.Next;
            }
            //numberOfElement++;
        } // end method InsertAtBack

        //------------------------------------------- Remove Node ----------------------------------//
        // remove first node from List
        public object RemoveFromFront()
        {
            if (IsEmpty())
                throw new EmptyListException(name);

            object removeItem = firstNode.Data; // retrieve data

            // reset firstNode and lastNode references
            if (firstNode == lastNode)
                firstNode = lastNode = null;
            else
                firstNode = firstNode.Next;
            //numberOfElement--;

            return removeItem; // return removed data

        } // end method RemoveFromFront

        // remove last node from List
        public object RemoveFromBack()
        {
            if (IsEmpty())
                throw new EmptyListException(name);

            object removeItem = lastNode.Data; // retrieve data

            // reset firstNode and lastNode references
            if (firstNode == lastNode)
                firstNode = lastNode = null;
            else
            {
                ListNode current = firstNode;

                // loop while current.Next is not lastNode
                while (current.Next != lastNode)
                    current = current.Next; // move to next node

                // current is new lastNode
                lastNode = current;
                current.Next = null;
            } // end else
            //numberOfElement--;
            return removeItem; // return removed data
        } // end method RemoveFromBack
        
        //-------------------------------------- Sorting List -------------------------------------------------//
        public List Sort()
        {
            object temp;  //Temporary object
            ListNode currentNode = firstNode;   //Taking currentNode as the firstNode
            ListNode nextNode, minNode;
            int min, currentValue;
            

            //Loop until the currentNode is not empty
            while (currentNode != null)
            {
                // Considering currentNode as the minimum node
                minNode = currentNode;

                // Assigning the node after the currenNode as nextNode
                nextNode = currentNode.Next;

                // Loop until NextNode is not empty
                while (nextNode != null)
                {
                    //Getting Value of nextNode and minimum Node
                    currentValue = Convert.ToInt32(nextNode.Data);
                    min = Convert.ToInt32(minNode.Data);

                    // If minimum node is greater than nextnode
                    // then assign that node to min node
                    if (min > currentValue)
                    {
                        minNode = nextNode;
                    }
                    nextNode = nextNode.Next;
                }

                //Swapping minimumNode & currentNode
                temp = currentNode.Data;
                currentNode.Data = minNode.Data;
                minNode.Data = temp;

                //Next node
                currentNode = currentNode.Next;
            }
            return this;
        }

        //----------------------------------- Merging List ----------------------------------------------//
        public List Merge(List list2)
        {
            mergedList = new List("Merged List");
            List list1 = this;

            // Taking FirstNodes of the lists 
            ListNode currentList1 = list1.firstNode;
            ListNode currentList2 = list2.firstNode;

            // Initializing current with 0
            int currentL1 = 0;
            int currentL2 = 0;

            // Merge list, if the list are not empty
            while (currentList1 != null && 
                   currentList2 != null)
            {
        
                // Getting Value of both currentLists
                currentL1 = Convert.ToInt32(currentList1.Data);
                currentL2 = Convert.ToInt32(currentList2.Data);


                // Sorting the currentNodes and
                // Adding it to the mergedList
                if (currentL1 < currentL2)
                {
                    mergedList.InsertAtBack(currentL1);
                    currentList1 = currentList1.Next;
                }
                else
                {
                    mergedList.InsertAtBack(currentL2);
                    currentList2 = currentList2.Next;
                }
            }

            
            // Adding remaining lists of list1 to mergedList
            while (currentList1 != null)
            {
                currentL1 = Convert.ToInt32(currentList1.Data);
                mergedList.InsertAtBack(currentL1);
                currentList1 = currentList1.Next;
            }

            // Adding remaining lists of list2 to mergedList
            while (currentList2 != null)
            {
                currentL2 = Convert.ToInt32(currentList2.Data);
                mergedList.InsertAtBack(currentL2);
                currentList2 = currentList2.Next;
            }

            return mergedList;
        }

        // return true if List is empty
        public bool IsEmpty()
      {
         return firstNode == null;
      } // end method IsEmpty

      // output List contents
      public void Display()
      {
         if ( IsEmpty() )
         {
            Console.WriteLine( "Empty " + name );
         } // end if
         else
         {
            //Console.Write( "The " + name + " is: " );
            ListNode current = firstNode;
            // output current node data while not at end of list
            while ( current != null )
            {
                    ListNode temp = current;
                    // Convert object to int for converting 
               Console.Write( current.Data + " " );
               current = current.Next;
            } // end while

            //Console.WriteLine( "\n" );
                // Displaying number of elements in the list
                // Console.WriteLine("Number of Elements in List:" + numberOfElement);
         } // end else
      } // end method Display
   } // end class List

   // class EmptyListException declaration
   
} // end namespace LinkedListLibrary

/**************************************************************************
 * (C) Copyright 1992-2014 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
