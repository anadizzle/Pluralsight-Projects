using System;
using GradeBook;
using Xunit;

namespace Gradebook.Tests
{

    public class TypeTests
    {
        [Fact]
        public void ValidGradeRange()
        {
            var book = new Book("Book1");
            book.AddGrade(105);
            
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            // act
            

            // assert
            Assert.Equal("New Name", book1.Name);
    
        }

       [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // act
            

            // assert
            Assert.Equal("Book 1", book1.Name);
    
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // act
            

            // assert
            Assert.Equal("New Name", book1.Name);
    
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act
            

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
    
        }

        
        public void TwoVarsCanReferenceSameObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // act
            

            // assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
            
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
        
    }
}
