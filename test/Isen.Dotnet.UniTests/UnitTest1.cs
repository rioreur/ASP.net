using System;
using Xunit;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.UniTests
{
    public class myLibraryStringTest
    { 
        private static MyCollection<string> TestList
        {
            get
            {
                var array = new string[] {"Je", "suis", "presque", "une", "phrase"};
                MyCollection<string> myCollection = new MyCollection<string>(array);
                return myCollection;
            }
        }

        [Fact]
        public void AddTest()
        {
            var MyCollection = TestList;
            MyCollection.Add("mais");
            MyCollection.Add("pas");
            MyCollection.Add("trop");
            Assert.Equal(TestList.Count + 3, MyCollection.Count);
            var targetArray = new string[] {"Je", "suis", "presque", "une", "phrase", "mais", "pas", "trop"};
            Assert.Equal(targetArray, MyCollection.Values);
        }
        [Fact]
        public void RemoveAtTest()
        {
            // Remove au milieu
            var MyCollection = TestList;
            MyCollection.RemoveAt(3);
            Assert.Equal(TestList.Count - 1, MyCollection.Count);
            var targetArray = new string[] {"Je", "suis", "presque", "phrase"};
            Assert.Equal(targetArray, MyCollection.Values);

            // Remove au début
            MyCollection.RemoveAt(0);
            Assert.Equal(TestList.Count - 2, MyCollection.Count);
            targetArray = new string[] {"suis", "presque", "phrase"};
            Assert.Equal(targetArray, MyCollection.Values);

            // Remove au milieu
            MyCollection.RemoveAt(MyCollection.Count - 1);
            Assert.Equal(TestList.Count - 3, MyCollection.Count);
            targetArray = new string[] {"suis", "presque"};
            Assert.Equal(targetArray, MyCollection.Values);
        }
        [Fact]
        public void IndexOfTest()
        {
            var MyCollection = TestList;
            Assert.Equal(4, MyCollection.IndexOf("phrase"));
            Assert.Equal(-1, MyCollection.IndexOf("mais"));
        }
        [Fact]
        public void IndexorAccessorTest()
        {
            var MyCollection = TestList;
            Assert.Equal("presque", MyCollection[2]);
            Assert.NotEqual("presque", MyCollection[3]);
            MyCollection[3] = "ta";
            Assert.Equal("ta", MyCollection[3]);
            var targetArray = new string[] {"Je", "suis", "presque", "ta", "phrase"};
            Assert.Equal(targetArray, MyCollection.Values);
        }
        
        [Fact]
        public void InsertTest()
        {
            // Insert au milieu
            var MyCollection = TestList;
            MyCollection.Insert(4, "super");
            Assert.Equal(TestList.Count + 1, MyCollection.Count);
            var targetArray = new string[] {"Je", "suis", "presque", "une", "super", "phrase"};
            Assert.Equal(targetArray, MyCollection.Values);

            // Remove au début
            MyCollection.Insert(0, "Ecoute,");
            Assert.Equal(TestList.Count + 2, MyCollection.Count);
            targetArray = new string[] {"Ecoute,", "Je", "suis", "presque", "une", "super", "phrase"};
            Assert.Equal(targetArray, MyCollection.Values);

            // Remove au milieu
            MyCollection.Insert(MyCollection.Count, ", non ?");
            Assert.Equal(TestList.Count + 3, MyCollection.Count);
            targetArray = new string[] {"Ecoute,", "Je", "suis", "presque", "une", "super", "phrase", ", non ?"};
            Assert.Equal(targetArray, MyCollection.Values);
        }
        [Fact]
        public void RemoveTest()
        {
            var MyCollection = TestList;
            Assert.True(MyCollection.Remove("presque"));
            Assert.Equal(TestList.Count - 1, MyCollection.Count);
            var targetArray = new string[] {"Je", "suis", "une", "phrase"};
            Assert.Equal(targetArray, MyCollection.Values);

            Assert.False(MyCollection.Remove("princesse"));
            Assert.Equal(TestList.Count - 1, MyCollection.Count);
            targetArray = new string[] {"Je", "suis", "une", "phrase"};
            Assert.Equal(targetArray, MyCollection.Values);
        }
        [Fact]
        public void ClearTest()
        {
            var MyCollection = TestList;
            MyCollection.Clear();
            Assert.Empty(MyCollection.Values);
        }
        [Fact]
        public void GetEnumeratorTest()
        {
            var MyCollection = TestList;
            
        }
    }
}
