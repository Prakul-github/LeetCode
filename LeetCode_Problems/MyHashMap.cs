using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    public class KeyValue
    {
        public int Key;
        public int Value;
        public KeyValue(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }
    public class MyHashMap
    {

        private List<KeyValue> dataDictionary;
        
        /** Initialize your data structure here. */
        public MyHashMap()
        {
            dataDictionary = new List<KeyValue>();
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            for (int iLoop = 0; iLoop < dataDictionary.Count; iLoop++)
            {
                if (dataDictionary[iLoop].Key == key)
                {
                    KeyValue kValue = dataDictionary[iLoop];
                    kValue.Value = value;
                    return;
                }
            }

            dataDictionary.Add(new KeyValue(key, value));
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            for (int iLoop = 0; iLoop < dataDictionary.Count; iLoop++)
            {
                if (dataDictionary[iLoop].Key == key)
                {
                    return dataDictionary[iLoop].Value;
                }
            }

            return -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            int result = -1;
            for (int iLoop = 0; iLoop < dataDictionary.Count; iLoop++)
            {
                if (dataDictionary[iLoop].Key == key)
                {
                    result = iLoop;
                    break;
                }
            }

            if(result != -1)
                dataDictionary.RemoveAt(result);
        }
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */
}
