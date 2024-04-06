/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine($"Output: {numberOfUniqueNumbers}, nums = [{string.Join(",", nums1[..numberOfUniqueNumbers])}]");

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 9, 0, 12, 0 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 0, 1, 1, 0, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 1, 2, 1, 10 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0) return 0; // Handles empty array case

                int k = 1; // Number of unique elements

                // Loop through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // If current element is different from previous unique element
                    if (nums[i] != nums[k - 1])
                    {
                        // Place the current element at index k
                        nums[k] = nums[i];
                        k++; // Increment the count of unique elements
                    }
                }
                return k; // Return the count of unique elements
            }

            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Initialize an index to track the position of the next non-zero element.
                int idx = 0;

                // Loop through the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is not zero, move it to the idx position and increment idx.
                    if (nums[i] != 0)
                    {
                        nums[idx] = nums[i]; // Move the non-zero element.
                        idx++; // Move to the next position.
                    }
                }

                // Fill the remaining positions from idx to the end of the array with zeros.
                while (idx < nums.Length)
                {
                    nums[idx] = 0; // Fill with zeros.
                    idx++; // Move to the next position.
                }

                return new List<int>(nums);


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> tripletsList = new List<IList<int>>(); // List to store triplets
                Array.Sort(nums); // Sort the input array

                // Iterate through the array, leaving out the last two elements to form a triplet
                for (int n = 0; n < nums.Length - 2; n++)
                {
                    // Skip duplicates to avoid duplicate triplets
                    if (n > 0 && nums[n] == nums[n - 1])
                        continue;

                    int leftPointer = n + 1; // Pointer for the element after nums[n]
                    int rightPointer = nums.Length - 1; // Pointer for the last element

                    // Two-pointer approach to find the other two elements
                    while (leftPointer < rightPointer)
                    {
                        int sum = nums[n] + nums[leftPointer] + nums[rightPointer]; // Calculate sum of current triplet

                        // If sum is zero, we found a triplet
                        if (sum == 0)
                        {
                            // Add the triplet to the list of triplets
                            tripletsList.Add(new List<int> { nums[n], nums[leftPointer], nums[rightPointer] });

                            // Avoid duplicates while adjusting the positions of the left pointer and right pointer
                            while (leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer + 1])
                                leftPointer++;
                            while (leftPointer < rightPointer && nums[rightPointer] == nums[rightPointer - 1])
                                rightPointer--;

                            // Move pointers to find other triplets
                            leftPointer++;
                            rightPointer--;
                        }
                        else if (sum < 0)
                        {
                            leftPointer++; // Move left pointer to increase sum
                        }
                        else
                        {
                            rightPointer--; // Move right pointer to decrease sum
                        }
                    }
                }

                return tripletsList; // Return list of unique triplets
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int m = 0; // Stores the maximum count of consecutive 1's
                int c = 0; // Stores the current count of consecutive 1's

                foreach (int n in nums)
                {
                    // If the current element is 1, increment the count
                    if (n == 1)
                    {
                        c++;
                    }
                    else
                    {
                        // If the current element is 0, update m if c is greater,
                        // then reset c to 0
                        m = Math.Max(m, c);
                        c = 0;
                    }
                }

                // Update m if the last sequence of 1's is longer than any previous ones
                m = Math.Max(m, c);
                return m;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int D = 0; // Initialize the decimal value to 0
                int bv = 1; // Initialize the base value to 1

                while (binary != 0)
                {
                    int digit = binary % 10; // Extract the last digit of the binary number
                    binary /= 10; // Remove the last digit from the binary number

                    D += digit * bv; // Update the decimal value
                    bv *= 2; // Update the base value (power of 2)
                }

                return D; // Return the decimal value after conversion

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                    return 0;

                int MG = 0;

                // Find the minimum and maximum elements in the array
                int MinN = nums[0];
                int maxN = nums[0];

                foreach (int x in nums)
                {
                    MinN = Math.Min(MinN, x);
                    maxN = Math.Max(maxN, x);
                }

                // Calculate the size of each group
                int groupSize = Math.Max(1, (maxN - MinN) / (nums.Length - 1));

                // Calculate the number of groups
                int numGroups = (maxN - MinN) / groupSize + 1;

                // Initialize groups
                int[] minGroup = new int[numGroups];
                int[] maxGroup = new int[numGroups];
                bool[] hasValue = new bool[numGroups];

                // Place elements into groups
                foreach (int n in nums)
                {
                    int groupIndex = (n - MinN) / groupSize;
                    minGroup[groupIndex] = hasValue[groupIndex] ? Math.Min(minGroup[groupIndex], n) : n;
                    maxGroup[groupIndex] = hasValue[groupIndex] ? Math.Max(maxGroup[groupIndex], n) : n;
                    hasValue[groupIndex] = true;
                }

                // Calculate the maximum gap
                int prevMax = MinN;
                for (int i = 0; i < numGroups; i++)
                {
                    if (hasValue[i])
                    {
                        MG = Math.Max(MG, minGroup[i] - prevMax);
                        prevMax = maxGroup[i];
                    }
                }

                return MG;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3)
                    return 0; // Return 0 if the array has fewer than 3 elements

                Array.Sort(nums); // Arrange the array elements in ascending order

                // Begin from the end of the sorted array to maximize perimeter
                for (int n = nums.Length - 1; n >= 2; n--)
                {
                    // Verify if the current set of three sides can form a triangle with a non-zero area
                    if (nums[n] < nums[n - 1] + nums[n - 2])
                        return nums[n] + nums[n - 1] + nums[n - 2]; // Provide the perimeter if a triangle can be formed
                }

                return 0; // Return 0 if it's impossible to form a triangle with a non-zero area

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                while (s.Contains(part))
                {
                    int idx = s.IndexOf(part); // Retrieve the index of the earliest instance of part
                    s = s.Remove(idx, part.Length); // Eliminate part from s beginning at idx
                }
                return s; // Yield s after eliminating all instances of part

            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}