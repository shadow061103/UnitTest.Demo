using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class ObjectTest
    {
        [Fact]
        public void Test()
        {
            var p1 = new Person { Id = 1, Name = "1" };
            var p2 = new Person { Id = 1, Name = "1" };
            Assert.Equal(p1, p2);
            Assert.NotSame(p1, p2);
        }

        [Fact(Skip = "test equal")]
        public void 測試用Assert_Equal比對兩物件會失敗()
        {
            var s1 = new Student { Id = 1, Name = "1" };
            var s2 = new Student { Id = 1, Name = "1" };
            //這邊會error
            Assert.Equal(s1, s2);
        }

        [Fact]
        public void 測試用ExpectObject比對兩物件()
        {
            var s1 = new Student { Id = 1, Name = "1" }.ToExpectedObject();
            var s2 = new Student { Id = 1, Name = "1" };
            s1.ShouldEqual(s2);
        }

        [Fact]
        public void 比對物件集合()
        {
            var s1 = new List<Student>
            {
                new Student{ Id=1,Name="1"},
                new Student{ Id=2,Name="2"},
                new Student{ Id=3,Name="2"}
            }.ToExpectedObject();

            var s2 = new List<Student>
            {
                new Student{ Id=1,Name="1"},
                new Student{ Id=2,Name="2"},
                new Student{ Id=3,Name="2"}
            };

            s1.ShouldEqual(s2);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Person)
            {
                var that = obj as Person;
                return this.Id == that.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}